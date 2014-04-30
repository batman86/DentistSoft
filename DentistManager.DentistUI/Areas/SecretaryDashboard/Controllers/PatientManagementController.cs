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
using System.Net;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class PatientManagementController : Controller
    {
        IPatientRepository patientRepository;
        IAppointmentRepository appointmentRepository;
        IimagesRepository imageRepository;
        ISessionStateManger sessionStateManger;
        IDoctorRepository doctorRepository;
        public PatientManagementController(IPatientRepository _patientRepository, IAppointmentRepository _appointmentRepository, IimagesRepository _imageRepository, ISessionStateManger _sessionStateManger, IDoctorRepository _doctorRepository)
        {
            patientRepository = _patientRepository;
            appointmentRepository = _appointmentRepository;
            imageRepository = _imageRepository;
            sessionStateManger = _sessionStateManger;
            doctorRepository = _doctorRepository;
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
        public ActionResult patientList(int pageNumber = 0)
        {
            int pageSize = 10;
            int clinecID = getUserCurrentClinecID();
            int itemTotal = patientRepository.getPatientTotal(clinecID);

            patientListViewModelWrap patientlidstWrap = new patientListViewModelWrap();
            patientlidstWrap.pagingInfoHolder = new PagingInfoHolder { ItemTotal = itemTotal, pageNumber = pageNumber, pageSize = pageSize };
            patientlidstWrap.patientList = patientRepository.getPatientList(pageNumber, pageSize, clinecID);

            if (patientlidstWrap.patientList == null)
                return HttpNotFound();

            return View(patientlidstWrap);
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
            return View(patient);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientCreate
        public ActionResult PatientCreate()
        {
            PatientCreateWrap patientCreateWrap = new PatientCreateWrap();
            patientCreateWrap.DoctorsList= doctorRepository.getDoctorMiniInfoList();

            return View(patientCreateWrap);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientCreate
        [HttpPost]
        public ActionResult PatientCreate(PatientFullDataViewModel PatientInfo)
        {
            try
            {
                PatientInfo.ClinicID = getUserCurrentClinecID();
                if (!ModelState.IsValid)
                {
                    PatientCreateWrap patientCreateWrap = new PatientCreateWrap();
                    patientCreateWrap.DoctorsList = doctorRepository.getDoctorMiniInfoList();
                    return View(patientCreateWrap);
                }

                bool check = patientRepository.addNewPatinetBasicInfo(PatientInfo);

                //return RedirectToAction("SecyrtaryPatientActvator","PatientSearch",new{PatientID=})
                return RedirectToAction("patientList");
            }
            catch
            {
                PatientCreateWrap patientCreateWrap = new PatientCreateWrap();
                patientCreateWrap.DoctorsList = doctorRepository.getDoctorMiniInfoList();
                return View(patientCreateWrap);
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
