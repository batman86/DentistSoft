using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.BL.Abstract
{
    public interface IPatientPaymentBL
    {
        // what patient should pay
        void patientTotalCost(int patientID);
        // what patient did pay
        void patientTotalPayment(int patientID);

    }
}
