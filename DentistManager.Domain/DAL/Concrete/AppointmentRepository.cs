using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Concrete
{
    public class AppointmentRepository:IAppointmentRepository
    {
        public IEnumerable<AppointmentViewModel> getPatientAppountmentList(int patientID)
        {
            using(Entities.Entities ctx=new Entities.Entities ())
            {
                IEnumerable<AppointmentViewModel> appointmentViewModel;

                var appointmentsIQ = ctx.Appointments;

                appointmentViewModel = (from a in appointmentsIQ
                                        select new AppointmentViewModel {  AppointmentID=a.AppointmentID , Date=a.Date }).ToList();
                return appointmentViewModel;
            }
        }
    }
}
