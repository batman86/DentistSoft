using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.Domain.ViewModel;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class PatientStatusController : Controller
    {
        IDoctorRepository doctorRepository;
        ISessionStateManger sessionStateManger;
        IAppointmentRepository appointmentRepository;
        public PatientStatusController(IDoctorRepository _doctorRepository, ISessionStateManger _sessionStateManger, IAppointmentRepository _appointmentRepository)
        {
            doctorRepository = _doctorRepository;
            sessionStateManger = _sessionStateManger;
            appointmentRepository = _appointmentRepository;
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

            AppointmentStatusViewModelWrap viewModel = new AppointmentStatusViewModelWrap();
            viewModel.AppointmentStatusViewModelList = appointmentRepository.getClinecMeeting(clinecID,PatientSchduelStatus.waiting.ToString(), DateTime.Now, DateTime.Now);
            viewModel.statusFilter = PatientSchduelStatus.waiting.ToString();
            viewModel.timeFilter = SchduelStatusTimeFilter.Daily.ToString();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PatientStatusList(string timeFilter, string statusFilter)
        {
            int clinecID = getUserCurrentClinecID();
           
            IEnumerable<AppointmentStatusViewModel> appList;

            if (timeFilter == SchduelStatusTimeFilter.Monthly.ToString())
            {
                if (statusFilter == "All")
                    appList = appointmentRepository.getClinecMeeting(clinecID,DateTime.Now,DateTime.Now.AddMonths(1));
                else
                    appList = appointmentRepository.getClinecMeeting(clinecID,statusFilter, DateTime.Now, DateTime.Now.AddMonths(1));
            }
            else if (timeFilter == SchduelStatusTimeFilter.Weekly.ToString())
            {
                if (statusFilter == "All")
                    appList = appointmentRepository.getClinecMeeting(clinecID, DateTime.Now, DateTime.Now.AddDays(7));
                else
                    appList = appointmentRepository.getClinecMeeting(clinecID, statusFilter, DateTime.Now, DateTime.Now.AddDays(7));
            }
            else
            {
                DateTime date = DateTime.Now;
                DateTime from = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
                DateTime to = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);

                if (statusFilter == "All")
                    appList = appointmentRepository.getClinecMeeting(clinecID, from, to);
                else
                    appList = appointmentRepository.getClinecMeeting(clinecID, statusFilter, from, to);
            }

            AppointmentStatusViewModelWrap viewModel = new AppointmentStatusViewModelWrap();
            viewModel.AppointmentStatusViewModelList = appList;
            viewModel.statusFilter = statusFilter;
            viewModel.timeFilter = timeFilter;

            return View(viewModel);
        }
        public ActionResult PatientStatusEdit(int AppointmentID = 0)
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