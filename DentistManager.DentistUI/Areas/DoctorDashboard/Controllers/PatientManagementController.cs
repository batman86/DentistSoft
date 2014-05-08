using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.DentistUI.Infrastructure;

namespace DentistManager.DentistUI.Areas.DoctorDashboard.Controllers
{
    //[Authorize(Roles = "Doctor")]
    public class PatientManagementController : Controller
    {
        //
        // GET: /DoctorDashboard/PatientManagement/
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
        // GET: /DoctorDashboard/PatientManagement/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /DoctorDashboard/PatientManagement/patientList
        public ActionResult patientList(int pageNumber = 0)
        {
            int pageSize = 10;
            int clinecID= getUserCurrentClinecID();
            int doctorID= getDoctorIDbyUserID();
            int itemTotal = patientRepository.getPatientTotalForDoctor(clinecID, doctorID);

            
            //areaName = "DoctorDashboard", controllerName = "PatientManagement", ActionName = "patientList",
            patientListViewModelWrap patientlidstWrap = new patientListViewModelWrap();
            patientlidstWrap.pagingInfoHolder = new PagingInfoHolder {  ItemTotal = itemTotal, pageNumber = pageNumber, pageSize = pageSize };
            patientlidstWrap.patientList = patientRepository.getPatientListForDoctor(pageNumber, pageSize, clinecID, doctorID);

            //if (patientList == null)
            //    return HttpNotFound();

            return View(patientlidstWrap);
        }

        //
        // GET: /DoctorDashboard/PatientManagement/PatientDetails/5
        public ActionResult PatientDetails(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            Patient patient = patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }


        public ActionResult PatientCreate()
        {
            PatientCreateWrap patientCreateWrap = new PatientCreateWrap();
            patientCreateWrap.DoctorsList = doctorRepository.getDoctorMiniInfoList();

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
                return RedirectToAction("patientList");
                }
            catch
            {
                PatientCreateWrap patientCreateWrap = new PatientCreateWrap();
                patientCreateWrap.DoctorsList = doctorRepository.getDoctorMiniInfoList();
                return View(patientCreateWrap);
            }
        }
	}
}