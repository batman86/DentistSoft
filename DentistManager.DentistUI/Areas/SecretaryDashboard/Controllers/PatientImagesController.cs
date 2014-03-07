using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.DAL.Abstract;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    public class PatientImagesController : Controller
    {

        IimagesRepository imageRepository;
        IPatientRepository patientRepository;
        IAppointmentRepository appointmentRepository;
        ISessionStateManger sessionStateManger;
        public PatientImagesController(IimagesRepository _imageRepository, IPatientRepository _patientRepository, IAppointmentRepository _appointmentRepository, ISessionStateManger _sessionStateManger)
        {
            imageRepository = _imageRepository;
            patientRepository = _patientRepository;
            appointmentRepository = _appointmentRepository;
            sessionStateManger = _sessionStateManger;
        }
        //
        // GET: /SecretaryDashboard/PatientImages/
        public ActionResult Index()
        {
            return View();
        }

        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getSecyrtaryActivePatinet(User.Identity.GetUserId()));
        }


        // patient Images -------------------------------------------------********************************************------------------------------------- //
        public ActionResult patientImagesList(int patientID=0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            IEnumerable<ImagesViewModel> patientImageList = patientRepository.getPatientImagesList(patientID);
            if (patientImageList == null)
                return HttpNotFound();
            ViewBag.patientID = patientID;

            return View(patientImageList);
        }

        //
        // GET: /SecretaryDashboard/PatientHistoryDetails/PatientImagesDetails/5
        public ActionResult PatientImagesDetails(int patientImageID)
        {
            ImagesViewModel patientImage = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImage == null)
                return HttpNotFound();
            return PartialView(patientImage);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientImagesCreate
        public ActionResult PatientImagesCreate(int patientID=0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            ImageCreateViewModel imageCreateViewModel = new ImageCreateViewModel();

            imageCreateViewModel.imageCategoryList = imageRepository.getImagesCategoryList();
            imageCreateViewModel.appointmentList = appointmentRepository.getPatientAppountmentList(patientID);

            ViewBag.patientID = patientID;
            return View(imageCreateViewModel);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientImagesCreate
        [HttpPost]
        public ActionResult PatientImagesCreate(ImagesViewModel imagesViewModel, string name, IEnumerable<HttpPostedFileBase> files, FormCollection coll)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (files != null)
                    {
                        List<HttpPostedFileBase> list = files.ToList();
                        if (list[0] != null)
                        {
                            imagesViewModel.PatientID = getCurrentPatientID();

                            string imageCategoryName = imageRepository.getIMageCategoryNameByID(imagesViewModel.ImageCategoryID);

                            ImagesDrawing ob = new ImagesDrawing();
                            ob.PatientImageSaver(System.Drawing.Image.FromStream(list[0].InputStream), Server.MapPath(@"~/Content/Images/" + imageCategoryName + "/"), imagesViewModel);

                            return RedirectToAction("patientImagesList", new { patientID = imagesViewModel.PatientID });
                        }
                    }
                    else
                    {
                        ViewBag.patientID = imagesViewModel.PatientID;
                        return View();
                    }

                }
                else
                {
                    ViewBag.patientID = imagesViewModel.PatientID;
                    return View();
                }

                return RedirectToAction("patientImagesList", new { patientID = imagesViewModel.PatientID });
            }
            catch
            {
                ViewBag.patientID = imagesViewModel.PatientID;
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientImagesEdit/5
        public ActionResult PatientImagesEdit(int patientImageID)
        {
            ImagesViewModel patientImagesViewModel = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImagesViewModel == null)
                return HttpNotFound();
            //  ViewBag.patientID = patientHistory.PatientID;

            return View(patientImagesViewModel);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientImagesEdit/5
        [HttpPost]
        public ActionResult PatientImagesEdit(ImagesViewModel patientImageViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = patientRepository.updatePatinetImage(patientImageViewModel);
                }
                else
                {
                    return View();
                }
                return RedirectToAction("patientImagesList", new { patientID = patientImageViewModel.PatientID });
            }
            catch
            {
                return View();
            }
        }


        // GET: /SecretaryDashboard/PatientManagement/PatientImagesDelete/5
        public ActionResult PatientImagesDelete(int patientImageID)
        {
            ImagesViewModel patientImageViewModel = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImageViewModel == null)
                return HttpNotFound();
            return View(patientImageViewModel);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/ConfirmPatientImagesDelete/5
        [HttpPost]
        [ActionName("PatientImagesDelete")]
        public ActionResult ConfirmPatientImagesDelete(int patientImageID, string patientID)
        {
            try
            {
                bool check = patientRepository.deletePatientImages(patientImageID);
                return RedirectToAction("patientImagesList", new { patientID = patientID });
            }
            catch
            {
                return View();
            }
        }
	}
}