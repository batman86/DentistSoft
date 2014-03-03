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

                // add all proberity after alter the database
                appointmentViewModelFull =  (from a in appointmentsIQ
                                             where a.ClinicID == ClinecID
                                             select new AppointmentViewModelFull { id= a.AppointmentID ,ClinicID= a.ClinicID, DoctorID=a.DoctorID, PatientID=a.PatientID, Reason=a.Reason , Status= a.Status  }).ToList();
                return appointmentViewModelFull;
            }
        }


        public bool AddNewAppointment(AppointmentViewModelFull appointment)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                
                Appointment appointmentEntity = ctx.Appointments.Create();
                appointmentEntity.ClinicID = appointment.ClinicID;
                appointmentEntity.DoctorID = appointment.DoctorID;
                appointmentEntity.PatientID = appointment.PatientID;
                appointmentEntity.Reason = appointment.Reason;
                appointmentEntity.Status = appointment.Status;
                //add text and start date  and end date

                ctx.Appointments.Add(appointmentEntity);
                count =ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }


        public bool alterAppointment(AppointmentViewModelFull appointment)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                ctx.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
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
