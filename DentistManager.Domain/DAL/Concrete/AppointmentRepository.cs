using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.DAL.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        // this is a mini list i use it in drop down list
        public IEnumerable<AppointmentViewModel> getPatientAppountmentList(int patientID)
        {
            using(Entities.Entities ctx=new Entities.Entities ())
            {
                IEnumerable<AppointmentViewModel> appointmentViewModel;

                var appointmentsIQ = ctx.Appointments;

                appointmentViewModel = (from a in appointmentsIQ
                                        select new AppointmentViewModel {  AppointmentID=a.AppointmentID , Date=a.Start_date }).ToList();
                return appointmentViewModel;
            }
        }

        public List<AppointmentViewModelFull> getClinecAppointmentList(int ClinecID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                List<AppointmentViewModelFull> appointmentViewModelFull;

                var appointmentsIQ = ctx.Appointments;

                appointmentViewModelFull =  (from a in appointmentsIQ
                                             where a.ClinicID == ClinecID
                                             select new AppointmentViewModelFull { id= a.AppointmentID ,ClinicID= a.ClinicID, DoctorID=a.DoctorID, PatientID=a.PatientID, Reason=a.Reason , Status= a.Status, start_date=a.Start_date, end_date=a.End_date, text=a.Text  }).ToList();
                return appointmentViewModelFull;
            }
        }


        public int AddNewAppointment(AppointmentViewModelFull appointment)
        {
            int appointmentID = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                
                Appointment appointmentEntity = ctx.Appointments.Create();
                appointmentEntity.ClinicID = appointment.ClinicID;
                appointmentEntity.DoctorID = appointment.DoctorID;
                appointmentEntity.PatientID = appointment.PatientID;
                appointmentEntity.Reason = appointment.Reason;
                appointmentEntity.Status = appointment.Status;
                appointmentEntity.Start_date = appointment.start_date;
                appointmentEntity.End_date = appointment.end_date;
                appointmentEntity.Text = appointment.text;

                ctx.Appointments.Add(appointmentEntity);
                ctx.SaveChanges();
                appointmentID = appointmentEntity.AppointmentID;
            }
            return appointmentID;
        }


        public bool alterAppointment(AppointmentViewModelFull appointment)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Appointment appointmentEntity = ctx.Appointments.Find(appointment.id);

                if (appointmentEntity == null)
                    return false;

                appointmentEntity.ClinicID = appointment.ClinicID;
                appointmentEntity.DoctorID = appointment.DoctorID;
                appointmentEntity.PatientID = appointment.PatientID;
                appointmentEntity.Reason = appointment.Reason;
                appointmentEntity.Status = appointment.Status;
                appointmentEntity.Start_date = appointment.start_date;
                appointmentEntity.End_date = appointment.end_date;
                appointmentEntity.Text = appointment.text;

                ctx.Entry(appointmentEntity).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool deleteAppointment(int appointmentID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Appointment appointment = ctx.Appointments.Find(appointmentID);
                if (appointment != null)
                {
                    ctx.Appointments.Remove(appointment);
                    count = ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false;
        }
    }
}
