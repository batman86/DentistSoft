using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using DentistManager.DentistUI.Models;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.BL.Abstract;
using Microsoft.AspNet.Identity;

namespace DentistManager.DentistUI.Controllers
{
    public class CalendarController : Controller
    {
        IDoctorRepository doctorRepository;
        IAppointmentRepository  appointmentRepository;
        IPatientRepository patientRepository;
        ISessionStateManger sessionStateManger;
        public CalendarController(IDoctorRepository _doctorRepository, IAppointmentRepository _appointmentRepository,IPatientRepository _patientRepository, ISessionStateManger _sessionStateManger)
        {
            doctorRepository = _doctorRepository;
            appointmentRepository = _appointmentRepository;
            patientRepository = _patientRepository;
            sessionStateManger = _sessionStateManger;
        }


        public ActionResult Index()
        {
            var scheduler = new DHXScheduler();
            scheduler.DataAction = Url.Action("Data");
            scheduler.SaveAction = Url.Action("Save");

            var selectDoctor = new LightboxSelect("DoctorID", "Doctor");
            var items = new List<object>();
            IEnumerable<DoctorMiniInfoViewModel> doctorList= doctorRepository.getDoctorMiniInfoList();
            foreach (DoctorMiniInfoViewModel item in doctorList)
            {
                items.Add(new { key = item.DoctorID, label = item.DoctorName});
            }
            selectDoctor.AddOptions(items);



            var selectPatientStatus = new LightboxSelect("Status", "Status");
            var Statusitems = new List<object>();
            //Statusitems.Add(new { key = PatientSchduelStatus.canceled, label = PatientSchduelStatus.canceled });
            Statusitems.Add(new { key = PatientSchduelStatus.Finished, label = PatientSchduelStatus.Finished });
            Statusitems.Add(new { key = PatientSchduelStatus.Postponed, label = PatientSchduelStatus.Postponed });
            Statusitems.Add(new { key = PatientSchduelStatus.InProgress, label = PatientSchduelStatus.InProgress });
            Statusitems.Add(new { key = PatientSchduelStatus.waiting, label = PatientSchduelStatus.waiting });
            selectPatientStatus.AddOptions(Statusitems);



            var Reason = new LightboxText("reason", "Reason");
            var Define = new LightboxText("text", "Define");
            var date = new LightboxMiniCalendar("Date");

            scheduler.Lightbox.Add(Define);
            scheduler.Lightbox.Add(Reason);
            scheduler.Lightbox.Add(selectDoctor);
            scheduler.Lightbox.Add(selectPatientStatus);
            scheduler.Lightbox.Add(date);

            scheduler.Config.hour_size_px= 100;

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            return View(scheduler);
        }

        public ContentResult Data()
        {
            int clinecID = sessionStateManger.getClinecIDForCurrentSecurtary(User.Identity.GetUserId());
            List<AppointmentViewModelFull> eventList = appointmentRepository.getClinecAppointmentList(clinecID);

            return Content(new SchedulerAjaxData(eventList), "text/json");
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            
            try
            {
                AppointmentViewModelFull appointmentViewModel = (AppointmentViewModelFull)DHXEventsHelper.Bind(typeof(AppointmentViewModelFull), actionValues);

                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        int patientID=int.Parse(sessionStateManger.getSecyrtaryActivePatinet(User.Identity.GetUserId()));
                        appointmentViewModel.ClinicID = sessionStateManger.getClinecIDForCurrentSecurtary(User.Identity.GetUserId());
                        appointmentViewModel.PatientID = patientID;
                        appointmentViewModel.Status = appointmentViewModel.Status;
                        appointmentViewModel.text = "DR:" + doctorRepository.getDoctorNameByID(appointmentViewModel.DoctorID) + " Patient:" + patientRepository.getPatientNameByID(patientID);
                        action.TargetId = appointmentRepository.AddNewAppointment(appointmentViewModel);
                        break;
                    case DataActionTypes.Delete:
                        appointmentRepository.deleteAppointment(appointmentViewModel.id);
                        break;
                    default:  
                        appointmentRepository.alterAppointment(appointmentViewModel);
                        break;
                }
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }

            return Content(new AjaxSaveResponse(action), "text/xml");
        }
    }
}

