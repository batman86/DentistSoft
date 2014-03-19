using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.BL.Abstract;
using DentistManager.DentistUI.Infrastructure;
using Microsoft.AspNet.Identity;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    public class PatientManagementController : Controller
    {
        IPatientRepository patientRepository;
        IAppointmentRepository appointmentRepository;
        IimagesRepository imageRepository;
        ISessionStateManger sessionStateManger;
        public PatientManagementController(IPatientRepository _patientRepository, IAppointmentRepository _appointmentRepository, IimagesRepository _imageRepository, ISessionStateManger _sessionStateManger)
        {
            patientRepository = _patientRepository;
            appointmentRepository = _appointmentRepository;
            imageRepository = _imageRepository;
            sessionStateManger = _sessionStateManger;
        }

        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getSecyrtaryActivePatinet(User.Identity.GetUserId()));
        }

        [NonAction]
        public int getUserCurrentClinecID()
        {
            return sessionStateManger.getClinecIDForCurrentSecurtary(User.Identity.GetUserId());
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /SecretaryDashboard/PatientManagement/patientList
        public ActionResult patientList()
        {
            // filter by clinec id
            IEnumerable<PatientMiniData> patientList = patientRepository.getPatientList(0, 10, getUserCurrentClinecID());
            if (patientList == null)
                return HttpNotFound();
            return View(patientList);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientDetails/5
        public ActionResult PatientDetails(int patientID=0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            Patient patient = patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return PartialView(patient);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientCreate
        public ActionResult PatientCreate()
        {
            return View();
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientCreate
        [HttpPost]
        public ActionResult PatientCreate(PatientFullDataViewModel patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    patient.ClinicID = getUserCurrentClinecID();
                   bool check= patientRepository.addNewPatinetBasicInfo(patient);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientEdit/5
        public ActionResult PatientEdit(int patientID= 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            Patient patient = patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientEdit/5
        [HttpPost]
        public ActionResult PatientEdit(Patient patient)
        {
            try
            {
               if(ModelState.IsValid)
               {
                  bool check = patientRepository.updatePatinetBasicInfo(patient);
               }
               else
               {
                   return View();
               }
               return RedirectToAction("patientList");
            }
            catch
            {
                return View();
               
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientDelete/5
        public ActionResult PatientDelete(int patientID=0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            Patient patient= patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientDelete/5
        [HttpPost]
        [ActionName("PatientDelete")]
        public ActionResult ConfirmPatientDelete(int patientID)
        {
            try
            {
                bool check = patientRepository.deletepatientBasicInfo(patientID);
                return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }


       

       

    }
}
