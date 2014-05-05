using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface IPaymentReceiptRerpository
    {
        decimal getPatientTotalReceiptPayment(int patientID, int clinecID);
        decimal getPatientTotalReceiptPayment(int patientID, int clinecID,DateTime from,DateTime to);

        bool addNewPatientReceipt(PaymentReceiptViewModel paymentRecieptViewModel);
        bool deletePatientReceipt(int ReceiptID);
        PaymentReceiptPresentViewModel getPaymentReceiptDetails(int ReceiptID);

        IEnumerable<PaymentReceiptPresentViewModel> getPatientReceiptList(int patientID, int clinecID);
    }
}
