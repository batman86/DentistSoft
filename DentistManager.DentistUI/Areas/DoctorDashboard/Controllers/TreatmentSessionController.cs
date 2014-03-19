using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentistManager.Domain.BL.Abstract;

namespace DentistManager.DentistUI.Areas.DoctorDashboard.Controllers
{
    public class TreatmentSessionController : Controller
    {
        IOpperationRepository opperationRepository;
        ITreatmentRepository treatmentRepository;
        ITreatmentBL treatmentBL;
        IMaterialRepository materialRepository;
        public TreatmentSessionController(IOpperationRepository _opperationRepository, ITreatmentRepository _treatmentRepository, ITreatmentBL _treatmentBL, IMaterialRepository _materialRepository)
        {
            opperationRepository = _opperationRepository;
            treatmentRepository = _treatmentRepository;
            treatmentBL = _treatmentBL;
            materialRepository = _materialRepository;
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
            ViewBag.PatientID = 1;
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
        public ActionResult GetMatrialList(int treatmentID = 0)
        {
           IEnumerable<MaterialMiniViewModel> matrailList=  materialRepository.getMatrailMiniList();
           return Json(matrailList);
        }

        [HttpPost]
        public void RemoveTreatmentItem(int treatmentID = 0)
        {
            treatmentRepository.RemoveTreatmentByID(treatmentID);
        }

        [HttpPost]
        public void TreatmentSave(IEnumerable<TreatmentPresntViewModel> treatmentList)
        {
            ViewBag.AppointmentID = 1;
            ViewBag.DoctorID = 1;
            ViewBag.PatientID = 1;
            ViewBag.clinecID = 1;

            treatmentBL.saveTreatment(treatmentList, 1, 1, 1,1);
        }

        [HttpPost]
        public bool matrailTreatmentSave(MatrailToSaveWrapViewModel matrailToSave)
        {
            if (matrailToSave.treatmentID == 0)
                return false;
            if (matrailToSave.vmMatrailListToSave == null)
                return false;
            if (matrailToSave.vmMatrailListToSave.Count() == 0)
                return false;

            bool check=  materialRepository.SaveTreatmentMatrail(matrailToSave.vmMatrailListToSave, matrailToSave.treatmentID);
         
            return check;
        }
	}
}