using DentistManager.Domain.ViewModel;
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
        PatientBillInfoWrap patientTotalCost(int patientID, int clinecID);

       
        // what patient did pay
        decimal patientTotalPayment(int patientID, int clinecID);

    }
}
