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
    public class PatientManagementController : Controller
    {
        //
        // GET: /DoctorDashboard/PatientManagement/
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
            var aa = User.Identity.GetUserId();
            return int.Parse(sessionStateManger.getDoctorActivePatinet(User.Identity.GetUserId()));
        }

        [NonAction]
        public int getUserCurrentClinecID()
        {
            var aa = sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
            return sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
        }

        //
        // GET: /DoctorDashboard/PatientManagement/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /DoctorDashboard/PatientManagement/patientList
        public ActionResult patientList()
        {
            // filter by clinec id
            IEnumerable<PatientMiniData> patientList = patientRepository.getPatientList(0, 10, getUserCurrentClinecID());
            if (patientList == null)
                return HttpNotFound();
            return View(patientList);
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
	}
}