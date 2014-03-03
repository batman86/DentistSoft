using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.DAL.Concrete
{
    public class TreatmentRepository :ITreatmentRepository
    {


        public IEnumerable<Treatment> getPatientTreatmentList(int patientID)
        {
            using(Entities.Entities ctx=new Entities.Entities ())
            {
                IEnumerable<Treatment> treatmentList = ctx.Treatments.Where(x => x.PatientID == patientID).ToList();
                return treatmentList;
            }
        }
    }
}
