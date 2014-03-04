using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;

namespace DentistManager.Domain.DAL.Concrete
{
    class PatientPaymentRepository : IPatientPaymentRepository
    {
        public int getPatientPaymentID(int patientID)
        {
           int patientPaymentID=0;
           using(Entities.Entities ctx=new Entities.Entities ())
           {
               //patientPaymentID = ctx.PatientPayments.Where(x => x.PatientID == patientID).Select(x => x.PatientPaymentID).FirstOrDefault();
           }
           return patientPaymentID;
        }
    }
}
