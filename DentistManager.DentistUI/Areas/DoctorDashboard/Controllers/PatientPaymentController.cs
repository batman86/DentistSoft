using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.DAL.Abstract;

namespace DentistManager.DentistUI.Areas.DoctorDashboard.Controllers
{
    public class PatientPaymentController : Controller
    {
        IPatientPaymentBL patientPaymentBL;
        ISessionStateManger sessionStateManger;
        IDoctorRepository doctorRepository;
        public PatientPaymentController(IPatientPaymentBL _patientPaymentBL, ISessionStateManger _sessionStateManger, IDoctorRepository _doctorRepository)
        {
            patientPaymentBL = _patientPaymentBL;
            sessionStateManger = _sessionStateManger;
            doctorRepository = _doctorRepository;
        }

        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getDoctorActivePatinet(User.Identity.GetUserId()));
        }

        [NonAction]
        public int getUserCurrentClinecID()
        {
            return sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
        }
        [NonAction]
        public int getDoctorIDbyUserID()
        {
            return doctorRepository.getDoctorIDByUserID(User.Identity.GetUserId());
        }

        //
        // GET: /DoctorDashboard/PatientPayment/
        public ActionResult Index()
        {
            PatientBillInfoWrap billInfo = patientPaymentBL.patientTotalCost(getCurrentPatientID(), getUserCurrentClinecID());
            return View(billInfo);
        }

        public ActionResult DoctorPayment()
        {
            PatientBillInfoWrap billInfo = patientPaymentBL.patientTotalCost(getCurrentPatientID(), getUserCurrentClinecID());
            return View(billInfo);
        }
	}
}