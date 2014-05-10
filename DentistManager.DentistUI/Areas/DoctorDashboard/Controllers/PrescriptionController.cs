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
    public class PrescriptionController : Controller
    {
        //
        // GET: /DoctorDashboard/Prescription/
        IPrescriptionRepository prescriptionRepository;
        ISessionStateManger sessionStateManger;
        IMedicineRepository medicineRepository;
        IAppointmentRepository appointmentRepository;
        IDoctorRepository doctorRepository;
        public PrescriptionController(IPrescriptionRepository _prescriptionRepository, ISessionStateManger _sessionStateManger, IMedicineRepository _medicineRepository, IAppointmentRepository _appointmentRepository, IDoctorRepository _doctorRepository)
        {
            sessionStateManger = _sessionStateManger;
            prescriptionRepository = _prescriptionRepository;
            medicineRepository = _medicineRepository;
            appointmentRepository = _appointmentRepository;
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
        //
        // GET: /DoctorDashboard/Prescription/
        public ActionResult Index()
        {
            return View();
        }
        // /DoctorDashboard/Prescription/PrescriptionList
        public ActionResult PrescriptionList(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            IEnumerable<PrescriptionPresnetViewModel> prescriptionList = prescriptionRepository.getPrescriptionList(patientID);

            if (prescriptionList == null)
                return HttpNotFound();

            ViewBag.patientID = patientID;

            return View(prescriptionList);
        }

        //
        // GET: /DoctorDashboard/Prescription/PrescriptionDetails/5
        public ActionResult PrescriptionDetails(int prescriptionID=0)
        {
            if (prescriptionID == 0)
                return HttpNotFound();
            PrescriptionPrintViewModel prescription = prescriptionRepository.getPrescriptionDetailsForPrint(prescriptionID);
            if (prescription == null)
                return HttpNotFound();
            prescription.AppointmentDate = DateTime.Now;
            return View(prescription);
        }

        //public ActionResult PrescriptionCreate(int patientID = 0)
        //{
        //    if (patientID == 0)
        //        patientID = getCurrentPatientID();

        //    var medList = medicineRepository.getMedicineList();
        //    var applist = appointmentRepository.getPatientAppountmentList(patientID);
        //    PrescriptionWrapViewModel prescriptionWrapViewModel = new PrescriptionWrapViewModel { appointmentList = applist, MedicineList = medList };

        //    return View(prescriptionWrapViewModel);
        //}

        //[HttpPost]
        //public ActionResult PrescriptionCreate(PrescriptionViewModel prescriptionViewModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid && prescriptionViewModel.MedicineID != 0 && prescriptionViewModel.AppointmentID != 0)
        //        {
        //            prescriptionViewModel.DoctorID = getDoctorIDbyUserID();
        //            prescriptionViewModel.PatientID = getCurrentPatientID();
        //            bool check = prescriptionRepository.addNewPrescription(prescriptionViewModel);
        //        }
        //        else
        //        {
        //            var medList = medicineRepository.getMedicineList();
        //            var applist = appointmentRepository.getPatientAppountmentList(getCurrentPatientID());
        //            PrescriptionWrapViewModel prescriptionWrapViewModel = new PrescriptionWrapViewModel { appointmentList = applist, MedicineList = medList };
        //            return View(prescriptionWrapViewModel);
        //        }

        //        return RedirectToAction("PrescriptionList", new { patientID = prescriptionViewModel.PatientID });
        //    }
        //    catch
        //    {
        //        ViewBag.patientID = prescriptionViewModel.PatientID;
        //        return View();
        //    }
        //}

        public ActionResult PrescriptionDelete(int prescriptionID)
        {
            PrescriptionPresnetViewModel prescriptionViewModel = prescriptionRepository.getPrescriptionDetails(prescriptionID);
            if (prescriptionViewModel == null)
                return HttpNotFound();
            return View(prescriptionViewModel);
        }

        [HttpPost]
        [ActionName("PrescriptionDelete")]
        public ActionResult ConfirmPrescriptionDelete(int prescriptionID=0)
        {
            try
            {
                if(prescriptionID==0)
                {
                    return HttpNotFound();
                }
               int patientID = getCurrentPatientID();

                bool check = prescriptionRepository.deletePrescription(prescriptionID);
                return RedirectToAction("PrescriptionList");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult PrescriptionAdd()
        {

            int patientID = getCurrentPatientID();
            int AppointmentID = appointmentRepository.getLastAppointmentIDByPatientID(patientID);
            string appointmentDate = appointmentRepository.getAppointmentDateByID(AppointmentID);

            ViewBag.PatientID = patientID;
            ViewBag.DoctorID = getDoctorIDbyUserID();
            ViewBag.AppointmentID = AppointmentID;
            ViewBag.appointmentDate = appointmentDate;

            IEnumerable<MedicineMiniViewModel> medList = medicineRepository.getMedicineList();
            return View(medList); ;
        }

        [HttpPost]
        public ActionResult SavePrescraptionMedcList(IEnumerable<MedicineMiniViewModel> medList)
        {
            try
            {
                int patientID = getCurrentPatientID();
                int AppointmentID = appointmentRepository.getLastAppointmentIDByPatientID(patientID);
                int doctorID = getDoctorIDbyUserID();


                medicineRepository.saveMedicineList(medList, AppointmentID, doctorID, patientID);

                return Json(new { RedirectUrl = Url.Action("PrescriptionList", "Prescription", new { area = "DoctorDashboard" }) });
            }
            catch
            {
                return null;
            }

        }
	}
}