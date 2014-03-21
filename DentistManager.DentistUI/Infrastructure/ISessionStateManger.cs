using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.DentistUI.Infrastructure
{
    public interface ISessionStateManger
    {
        string getSecyrtaryActivePatinet(string userID);
        void setSecyrtaryActivePatinet(string userID, int patientID);
        string getDoctorActivePatinet(string userID);
        void setDoctorActivePatinet(string userID, int patientID);
        int getClinecIDForCurrentSecurtary(string userID);
        int getClinecIDForCurrentDoctor(string userID);
        string getDoctorCustomMatrailFilter(string userID);
        void setDoctorCustomMatrailFilter(string userID, string FilterType);

    }
}
