using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class PatientIllnessHistoryController : Controller
    {

        IPatientRepository patientRepository;
        ISessionStateManger sessionStateManger;
        public PatientIllnessHistoryController(IPatientRepository _patientRepository, ISessionStateManger _sessionStateManger)
        {
            sessionStateManger = _sessionStateManger;
            patientRepository = _patientRepository;
        }

        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getSecyrtaryActivePatinet(User.Identity.GetUserId()));
        }
        
        //
        // GET: /SecretaryDashboard/PatientIllnessHistory/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult patientHistoryList(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

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
            return View(patientHistory);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientHistoryCreate
        public ActionResult PatientHistoryCreate(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

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
        public ActionResult ConfirmPatientHistoryDelete(int patientHistoryID, int patientID = 0)
        {
            try
            {
                if (patientID == 0)
                    patientID = getCurrentPatientID();

                bool check = patientRepository.deletePatientHistory(patientHistoryID);
                return RedirectToAction("patientHistoryList", new { patientID = patientID });
            }
            catch
            {
                return View();
            }
        }
	}
}