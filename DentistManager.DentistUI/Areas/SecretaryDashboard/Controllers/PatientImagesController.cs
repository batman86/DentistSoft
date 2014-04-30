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
    [Authorize(Roles = "Secretary")]
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
        // /SecretaryDashboard/PatientImages/patientImagesList
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

        //[HttpPost]
        //public ActionResult patientImagesList(int patientID = 0, int ImageCategoryID = 0, int AppointmentID = 0)
        //{
        //    if (patientID == 0)
        //        patientID = getCurrentPatientID();

        //    IEnumerable<ImagesViewModel> patientImageList = patientRepository.getPatientImagesList(patientID);


        //    ImageListWrapViewModel imageListWrapViewModel = new ImageListWrapViewModel();
        //    imageListWrapViewModel.imageCategoryList = imageRepository.getImagesCategoryList();
        //    imageListWrapViewModel.appointmentList = appointmentRepository.getPatientAppountmentList(patientID); ;
        //    imageListWrapViewModel.patientImageList = patientImageList;


        //    if (patientImageList == null)
        //        return HttpNotFound();

        //    ViewBag.patientID = patientID;

        //    return View(patientImageList);
        //}


        public ActionResult PatientImagesDetails(int patientImageID)
        {
            ImagesPresentViewModel patientImage = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImage == null)
                return HttpNotFound();
            return View(patientImage);
        }

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
                }
                    ViewBag.patientID = imagesViewModel.PatientID;
                    ImageCreateViewModel imageCreateViewModel = new ImageCreateViewModel();

                    imageCreateViewModel.imageCategoryList = imageRepository.getImagesCategoryList();
                    imageCreateViewModel.appointmentList = appointmentRepository.getPatientAppountmentList(imagesViewModel.PatientID);
                    return View(imageCreateViewModel);

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

        public ActionResult PatientImagesEdit(int patientImageID=0)
        {
            ImagesPresentViewModel patientImagesViewModel = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImagesViewModel == null)
                return HttpNotFound();
            //  ViewBag.patientID = patientHistory.PatientID;

            return View(patientImagesViewModel);
        }

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


        public ActionResult PatientImagesDelete(int patientImageID)
        {
            ImagesPresentViewModel patientImageViewModel = patientRepository.getPatinetImagesDetails(patientImageID);
            if (patientImageViewModel == null)
                return HttpNotFound();
            return View(patientImageViewModel);
        }


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