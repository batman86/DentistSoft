using DentistManager.Domain.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.DAL.Concrete
{
    public class PaymentReceiptRerpository : IPaymentReceiptRerpository
    {

        public decimal getPatientTotalReceiptPayment(int patientPaymentID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                decimal total = 0;

                total = ctx.PaymentReceipts.Where(x => x.PatientPaymentID == patientPaymentID).Select(x => x.Amount).Sum();
                return total;
            }
        }


        public bool addNewPatientReceipt(PaymentReceiptViewModel paymentRecieptViewModel)
        {
            int count = 0;

            using (Entities.Entities ctx = new Entities.Entities())
            {
                PaymentReceipt paymentRercieptEntity = ctx.PaymentReceipts.Create();

                paymentRercieptEntity.UserID = paymentRecieptViewModel.UserID;
                paymentRercieptEntity.ClinicID = paymentRecieptViewModel.ClinicID;
                paymentRercieptEntity.Amount = paymentRecieptViewModel.Amount;

                ctx.PaymentReceipts.Add(paymentRercieptEntity);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool alterPatientReceipt(PaymentReceiptViewModel paymentRecieptViewModel)
        {
            throw new NotImplementedException();
        }

        public bool deletePatientReceipt(int ReceiptID)
        {
            throw new NotImplementedException();
        }

        public PaymentReceiptViewModel getPaymentReceiptDetails(int ReceiptID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentReceiptViewModel> getPatientReceiptList(int patientID)
        {
            throw new NotImplementedException();
        }
    }
}
