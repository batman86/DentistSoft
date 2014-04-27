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

        public decimal getPatientTotalReceiptPayment(int patientID,int clinecID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                decimal total = 0;
                int count = 0;
                count= ctx.PaymentReceipts.Where(x => x.PatientID == patientID && x.ClinicID == clinecID).Count();

                if(count>0)
                     total = ctx.PaymentReceipts.Where(x => x.PatientID == patientID && x.ClinicID == clinecID).Select(x => x.Amount).Sum();
                


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
                paymentRercieptEntity.Date = DateTime.Now;
                paymentRercieptEntity.PatientID = paymentRecieptViewModel.PatientID;
                paymentRercieptEntity.DoctorID = paymentRecieptViewModel.doctorID;

                ctx.PaymentReceipts.Add(paymentRercieptEntity);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool deletePatientReceipt(int ReceiptID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                PaymentReceipt recipt= ctx.PaymentReceipts.Find(ReceiptID);
                if (recipt == null)
                    return false;
                ctx.PaymentReceipts.Remove(recipt);
                count = ctx.SaveChanges();

            }
            return count > 0 ? true : false;
        }

        public PaymentReceiptPresentViewModel getPaymentReceiptDetails(int ReceiptID)
        {

            PaymentReceiptPresentViewModel reciptpresentViewModel;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                PaymentReceipt recipt = ctx.PaymentReceipts.Find(ReceiptID);

                if (recipt == null)
                    return null;
                 reciptpresentViewModel = new PaymentReceiptPresentViewModel();

                reciptpresentViewModel.receiptID = recipt.ReceiptID;
                reciptpresentViewModel.receiptAmount = recipt.Amount;
                reciptpresentViewModel.ReviceDate = recipt.Date;
                reciptpresentViewModel.reciverName = ctx.Secretaries.Where(x => x.UserID == recipt.UserID) .FirstOrDefault().Name;
            }
            return reciptpresentViewModel;
        }

        public IEnumerable<PaymentReceiptPresentViewModel> getPatientReceiptList(int patientID, int clinecID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                // in where change payment ID to patient id
                var paymentReciptIQ=ctx.PaymentReceipts;
                var secertaryIQ= ctx.Secretaries;
                IEnumerable<PaymentReceiptPresentViewModel> reciptpresentViewModel = (from p in paymentReciptIQ
                                                                         join s in secertaryIQ on p.UserID equals s.UserID
                                                                         where p.PatientID == patientID && p.ClinicID == clinecID
                                                                         select new PaymentReceiptPresentViewModel { receiptID =p.ReceiptID, receiptAmount = p.Amount, ReviceDate = p.Date, reciverName = s.Name }).ToList();
                return reciptpresentViewModel;
            }
        }
    }
}
