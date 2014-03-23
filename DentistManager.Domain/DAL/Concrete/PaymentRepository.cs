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
       public decimal? GetAllCostTreatmentByClinic(int clinicID)
       {
           decimal? TotalCost = 0;

           decimal treatmentCost = 0;
           decimal? opperationCost = 0;
           decimal? materialCost = 0;
           decimal? customMatrialCost = 0;

           using (Entities.Entities ctx = new Entities.Entities())
           {
               customMatrialCost = ctx.CustomMaterials.Where(c => c.ClinicID == clinicID).ToList().Select(c => c.Cost).Sum();
               IEnumerable<Treatment> patientTreatmentList = ctx.Treatments.Where(t => t.ClinicID == clinicID).ToList();
               treatmentCost = patientTreatmentList.Select(t => t.TeratmentCost).Sum();
               opperationCost = patientTreatmentList.Select(t=>t.OpperationCost).Sum();
               foreach (Treatment treatment in patientTreatmentList)
               {
                   IEnumerable<MaterialTreatment> matrialTreatmentList = treatment.MaterialTreatments;

                   foreach (MaterialTreatment matrialTreatment in matrialTreatmentList)
                   {
                       materialCost += matrialTreatment.MaterialCost * (int)matrialTreatment.Quantity;
                   }
               }
               TotalCost = treatmentCost + opperationCost + materialCost + customMatrialCost;
           }

           return TotalCost;
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
       public decimal? GetAllTeratmentByDoctor(int DoctorID,int ClinicID)
       {
           decimal? TotalCost = 0;

           decimal treatmentCost = 0;
           decimal? opperationCost = 0;
           decimal? materialCost = 0;
           decimal? customMatrialCost = 0;

           using (Entities.Entities ctx = new Entities.Entities())
           {
               customMatrialCost = ctx.CustomMaterials.Where(c => c.ClinicID == ClinicID && c.DoctorID == DoctorID).ToList().Select(c => c.Cost).Sum();
               IEnumerable<Treatment> patientTreatmentList = ctx.Treatments.Where(t => t.ClinicID == ClinicID && t.DoctorID == DoctorID).ToList();
               treatmentCost = patientTreatmentList.Select(t => t.TeratmentCost).Sum();
               opperationCost = patientTreatmentList.Select(t => t.OpperationCost).Sum();
               foreach (Treatment treatment in patientTreatmentList)
               {
                   IEnumerable<MaterialTreatment> matrialTreatmentList = treatment.MaterialTreatments;

                   foreach (MaterialTreatment matrialTreatment in matrialTreatmentList)
                   {
                       materialCost += matrialTreatment.MaterialCost * (int)matrialTreatment.Quantity;
                   }
               }
               TotalCost = treatmentCost + opperationCost + materialCost + customMatrialCost;
           }

           return TotalCost;

       }
       public decimal GetAllPaymentReceitByDoctor(int DoctorID, int ClinicID)
       {
           decimal total = 0;

           using (Entities.Entities ctx = new Entities.Entities())
           {
               total = ctx.PaymentReceipts.Where(t => t.ClinicID == ClinicID &&  t.DoctorID== DoctorID).ToList().Select(p => p.Amount).Sum();

           }

           return total;

       }
       public decimal? GetAllTeratmentByPatient(int DoctorID, int ClinicID,int PatientID)
       {
           decimal? TotalCost = 0;

           decimal treatmentCost = 0;
           decimal? opperationCost = 0;
           decimal? materialCost = 0;
           decimal? customMatrialCost = 0;

           using (Entities.Entities ctx = new Entities.Entities())
           {
               customMatrialCost = ctx.CustomMaterials.Where(c => c.ClinicID == ClinicID && c.DoctorID == DoctorID && c.PatientID == PatientID).ToList().Select(c => c.Cost).Sum();
               IEnumerable<Treatment> patientTreatmentList = ctx.Treatments.Where(t => t.ClinicID == ClinicID && t.DoctorID == DoctorID && t.PatientID==PatientID).ToList();
               treatmentCost = patientTreatmentList.Select(t => t.TeratmentCost).Sum();
               opperationCost = patientTreatmentList.Select(t => t.OpperationCost).Sum();
               foreach (Treatment treatment in patientTreatmentList)
               {
                   IEnumerable<MaterialTreatment> matrialTreatmentList = treatment.MaterialTreatments;

                   foreach (MaterialTreatment matrialTreatment in matrialTreatmentList)
                   {
                       materialCost += matrialTreatment.MaterialCost * (int)matrialTreatment.Quantity;
                   }
               }
               TotalCost = treatmentCost + opperationCost + materialCost + customMatrialCost;
           }

           return TotalCost;

       }
       public decimal GetAllPaymentReceitByPatient(int DoctorID, int ClinicID,int PatientID)
       {
           decimal total = 0;
           using (Entities.Entities ctx = new Entities.Entities())
           {
               total = ctx.PaymentReceipts.Where(t => t.ClinicID == ClinicID && t.DoctorID == DoctorID && t.PatientID == PatientID).ToList().Select(p => p.Amount).Sum();
           }
           return total;

       }
    }
}
