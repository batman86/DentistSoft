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
    public class PatientSearchController : Controller
    {
        ISeassionStateBL sessionStateBL;
        IPatientRepository patientRepository;
        public PatientSearchController(ISeassionStateBL _sessionStateBL, IPatientRepository _patientRepository)
        {
            sessionStateBL = _sessionStateBL;
            patientRepository = _patientRepository;
        }




        //
        // GET: /SecretaryDashboard/PatientSearch/
        public ActionResult Index()
        {
            return View();
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

        public ActionResult PatientSearchInfo()
        {
            int patientID=1;
            string mobileNumber="a", phoneNumber="a", Name="a";

            var s= patientRepository.getPatientListSearchResult(patientID, mobileNumber, phoneNumber, Name);

            return null;

        }
	}
}