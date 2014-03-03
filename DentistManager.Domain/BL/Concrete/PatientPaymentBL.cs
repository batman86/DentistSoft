﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.BL.Concrete
{
    public class PatientPaymentBL:IPatientPaymentBL
    {
        public void patientTotalCost(int patientID)
        {
            decimal TotalCost=0;

            decimal treatmentCost=0;
            decimal opperationCost = 0;
            decimal materialCost = 0;
            decimal? customMatrialCost = 0;

            CustomMatrialRepository customMatrialRepository = new CustomMatrialRepository();
            customMatrialCost = customMatrialRepository.getPatientCusmotMatrialCostTotal(patientID);
           
           

            TreatmentRepository treatmentRepository = new TreatmentRepository();

            IEnumerable<Treatment> patientTreatmentList= treatmentRepository.getPatientTreatmentList(patientID);

            foreach (Treatment treatment in patientTreatmentList)
            {
                treatmentCost += treatment.TeratmentCost;
                opperationCost += treatment.opperation.Price;

                IEnumerable<MaterialTreatment> matrialTreatmentList = treatment.MaterialTreatments;

                foreach (MaterialTreatment matrialTreatment in matrialTreatmentList)
                {
                   materialCost += matrialTreatment.Material.MaterialCost;
                }
            }
            //TotalCost=treatmentCost+opperationCost+materialCost+customMatrialCost;

        }

        public void patientTotalPayment(int patientID)
        {
            PatientPaymentRepository patientPaymentRepository = new PatientPaymentRepository();
            int patientPaymentID=  patientPaymentRepository.getPatientPaymentID(patientID);

            PaymentReceiptRerpository paymentReceiptRepository = new PaymentReceiptRerpository();
            decimal patientTotalPayment= paymentReceiptRepository.getPatientTotalReceiptPayment(patientPaymentID);

        }

      //  public void patientRemain(decimal patientTotalPayment,)
    }
}
