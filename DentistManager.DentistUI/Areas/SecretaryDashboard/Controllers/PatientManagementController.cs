using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.BL.Abstract;
using DentistManager.DentistUI.Infrastructure;
using Microsoft.AspNet.Identity;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    public class PatientManagementController : Controller
    {
        ISeassionStateBL sessionStateBL;
        IPatientRepository patientRepository;
        IAppointmentRepository appointmentRepository;
        IimagesRepository imageRepository;
        public PatientManagementController(IPatientRepository _patientRepository, ISeassionStateBL _sessionStateBL, IAppointmentRepository _appointmentRepository, IimagesRepository _imageRepository)
        {
            patientRepository = _patientRepository;
            sessionStateBL = _sessionStateBL;
            appointmentRepository = _appointmentRepository;
            imageRepository = _imageRepository;
        }
        //
        // GET: /SecretaryDashboard/PatientManagement/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /SecretaryDashboard/PatientManagement/patientList
        public ActionResult patientList()
        {
            IEnumerable<PatientMiniData> patientList = patientRepository.getPatientList(0, 10);
            if (patientList == null)
                return HttpNotFound();
            return View(patientList);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientDetails/5
        public ActionResult PatientDetails(int patientID)
        {
            Patient patient = patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return PartialView(patient);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientCreate
        public ActionResult PatientCreate()
        {
            return View();
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientCreate
        [HttpPost]
        public ActionResult PatientCreate(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   bool check= patientRepository.addNewPatinetBasicInfo(patient);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientEdit/5
        public ActionResult PatientEdit(int patientID)
        {
            Patient patient = patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientEdit/5
        [HttpPost]
        public ActionResult PatientEdit(Patient patient)
        {
            try
            {
               if(ModelState.IsValid)
               {
                  bool check = patientRepository.updatePatinetBasicInfo(patient);
               }
               else
               {
                   return View();
               }
               return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientDelete/5
        public ActionResult PatientDelete(int patientID)
        {
            Patient patient= patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientDelete/5
        [HttpPost]
        [ActionName("PatientDelete")]
        public ActionResult ConfirmPatientDelete(int patientID)
        {
            try
            {
                bool check = patientRepository.deletepatientBasicInfo(patientID);
                return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActivePatientTopBar()
        {
             //get the member ship user id
            string userID = User.Identity.GetUserId();
            string patientID;

            SessionStateManger stm = new SessionStateManger(sessionStateBL);
            patientID = stm.getSecyrtaryActivePatinet(userID);
           

            PatientMiniData patient = patientRepository.getPatinetMiniInfo(int.Parse(patientID));

            return PartialView(patient);

        }


        // patient History -------------------------------------------------********************************************------------------------------------- //

        public ActionResult patientHistoryList(int patientID)
        {
            IEnumerable<PatientHistoryViewModel> patientHistoryList = patientRepository.getPatientHistoryList(patientID);
            if (patientHistoryList == null)
                return HttpNotFound();
            ViewBag.patientID = patientID;

            return View(patientHistoryList);
        }

        //
        // GET: /SecretaryDashboard/PatientHistoryDetails/PatientDetails/5
        public ActionResult PatientHistoryDetails(int patientHistoryID)
        {
            PatientHistoryViewModel patientHistory = patientRepository.getPatinetHistoryDetails(patientHistoryID);
            if (patientHistory == null)
                return HttpNotFound();
            return PartialView(patientHistory);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientHistoryCreate
        public ActionResult PatientHistoryCreate(int patientID)
        {
            ViewBag.patientID = patientID;
            return View();
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientHistoryCreate
        [HttpPost]
        public ActionResult PatientHistoryCreate(PatientHistoryViewModel patientHistory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = patientRepository.addNewPatinetHistory(patientHistory);
                }
                else
                {
                    ViewBag.patientID = patientHistory.PatientID;
                    return View();
                }

                return RedirectToAction("patientHistoryList", new { patientID = patientHistory.PatientID });
            }
            catch
            {
                ViewBag.patientID = patientHistory.PatientID;
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientHistoryEdit/5
        public ActionResult PatientHistoryEdit(int patientHistoryID)
        {
            PatientHistoryViewModel patientHistory = patientRepository.getPatinetHistoryDetails(patientHistoryID);
            if (patientHistory == null)
                return HttpNotFound();
          //  ViewBag.patientID = patientHistory.PatientID;
            
            return View(patientHistory);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientHistoryEdit/5
        [HttpPost]
        public ActionResult PatientHistoryEdit(PatientHistoryViewModel patientHistory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = patientRepository.updatePatinetHistory(patientHistory);
                }
                else
                {
                    return View(patientHistory);
                }
                return RedirectToAction("patientHistoryList", new { patientID = patientHistory.PatientID });
            }
            catch
            {
                return View(patientHistory);
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientHistoryDelete/5
        public ActionResult PatientHistoryDelete(int patientHistoryID)
        {
            PatientHistoryViewModel patientHistory = patientRepository.getPatinetHistoryDetails(patientHistoryID);
            if (patientHistory == null)
                return HttpNotFound();
            ViewBag.patientID = patientHistory.PatientID;
            return View(patientHistory);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientHistoryDelete/5
        [HttpPost]
        [ActionName("PatientHistoryDelete")]
        public ActionResult ConfirmPatientHistoryDelete(int patientHistoryID,string patientID)
        {
            try
            {
                bool check = patientRepository.deletePatientHistory(patientHistoryID);
                return RedirectToAction("patientHistoryList", new { patientID = patientID });
            }
            catch
            {
                return View();
            }
        }

        // patient Images -------------------------------------------------********************************************------------------------------------- //
        public ActionResult patientImagesList(int patientID)
        {
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
        public ActionResult PatientImagesCreate(int patientID)
        {
            ImageCreateViewModel imageCreateViewModel = new ImageCreateViewModel();

           // imageCreateViewModel.image = new ImagesViewModel();
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
                            ImagesDrawing ob = new ImagesDrawing();
                            ob.PatientImageSaver(System.Drawing.Image.FromStream(list[0].InputStream), Server.MapPath(@"~/Content/Images"), imagesViewModel);

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
