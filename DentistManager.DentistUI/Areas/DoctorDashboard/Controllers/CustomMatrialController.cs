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
    //[Authorize(Roles = "Doctor")]
    public class CustomMatrialController : Controller
    {
        //
        // GET: /DoctorDashboard/CustomMatrial/
        ICustomMatrialRepository customMatrialRepository;
        ISessionStateManger sessionStateManger;
        IDoctorRepository doctorRepository;
        public CustomMatrialController(ICustomMatrialRepository _customMatrialRepository, ISessionStateManger _sessionStateManger, IDoctorRepository _doctorRepository)
        {
            sessionStateManger = _sessionStateManger;
            customMatrialRepository = _customMatrialRepository;
            doctorRepository = _doctorRepository;
        }

        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getDoctorActivePatinet(User.Identity.GetUserId()));
        }

        [NonAction]
        public int getDoctorIDbyUserID()
        {
            return doctorRepository.getDoctorIDByUserID(User.Identity.GetUserId());
        }

        [NonAction]
        public int getUserCurrentClinecID()
        {
            return sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
        }
        //
        // GET: /DoctorDashboard/CustomMatrial/
        public ActionResult Index()
        {
            return View();
        }
        // /DoctorDashboard/CustomMatrial/customMatrialList
        public ActionResult customMatrialList(int DoctorID = 0)
        {
            if (DoctorID == 0)
                DoctorID = getDoctorIDbyUserID();
            IEnumerable<CustomMaterialPresentViewModel> customMatrialList;
            string FilterType = sessionStateManger.getDoctorCustomMatrailFilter(User.Identity.GetUserId());

            if(FilterType=="1")
                customMatrialList = customMatrialRepository.getCustomMaterialList(DoctorID);
            else if(FilterType=="2")
            {
                customMatrialList = customMatrialRepository.getOldCustomMaterialList(DoctorID);
            }
            else if (FilterType == "3")
            {
                int patientID = getCurrentPatientID();
                customMatrialList = customMatrialRepository.getCustomMaterialList(DoctorID, patientID);
            }
            else 
            {
                int patientID = getCurrentPatientID();
                customMatrialList = customMatrialRepository.getOldCustomMaterialList(DoctorID, patientID);
            }
            if (customMatrialList == null)
                return HttpNotFound();
            ViewBag.FilterType = FilterType;

            return View(customMatrialList);
        }

        [HttpPost]
        public ActionResult customMatrialList(int DoctorID = 0, string FilterType="1")
        {
            if (DoctorID == 0)
                DoctorID = getDoctorIDbyUserID();
            IEnumerable<CustomMaterialPresentViewModel> customMatrialList;
            sessionStateManger.setDoctorCustomMatrailFilter(User.Identity.GetUserId(), FilterType);
            if (FilterType == "1")
                customMatrialList = customMatrialRepository.getCustomMaterialList(DoctorID);
            else if (FilterType == "2")
            {
                customMatrialList = customMatrialRepository.getOldCustomMaterialList(DoctorID);
            }
            else if (FilterType == "3")
            {
                int patientID = getCurrentPatientID();
                customMatrialList = customMatrialRepository.getCustomMaterialList(DoctorID, patientID);
            }
            else 
            {
                int patientID = getCurrentPatientID();
                customMatrialList = customMatrialRepository.getOldCustomMaterialList(DoctorID, patientID);
            }

            if (customMatrialList == null)
                return HttpNotFound();
            ViewBag.FilterType = FilterType;

            return View(customMatrialList);
        }

        public ActionResult customMatrialdetails(int customMatrialID=0)
        {
            if(customMatrialID==0)
                return HttpNotFound();
            CustomMaterialPresentViewModel customMatrial = customMatrialRepository.getCustomMaterialDetails(customMatrialID);
            if (customMatrial == null)
                return HttpNotFound();
            return View(customMatrial);
        }


        public ActionResult customMatrialCreate(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            ViewBag.patientID = patientID;
            return View();
        }

        [HttpPost]
        public ActionResult customMatrialCreate(CustomMaterialViewModel customMaterialViewModel)
        {
            try
            {
                if (ModelState.IsValid && customMaterialViewModel.Name != null)
                {
                    customMaterialViewModel.RequestDate = DateTime.Now;
                    customMaterialViewModel.PatientID = getCurrentPatientID();
                    customMaterialViewModel.DoctorID = getDoctorIDbyUserID();
                    customMaterialViewModel.clinecid = getUserCurrentClinecID();

                    bool check = customMatrialRepository.addNewCustomMaterial(customMaterialViewModel);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("customMatrialList");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult customMatrialEdit(int customMatrialID)
        {
            CustomMaterialPresentViewModel customMaterialPresentViewModel = customMatrialRepository.getCustomMaterialDetails(customMatrialID);
            if (customMaterialPresentViewModel == null)
                return HttpNotFound();
            return View(customMaterialPresentViewModel);
        }


        [HttpPost]
        public ActionResult customMatrialEdit(CustomMaterialViewModel customMaterialViewModel)
        {
            try
            {
                if (ModelState.IsValid && customMaterialViewModel.Name !=null)
                {
                    bool check = customMatrialRepository.updateCustomMaterial(customMaterialViewModel);
                }
                else
                {
                    return View(customMaterialViewModel);
                }
                return RedirectToAction("customMatrialList", new { patientID = customMaterialViewModel.PatientID });
            }
            catch
            {
                return View(customMaterialViewModel);
            }
        }


        public ActionResult customMatrialDelete(int customMatrialID)
        {
            CustomMaterialPresentViewModel customMaterialPresentViewModel = customMatrialRepository.getCustomMaterialDetails(customMatrialID);
            if (customMaterialPresentViewModel == null)
                return HttpNotFound();
            //ViewBag.patientID = customMaterialPresentViewModel.PatientID;

            return View(customMaterialPresentViewModel);
        }


        [HttpPost]
        [ActionName("customMatrialDelete")]
        public ActionResult ConfirmcustomMatrialDelete(int customMatrialID)
        {
            try
            {
                bool check = customMatrialRepository.deleteCustomMaterial(customMatrialID);

                return RedirectToAction("customMatrialList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult getCustomMatrailPayment()
        {
            int doctorID = getDoctorIDbyUserID();
            int clinicID = getUserCurrentClinecID();

            CustomMatrailPaymentViewModel customMatrailPaymentViewModel = new CustomMatrailPaymentViewModel();

            customMatrailPaymentViewModel.Payed = customMatrialRepository.getDoctorCustomMatrailCostTotalPayed(clinicID, doctorID);
            customMatrailPaymentViewModel.unPayed = customMatrialRepository.getDoctorCustomMatrailCostTotalUnPayed(clinicID, doctorID);


            return View(customMatrailPaymentViewModel);
        }
	}
}