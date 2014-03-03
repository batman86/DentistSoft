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
        decimal getPatientTotalReceiptPayment(int patientPaymentID);

        bool addNewPatientReceipt(PaymentReceiptViewModel paymentRecieptViewModel);
        bool alterPatientReceipt(PaymentReceiptViewModel paymentRecieptViewModel);
        bool deletePatientReceipt(int ReceiptID);
        PaymentReceiptViewModel getPaymentReceiptDetails(int ReceiptID);
        IEnumerable<PaymentReceiptViewModel> getPatientReceiptList(int patientID);
    }
}
