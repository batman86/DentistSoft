using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface IDoctorRepository
    {
        IEnumerable<DoctorMiniInfoViewModel> getDoctorMiniInfoList();
        string getDoctorNameByID(int doctorID);
        int getClinecIDByUserID(string UserID);
        int getDoctorIDByUserID(string UserID);
        int getDoctorIDByPatientID(int patientID);
    }
}
