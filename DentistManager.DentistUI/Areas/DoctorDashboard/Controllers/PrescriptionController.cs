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
    public class PrescriptionController : Controller
    {
        //
        // GET: /DoctorDashboard/Prescription/
        IPrescriptionRepository prescriptionRepository;
        ISessionStateManger sessionStateManger;
        IMedicineRepository medicineRepository;
        IAppointmentRepository appointmentRepository;
        public PrescriptionController(IPrescriptionRepository _prescriptionRepository, ISessionStateManger _sessionStateManger, IMedicineRepository _medicineRepository, IAppointmentRepository _appointmentRepository)
        {
            sessionStateManger = _sessionStateManger;
            prescriptionRepository = _prescriptionRepository;
            medicineRepository = _medicineRepository;
            appointmentRepository = _appointmentRepository;
        }

        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getDoctorActivePatinet(User.Identity.GetUserId()));
        }

        //
        // GET: /DoctorDashboard/Prescription/
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult PrescriptionDetails(int prescriptionID)
        {
            PrescriptionPresnetViewModel prescription = prescriptionRepository.getPrescriptionDetails(prescriptionID);
            if (prescription == null)
                return HttpNotFound();
            return PartialView(prescription);
        }

        public ActionResult PrescriptionCreate(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            var medList = medicineRepository.getMedicineList();
            var applist = appointmentRepository.getPatientAppountmentList(patientID);
            PrescriptionWrapViewModel prescriptionWrapViewModel = new PrescriptionWrapViewModel { appointmentList = applist, MedicineList = medList };



            ViewBag.patientID = patientID;
            return View(prescriptionWrapViewModel);
        }

        [HttpPost]
        public ActionResult PrescriptionCreate(PrescriptionViewModel prescriptionViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = prescriptionRepository.addNewPrescription(prescriptionViewModel);
                }
                else
                {
                    ViewBag.patientID = prescriptionViewModel.PatientID;
                    return View();
                }

                return RedirectToAction("PrescriptionList", new { patientID = prescriptionViewModel.PatientID });
            }
            catch
            {
                ViewBag.patientID = prescriptionViewModel.PatientID;
                return View();
            }
        }

        public ActionResult PrescriptionDelete(int prescriptionID)
        {
            PrescriptionPresnetViewModel prescriptionViewModel = prescriptionRepository.getPrescriptionDetails(prescriptionID);
            if (prescriptionViewModel == null)
                return HttpNotFound();
            return View(prescriptionViewModel);
        }

        [HttpPost]
        [ActionName("PrescriptionDelete")]
        public ActionResult ConfirmPrescriptionDelete(int prescriptionID)
        {
            try
            {
                    int patientID = getCurrentPatientID();

                bool check = prescriptionRepository.deletePrescription(prescriptionID); 
                return RedirectToAction("patientHistoryList", new { patientID = patientID });
            }
            catch
            {
                return View();
            }
        }


        ////
        //// GET: /DoctorDashboard/PatientManagement/PatientHistoryEdit/5
        //public ActionResult PrescriptionEdit(int prescriptionID)
        //{
        //    prescriptionRepository.getPrescriptionDetails(prescriptionID);
        //    PatientHistoryViewModel patientHistory = patientRepository.getPatinetHistoryDetails(prescriptionID);
        //    if (patientHistory == null)
        //        return HttpNotFound();
        //    return View(patientHistory);
        //}

        ////
        //// POST: /DoctorDashboard/PatientManagement/PatientHistoryEdit/5
        //[HttpPost]
        //public ActionResult PrescriptionEdit(PatientHistoryViewModel patientHistory)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            bool check = patientRepository.updatePatinetHistory(patientHistory);
        //        }
        //        else
        //        {
        //            return View(patientHistory);
        //        }
        //        return RedirectToAction("patientHistoryList", new { patientID = patientHistory.PatientID });
        //    }
        //    catch
        //    {
        //        return View(patientHistory);
        //    }
        //}

	}
}