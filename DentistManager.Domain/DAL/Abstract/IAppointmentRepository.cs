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
        List<AppointmentViewModelFull> getClinecAppointmentList(int ClinecID);
        int AddNewAppointment(AppointmentViewModelFull appointment);
        bool alterAppointment(AppointmentViewModelFull appointment);
        bool deleteAppointment(int appointmentID);

        string getAppointmentDateByID(int appointmentID);
        int getLastAppointmentIDByPatientID(int patientID);
    }
}
