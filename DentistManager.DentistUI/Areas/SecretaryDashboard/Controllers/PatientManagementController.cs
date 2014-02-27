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
        public PatientManagementController(IPatientRepository _patientRepository, ISeassionStateBL _sessionStateBL)
        {
            patientRepository = _patientRepository;
            sessionStateBL = _sessionStateBL;
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
             //User.Identity.GetUserId();
            string userID = "1";
            string patientID;

            SessionStateManger stm = new SessionStateManger(sessionStateBL);
            patientID = stm.getSecyrtaryActivePatinet(userID);
           

            PatientMiniData patient = patientRepository.getPatinetMiniInfo(int.Parse(patientID));

            return PartialView(patient);

        }


        // patient History -------------------------------------------------------------------------------------- //

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
                    return View();
                }

                return RedirectToAction("patientHistoryList");
            }
            catch
            {
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
                    return View();
                }
                return RedirectToAction("patientHistoryList");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientHistoryDelete/5
        public ActionResult PatientHistoryDelete(int patientHistoryID)
        {
            PatientHistoryViewModel patientHistory = patientRepository.getPatinetHistoryDetails(patientHistoryID);
            if (patientHistory == null)
                return HttpNotFound();
            return View(patientHistory);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientHistoryDelete/5
        [HttpPost]
        [ActionName("PatientHistoryDelete")]
        public ActionResult ConfirmPatientHistoryDelete(int patientHistoryID)
        {
            try
            {
                bool check = patientRepository.deletePatientHistory(patientHistoryID);
                return RedirectToAction("patientHistoryList");
            }
            catch
            {
                return View();
            }
        }
    }
}
