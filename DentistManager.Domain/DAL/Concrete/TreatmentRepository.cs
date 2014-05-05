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

        public IEnumerable<Treatment> getPatientTreatmentList(int patientID, int clinecID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<Treatment> treatmentList = ctx.Treatments.Include("MaterialTreatments").Where(x => x.PatientID == patientID && x.ClinicID == clinecID).ToList();
                return treatmentList;
            }
        }

        public IEnumerable<Treatment> getPatientTreatmentList(int patientID, int clinecID, DateTime from, DateTime to)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<Treatment> treatmentList = ctx.Treatments.Include("MaterialTreatments").Where(x => x.PatientID == patientID && x.ClinicID == clinecID && x.Appointment.Start_date >= from && x.Appointment.Start_date <= to).ToList();
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
                                                                       select new TreatmentPresntViewModel { TeratmentID = t.TeratmentID, TeratmentCost = t.TeratmentCost, toothNumber = t.ToothNumber, toothSideNumber = t.ToothSideNumber, Description = t.Description, treatmentState = "In Progress", AppointmentDate = a.Start_date, opperatioName = o.Name, opperationColor = o.Color, OpperationID= o.OpperationID }).ToList();
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

                ctx.MaterialTreatments.RemoveRange(treatment.MaterialTreatments);

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


        public bool addTreatmentList(IEnumerable<TreatmentPresntViewModel> treatmentList, int AppointmentID, int DoctorID, int PatientID, int clinecID)
        {
            // enhance
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                foreach (var item in treatmentList)
                {
                    Treatment treatment = ctx.Treatments.Create();
                    treatment.PatientID = PatientID;
                    treatment.DoctorID = DoctorID;
                    treatment.ClinicID = clinecID;
                    treatment.AppointmentID = AppointmentID;
                    treatment.OpperationID = item.OpperationID;
                    treatment.TeratmentCost = item.TeratmentCost;
                    treatment.ToothNumber = item.toothNumber;
                    treatment.ToothSideNumber = item.toothSideNumber;
                    treatment.Description = item.Description;
                    treatment.OpperationCost = ctx.opperations.Find(item.OpperationID).Price;
                    ctx.Treatments.Add(treatment);
                    count += ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false;
        }

        public bool updateTreatmentList(IEnumerable<TreatmentPresntViewModel> treatmentList)
        {

            // enhance
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                foreach (var item in treatmentList)
                {
                    Treatment treatment = ctx.Treatments.Find(item.TeratmentID);
                    treatment.Description = item.Description;
                    treatment.TeratmentCost = item.TeratmentCost;

                    count += ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false;
        }



    }
}
