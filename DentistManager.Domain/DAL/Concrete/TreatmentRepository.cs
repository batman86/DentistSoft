using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Concrete
{
    public class TreatmentRepository :ITreatmentRepository
    {

        public IEnumerable<Treatment> getPatientTreatmentList(int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<Treatment> treatmentList = ctx.Treatments.Where(x => x.PatientID == patientID).ToList();
                return treatmentList;
            }
        }

        public IEnumerable<TreatmentPresntViewModel> getPatientPresntTreatmentList(int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var treatmentIQ = ctx.Treatments;
                var appointmentIQ = ctx.Appointments;
                var opperationIQ = ctx.opperations;

                IEnumerable<TreatmentPresntViewModel> treatmentList = (from t in treatmentIQ
                                                                       join a in appointmentIQ on t.AppointmentID equals a.AppointmentID
                                                                       join o in opperationIQ on t.OpperationID equals o.OpperationID
                                                                       where t.PatientID == patientID
                                                                       select new TreatmentPresntViewModel { TeratmentID = t.TeratmentID, TeratmentCost = t.TeratmentCost, toothNumber = t.ToothNumber, toothSideNumber = t.ToothSideNumber, Description = t.Description, treatmentState = "In Progress", AppointmentDate = a.Start_date, opperatioName = o.Name, opperationColor = o.Color }).ToList();
                return treatmentList;
            }
        }


        public bool RemoveTreatmentByID(int treatmentID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Treatment treatment = ctx.Treatments.Find(treatmentID);
                if (treatment == null)
                    return false;
                ctx.Treatments.Remove(treatment);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }


        public bool addTreatment(Treatment treatment)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                ctx.Treatments.Add(treatment);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool updateTreatment(Treatment treatment)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                ctx.Entry(treatment).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }
    }
}
