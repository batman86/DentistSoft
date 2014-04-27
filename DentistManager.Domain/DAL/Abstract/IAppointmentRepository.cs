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

        List<AppointmentStatusViewModel> getDoctorDailyMeeting(int ClinecID, int DoctorID);
        List<AppointmentStatusViewModel> getDoctorDailyMeeting(int ClinecID, int DoctorID,string status);

        List<AppointmentStatusViewModel> getDoctorWeeklyMeeting(int ClinecID, int DoctorID);
        List<AppointmentStatusViewModel> getDoctorWeeklyMeeting(int ClinecID, int DoctorID,string status);

        List<AppointmentStatusViewModel> getDoctorMonthlyMeeting(int ClinecID, int DoctorID);
        List<AppointmentStatusViewModel> getDoctorMonthlyMeeting(int ClinecID, int DoctorID,string status);


        List<AppointmentStatusViewModel> getClinecMeeting(int ClinecID,DateTime begin,DateTime ending);
        List<AppointmentStatusViewModel> getClinecMeeting(int ClinecID, string status, DateTime begin, DateTime ending);

        AppointmentStatusViewModel getPatientStatus(int appointmentID);
        bool updatePatientStatus(AppointmentStatusViewModel appointmentStatusViewModel);
    }
}
