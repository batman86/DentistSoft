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
    public class PatientSearchController : Controller
    {
        //
        // GET: /DoctorDashboard/PatientSearch/
        IPatientRepository patientRepository;
        ISessionStateManger sessionStateManger;
        public PatientSearchController(IPatientRepository _patientRepository, ISessionStateManger _sessionStateManger)
        {
            patientRepository = _patientRepository;
            sessionStateManger = _sessionStateManger;
        }

        //
        // GET: /DoctorDashboard/PatientSearch/
        public ActionResult Index()
        {
            return View();
        }


        [NonAction]
        public int getUserCurrentClinecID()
        {
            return sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
        }

        // /DoctorDashboard/PatientSearch/getCurrentPatientID
        [NonAction]
        public int getCurrentPatientID()
        {
            string CurrentUserID = User.Identity.GetUserId();
            string patientID;

            patientID = sessionStateManger.getDoctorActivePatinet(CurrentUserID);

            if (patientID == null)
                return 0;

            return int.Parse(patientID);
        }

        // /DoctorDashboard/PatientSearch/ActivePatientTopBar
        public ActionResult ActivePatientTopBar()
        {
            int patientID = getCurrentPatientID();
            if (patientID == 0)
                return PartialView("NoActivePatientView");

            PatientMiniData patient = patientRepository.getPatinetMiniInfo(patientID);
            if (patient == null)
                return PartialView("NoActivePatientView");

            return PartialView(patient);
        }


        // /DoctorDashboard/PatientSearch/ActivePatientTopBarSearch
        public ActionResult ActivePatientTopBarSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActivePatientTopBarSearch(string mobileNumber, int PatientID = 0)
        {
            if (mobileNumber == string.Empty && PatientID == 0)
                return View();
            try
            {
                int patientID = patientRepository.getPatientIDSearchResultByMobileOrID(PatientID, mobileNumber);
                if (patientID != 0)
                {
                    sessionStateManger.setDoctorActivePatinet(User.Identity.GetUserId(), patientID);

                    ViewBag.Msg = "Patient Findes";
                }

                else
                    ViewBag.Msg = "Could Not Find this Patient";

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult doctorPatientActvator(int PatientID = 0)
        {
            if (PatientID != 0)
            {
                sessionStateManger.setDoctorActivePatinet(User.Identity.GetUserId(), PatientID);
                 ViewBag.Msg = "Patient Findes";
            }

            return RedirectToAction("patientList", "PatientManagement");
        }



        // /DoctorDashboard/PatientSearch/PatientAdvancedSearch
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