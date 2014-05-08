using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.BL.Concrete
{
    public class PatientPaymentBL:IPatientPaymentBL
    {
        public PatientBillInfoWrap patientTotalCost(int patientID, int clinecID)
        {
            decimal? TotalCost = 0;

            decimal treatmentCost = 0;
            decimal? opperationCost = 0;
            decimal? materialCost = 0;
            decimal? customMatrialCost = 0;
            decimal? patientPayment = 0;
            decimal? remain = 0;

            CustomMatrialRepository customMatrialRepository = new CustomMatrialRepository();
            customMatrialCost = customMatrialRepository.getPatientCusmotMatrialCostTotal(patientID, clinecID);

            TreatmentRepository treatmentRepository = new TreatmentRepository();

            IEnumerable<Treatment> patientTreatmentList = treatmentRepository.getPatientTreatmentList(patientID, clinecID);

            foreach (Treatment treatment in patientTreatmentList)
            {
                treatmentCost += treatment.TeratmentCost;
                opperationCost += treatment.OpperationCost;

                IEnumerable<MaterialTreatment> matrialTreatmentList = treatment.MaterialTreatments;

                foreach (MaterialTreatment matrialTreatment in matrialTreatmentList)
                {
                    materialCost += matrialTreatment.MaterialCost * (int)matrialTreatment.Quantity;
                }
            }
            if (opperationCost == null)
                opperationCost = 0;

            if (materialCost == null)
                materialCost = 0;

            if (customMatrialCost == null)
                customMatrialCost = 0;

            TotalCost = treatmentCost + opperationCost + materialCost;// +customMatrialCost;

            patientPayment =patientTotalPayment(patientID, clinecID);

            if (patientPayment == null)
                patientPayment = 0;

            remain = TotalCost - patientPayment;

            PatientBillInfoWrap billInfo = new PatientBillInfoWrap { customMatrialCost = customMatrialCost, materialCost = materialCost, opperationCost = opperationCost, treatmentCost = treatmentCost, TotalCost = TotalCost, PatientPayment = patientPayment , Remain =remain};

            return billInfo;
        }


        public PatientBillInfoWrap patientTotalCost(int patientID, int clinecID,DateTime from,DateTime to)
        {
            decimal? TotalCost = 0;

            decimal treatmentCost = 0;
            decimal? opperationCost = 0;
            decimal? materialCost = 0;
            decimal? customMatrialCost = 0;
            decimal? patientPayment = 0;
            decimal? remain = 0;

            CustomMatrialRepository customMatrialRepository = new CustomMatrialRepository();
            customMatrialCost = customMatrialRepository.getPatientCusmotMatrialCostTotal(patientID, clinecID,from,to);

            TreatmentRepository treatmentRepository = new TreatmentRepository();
            IEnumerable<Treatment> patientTreatmentList = treatmentRepository.getPatientTreatmentList(patientID, clinecID,from,to);

            foreach (Treatment treatment in patientTreatmentList)
            {
                treatmentCost += treatment.TeratmentCost;
                opperationCost += treatment.OpperationCost;

                IEnumerable<MaterialTreatment> matrialTreatmentList = treatment.MaterialTreatments;

                foreach (MaterialTreatment matrialTreatment in matrialTreatmentList)
                {
                    materialCost += matrialTreatment.MaterialCost * (int)matrialTreatment.Quantity;
                }
            }

            if (opperationCost == null)
                opperationCost = 0;

            if (materialCost == null)
                materialCost = 0;

            if (customMatrialCost == null)
                customMatrialCost = 0;

            TotalCost = treatmentCost + opperationCost + materialCost;// +customMatrialCost;

            patientPayment = patientTotalPayment(patientID, clinecID,from,to);

            if (patientPayment == null)
                patientPayment = 0;

            remain = TotalCost - patientPayment;

            PatientBillInfoWrap billInfo = new PatientBillInfoWrap { customMatrialCost = customMatrialCost, materialCost = materialCost, opperationCost = opperationCost, treatmentCost = treatmentCost, TotalCost = TotalCost, PatientPayment = patientPayment, Remain = remain };

            return billInfo;
        }
        public decimal patientTotalPayment(int patientID, int clinecID)
        {
            PaymentReceiptRerpository patientRecipt = new PaymentReceiptRerpository();
            decimal totalPayment = patientRecipt.getPatientTotalReceiptPayment(patientID, clinecID);
            return totalPayment;
        }

        public decimal patientTotalPayment(int patientID, int clinecID,DateTime from,DateTime to)
        {
            PaymentReceiptRerpository patientRecipt = new PaymentReceiptRerpository();
            decimal totalPayment = patientRecipt.getPatientTotalReceiptPayment(patientID, clinecID,from,to);
            return totalPayment;
        }
      //  public void patientRemain(decimal patientTotalPayment,)


    }
}
