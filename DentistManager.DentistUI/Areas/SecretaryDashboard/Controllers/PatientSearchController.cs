using DentistManager.Domain.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;


namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class PatientSearchController : Controller
    {

        IPatientRepository patientRepository;
        ISessionStateManger sessionStateManger;
        public PatientSearchController(IPatientRepository _patientRepository, ISessionStateManger _sessionStateManger)
        {
            patientRepository = _patientRepository;
            sessionStateManger = _sessionStateManger;
        }

        //
        // GET: /SecretaryDashboard/PatientSearch/
        public ActionResult Index()
        {
            return View();
        }


        [NonAction]
        public int getUserCurrentClinecID()
        {
            return sessionStateManger.getClinecIDForCurrentSecurtary(User.Identity.GetUserId());
        }

        // /SecretaryDashboard/PatientSearch/getCurrentPatientID
       // [NonAction]
        public int getCurrentPatientID()
        {
            string CurrentUserID = User.Identity.GetUserId();
            string patientID;

            patientID = sessionStateManger.getSecyrtaryActivePatinet(CurrentUserID);

            if (patientID == null)
                return 0;

             return int.Parse(patientID);
        }

        // /SecretaryDashboard/PatientSearch/ActivePatientTopBar
        public ActionResult ActivePatientTopBar()
        {
            int patientID = getCurrentPatientID();
            if (patientID == 0)
                return PartialView("NoActivePatientView");

            PatientMiniData patient = patientRepository.getPatinetMiniInfo(patientID);
            if(patient ==null)
                return PartialView("NoActivePatientView");

            return PartialView(patient);
        }


        // /SecretaryDashboard/PatientSearch/ActivePatientTopBarSearch
        public ActionResult ActivePatientTopBarSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActivePatientTopBarSearch(string mobileNumber, int PatientID=0)
        {
            if (mobileNumber == string.Empty && PatientID == 0)
                return View();
            try
            {
                int patientID = patientRepository.getPatientIDSearchResultByMobileOrID(PatientID, mobileNumber);
                if (patientID != 0)
                {
                    sessionStateManger.setSecyrtaryActivePatinet(User.Identity.GetUserId(), patientID);
             
                    ViewBag.Msg = "Patient Findes";
                }

                else
                    ViewBag.Msg = "Could Not Find this Patient";

               return  View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SecyrtaryPatientActvator(int PatientID = 0)
        {
            if (PatientID != 0)
            {
                sessionStateManger.setSecyrtaryActivePatinet(User.Identity.GetUserId(), PatientID);
                ViewBag.Msg = "Patient Findes";
            }

            return RedirectToAction("patientList", "PatientManagement");
        }

        // /SecretaryDashboard/PatientSearch/PatientAdvancedSearch
        public ActionResult PatientAdvancedSearch()
        {
            return View("PatientAdvancedSearchForm");
        }

        [HttpPost]
        public ActionResult PatientAdvancedSearch(string patientMobileNumber, string patientPhoneNumber, string patientName, int patientID = 0)
        {
            // filter by clinec id
            IEnumerable<PatientMiniData> patintSearchResultList = patientRepository.getPatientListSearchResult(patientID, patientMobileNumber, patientPhoneNumber, patientName, getUserCurrentClinecID());
            return View(patintSearchResultList);
        }
	}
}