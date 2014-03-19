using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.Entities;
namespace DentistManager.Domain.DAL.Concrete
{
   public  class PaymentRepository
    {
       public decimal GetAllCostTreatmentByClinic(int clinicID)
       {
           decimal total = 0;
           using(Entities.Entities ctx = new Entities.Entities())
           {
               total = ctx.Treatments.Where(t => t.ClinicID == clinicID).ToList().Select(c=>c.TeratmentCost).Sum();
          
           }

           return total;
 
       }
       public decimal GetAllPayedReceitsByClinic(int clinicID)
       {
           decimal total = 0;
           using (Entities.Entities ctx = new Entities.Entities())
           {
               total = ctx.PaymentReceipts.Where(t => t.ClinicID == clinicID).ToList().Select(p => p.Amount).Sum();

           }

           return total;

       }
       public decimal GetAllTeratmentByDoctor(int DoctorID,int ClinicID)
       {
           decimal total = 0;
           using (Entities.Entities ctx = new Entities.Entities())
           {
               total = ctx.Treatments.Where(t => t.ClinicID == ClinicID && t.DoctorID == DoctorID).ToList().Select(p => p.TeratmentCost).Sum();

           }

           return total;

       }
       public decimal GetAllPaymentReceitByDoctor(int DoctorID, int ClinicID)
       {
           decimal total = 0;
           //using (Entities.Entities ctx = new Entities.Entities())
           //{
           //    total = ctx.PaymentReceipts.Where(t => t.ClinicID == ClinicID && t.DoctorID == DoctorID).ToList().Select(p => p.TeratmentCost).Sum();

           //}

           return total;

       }
    }
}
