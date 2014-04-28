using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.ViewModel;

namespace DentistManager.DentistUI.Areas.DoctorDashboard.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class PatientStatusController : Controller
    {
        IDoctorRepository doctorRepository;
        ISessionStateManger sessionStateManger;
        IAppointmentRepository appointmentRepository;
        public PatientStatusController(IDoctorRepository _doctorRepository, ISessionStateManger _sessionStateManger, IAppointmentRepository _appointmentRepository)
        {
            doctorRepository = _doctorRepository;
            sessionStateManger=_sessionStateManger;
            appointmentRepository = _appointmentRepository;
        }


        [NonAction]
        public int getDoctorIDbyUserID()
        {
            return doctorRepository.getDoctorIDByUserID(User.Identity.GetUserId());
        }
        [NonAction]
        public int getUserCurrentClinecID()
        {
            var aa = sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
            return sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
        }

        //
        // GET: /DoctorDashboard/PatientStatus/
        public ActionResult Index()
        {
            return View();
        }


        // day list        // week list // month list
        // /DoctorDashboard/PatientStatus/PatientStatusList
        public ActionResult PatientStatusList()
        {
            int clinecID = getUserCurrentClinecID();
            int doctorID= getDoctorIDbyUserID();

            AppointmentStatusViewModelWrap viewModel = new AppointmentStatusViewModelWrap();
            viewModel.AppointmentStatusViewModelList = appointmentRepository.getDoctorDailyMeeting(clinecID, doctorID, PatientSchduelStatus.waiting.ToString());
            viewModel.statusFilter = PatientSchduelStatus.waiting.ToString();
            viewModel.timeFilter = SchduelStatusTimeFilter.Daily.ToString();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PatientStatusList(string timeFilter, string statusFilter)
        {
            int clinecID = getUserCurrentClinecID();
            int doctorID = getDoctorIDbyUserID();
            IEnumerable<AppointmentStatusViewModel> appList;

            if (timeFilter == SchduelStatusTimeFilter.Monthly.ToString())
            {
                if(statusFilter == "All")
                     appList = appointmentRepository.getDoctorMonthlyMeeting(clinecID, doctorID);
                else
                    appList = appointmentRepository.getDoctorMonthlyMeeting(clinecID, doctorID,statusFilter);
            }
            else if (timeFilter == SchduelStatusTimeFilter.Weekly.ToString())
            {
                if (statusFilter == "All")
                    appList = appointmentRepository.getDoctorWeeklyMeeting(clinecID, doctorID);
                else
                    appList = appointmentRepository.getDoctorWeeklyMeeting(clinecID, doctorID, statusFilter);
            }
            else
            {
                if (statusFilter == "All")
                    appList = appointmentRepository.getDoctorDailyMeeting(clinecID, doctorID);
                else
                    appList = appointmentRepository.getDoctorDailyMeeting(clinecID, doctorID, statusFilter);
            }

            AppointmentStatusViewModelWrap viewModel = new AppointmentStatusViewModelWrap();
            viewModel.AppointmentStatusViewModelList = appList;
            viewModel.statusFilter = statusFilter;
            viewModel.timeFilter = timeFilter;

            return View(viewModel);
        }

        public ActionResult PatientStatusEdit(int AppointmentID=0)
        {
            AppointmentStatusViewModel vm = appointmentRepository.getPatientStatus(AppointmentID);
            return View(vm);
        }

        [HttpPost]
        public ActionResult PatientStatusEdit(AppointmentStatusViewModel appointmentStatusViewModel)
        {
            if (!ModelState.IsValid)
            {
                AppointmentStatusViewModel vm = appointmentRepository.getPatientStatus(appointmentStatusViewModel.id);
                return View(vm);
            }
            appointmentRepository.updatePatientStatus(appointmentStatusViewModel);
            return RedirectToAction("PatientStatusList");
        }
	}
}