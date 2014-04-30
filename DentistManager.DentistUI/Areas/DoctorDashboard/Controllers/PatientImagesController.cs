using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.Domain.ViewModel;

namespace DentistManager.DentistUI.Areas.DoctorDashboard.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class PatientImagesController : Controller
    {
        //
        // GET: /DoctorDashboard/PatientImages/
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
        // GET: /DoctorDashboard/PatientImages/
        public ActionResult Index()
        {
            return View();
        }

        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getDoctorActivePatinet(User.Identity.GetUserId()));
        }


        // patient Images -------------------------------------------------********************************************------------------------------------- //
        public ActionResult patientImagesList(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            IEnumerable<ImagesPresentViewModel> patientImageList = patientRepository.getPatientImagesList(patientID);
            if (patientImageList == null)
                return HttpNotFound();
            ViewBag.patientID = patientID;

            return View(patientImageList);
        }

        //
        // GET: /DoctorDashboard/PatientHistoryDetails/PatientImagesDetails/5
        public ActionResult PatientImagesDetails(int patientImageID)
        {
            ImagesPresentViewModel patientImage = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImage == null)
                return HttpNotFound();
            return View(patientImage);
        }

        //
        // GET: /DoctorDashboard/PatientManagement/PatientImagesCreate
        public ActionResult PatientImagesCreate(int patientID = 0)
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
        // POST: /DoctorDashboard/PatientManagement/PatientImagesCreate
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
                            ob.PatientImageSaver(System.Drawing.Image.FromStream(list[0].InputStream), Server.MapPath(@"~/Content/Images/") + imageCategoryName, @"../../Content/Images/" + imageCategoryName, imagesViewModel);

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
                    ImageCreateViewModel imageCreateViewModel = new ImageCreateViewModel();

                    imageCreateViewModel.imageCategoryList = imageRepository.getImagesCategoryList();
                    imageCreateViewModel.appointmentList = appointmentRepository.getPatientAppountmentList(imagesViewModel.PatientID);
                    return View(imageCreateViewModel);
                }

                return RedirectToAction("patientImagesList", new { patientID = imagesViewModel.PatientID });
            }
            catch
            {
                ViewBag.patientID = imagesViewModel.PatientID;
                ImageCreateViewModel imageCreateViewModel = new ImageCreateViewModel();

                imageCreateViewModel.imageCategoryList = imageRepository.getImagesCategoryList();
                imageCreateViewModel.appointmentList = appointmentRepository.getPatientAppountmentList(imagesViewModel.PatientID);
                return View(imageCreateViewModel);
            }
        }

        //
        // GET: /DoctorDashboard/PatientManagement/PatientImagesEdit/5
        public ActionResult PatientImagesEdit(int patientImageID)
        {
            ImagesPresentViewModel patientImagesViewModel = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImagesViewModel == null)
                return HttpNotFound();
            //  ViewBag.patientID = patientHistory.PatientID;

            return View(patientImagesViewModel);
        }

        //
        // POST: /DoctorDashboard/PatientManagement/PatientImagesEdit/5
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


        // GET: /DoctorDashboard/PatientManagement/PatientImagesDelete/5
        public ActionResult PatientImagesDelete(int patientImageID)
        {
            ImagesPresentViewModel patientImageViewModel = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImageViewModel == null)
                return HttpNotFound();
            return View(patientImageViewModel);
        }

        //
        // POST: /DoctorDashboard/PatientManagement/ConfirmPatientImagesDelete/5
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