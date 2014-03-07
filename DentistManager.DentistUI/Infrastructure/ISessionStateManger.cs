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
        int getClinecIDForCurrentSecurtary(string userID);
        int getClinecIDForCurrentDoctor(string userID);
        void setSecyrtaryActivePatinet(string userID, int patientID);
    }
}
