using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistManager.DentistUI.Areas.DoctorDashboard.Controllers
{
    public class TreatmentSessionController : Controller
    {
        IOpperationRepository opperationRepository;
        ITreatmentRepository treatmentRepository;
        public TreatmentSessionController(IOpperationRepository _opperationRepository, ITreatmentRepository _treatmentRepository)
        {
            opperationRepository = _opperationRepository;
            treatmentRepository = _treatmentRepository;
        }

        //
        // GET: /DoctorDashboard/TreatmentSession/

        public ActionResult Index()
        {
            return View();
        }
        //  /DoctorDashboard/TreatmentSession/TreatmentSessionMain
        public ActionResult TreatmentSessionMain()
        {
            // get last appointment date by patient and doctor id
            ViewBag.AppointmentID = 1;
            ViewBag.DoctorID = 1;
            ViewBag.PatientID = 9;
            ViewBag.appointmentDate = DateTime.Now;
            return View();
        }

        public ActionResult opperationList()
        {
            var opperationList = opperationRepository.getOpperationList();
            return PartialView(opperationList);
        }

        //   /DoctorDashboard/TreatmentSession/GetTreatmentListByPatientID
        [HttpPost]
        public ActionResult GetTreatmentListByPatientID(int patientID = 0)
        {
            IEnumerable<TreatmentPresntViewModel> treatmentViewModel = treatmentRepository.getPatientPresntTreatmentList(patientID);
            return Json(treatmentViewModel);
        }

        [HttpPost]
        public void RemoveTreatmentItem(int treatmentID = 0)
        {
            treatmentRepository.RemoveTreatmentByID(treatmentID);
        }
	}
}