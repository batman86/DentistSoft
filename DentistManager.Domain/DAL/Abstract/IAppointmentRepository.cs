using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface IAppointmentRepository
    {
        IEnumerable<AppointmentViewModel> getPatientAppountmentList(int patientID);   
    }
}
