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
    [Authorize(Roles = "Doctor")]
    public class PatientPaymentController : Controller
    {
        IPatientPaymentBL patientPaymentBL;
        ISessionStateManger sessionStateManger;
        IDoctorRepository doctorRepository;
        IPatientRepository patientRepository;
        public PatientPaymentController(IPatientPaymentBL _patientPaymentBL, ISessionStateManger _sessionStateManger, IDoctorRepository _doctorRepository, IPatientRepository _patientRepository)
        {
            patientPaymentBL = _patientPaymentBL;
            sessionStateManger = _sessionStateManger;
            doctorRepository = _doctorRepository;
            patientRepository = _patientRepository;
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

        public ActionResult DoctorClinecPaymnet()
        {
            try
            {
                int clinecID = getUserCurrentClinecID();
                int doctorID = getDoctorIDbyUserID();

                DateTime date = DateTime.Now;
                // day start
                DateTime from = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
                // day end
                DateTime to = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);

                PatientBillInfoWrap billInfo;
                List<PatientBillInfoWrap> patientBillInfoWrap = new List<PatientBillInfoWrap>();
                DoctorPatientBillInfoWrap doctorPatientBillInfoWrap = new DoctorPatientBillInfoWrap();


                IEnumerable<PatientMiniData> patientList = patientRepository.getPatientListForDoctor(clinecID, doctorID, from, to);

                if (patientList == null)
                    return HttpNotFound();

                foreach (PatientMiniData item in patientList)
                {
                    billInfo = patientPaymentBL.patientTotalCost(item.PatientID, clinecID,from,to);
                    billInfo.patientID = item.PatientID;
                    billInfo.patientName = item.Name;
                    patientBillInfoWrap.Add(billInfo);
                }

                patientBillInfoWrap.TrimExcess();

                billInfo = new PatientBillInfoWrap();

                billInfo.TotalCost = patientBillInfoWrap.Sum(x => x.TotalCost);
                billInfo.Remain = patientBillInfoWrap.Sum(x => x.Remain);
                billInfo.materialCost = patientBillInfoWrap.Sum(x => x.materialCost);
                billInfo.customMatrialCost = patientBillInfoWrap.Sum(x => x.customMatrialCost);
                billInfo.opperationCost = patientBillInfoWrap.Sum(x => x.opperationCost);
                billInfo.treatmentCost = patientBillInfoWrap.Sum(x => x.treatmentCost);
                billInfo.PatientPayment = patientBillInfoWrap.Sum(x => x.PatientPayment);


                doctorPatientBillInfoWrap.patientPaymentInfoList = patientBillInfoWrap;
                doctorPatientBillInfoWrap.TotalPatientPaymentInfo = billInfo;

                return View(doctorPatientBillInfoWrap);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
           
        }
	}
}