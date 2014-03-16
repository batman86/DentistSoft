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
    class PrescriptionRepository :IPrescriptionRepository
    {
        public bool addNewPrescription(PrescriptionViewModel prescription)
        {
            int count = 0;

            using (Entities.Entities ctx = new Entities.Entities())
            {
                Prescription prescriptionEntity = ctx.Prescriptions.Create();
                prescriptionEntity.PatientID = prescription.PatientID;
                prescriptionEntity.MedicineID = prescription.DoctorID;
                prescriptionEntity.DoctorID = prescription.DoctorID;
                prescriptionEntity.AppointmentID = prescription.AppointmentID;
                prescriptionEntity.Notice = prescription.Notice;
                prescriptionEntity.Dose = prescription.Dose;

                ctx.Prescriptions.Add(prescriptionEntity);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool updatePrescription(PrescriptionViewModel prescription)
        {
            int count = 0;

            using (Entities.Entities ctx = new Entities.Entities())
            {
                Prescription prescriptionEntity = ctx.Prescriptions.Find(prescription.PrescriptionID);
                if (prescriptionEntity == null)
                    return false;

                prescriptionEntity.Notice = prescription.Notice;
                prescriptionEntity.Dose = prescription.Dose;

                ctx.Entry(prescriptionEntity).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public PrescriptionPresnetViewModel getPrescriptionDetails(int prescriptiontID)
        {
            PrescriptionPresnetViewModel prescriptionViewModel;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Prescription prescriptionEntity = ctx.Prescriptions.Find(prescriptiontID);
                if (prescriptionEntity != null)
                {
                    prescriptionViewModel = new PrescriptionPresnetViewModel
                    {
                        Notice = prescriptionEntity.Notice,
                        DoctorName = prescriptionEntity.Doctor.Name,
                        MedicineName=prescriptionEntity.Medicine.Name,
                        AppointmentDate=prescriptionEntity.Appointment.Start_date,
                        Dose=prescriptionEntity.Dose
                    };
                }
                else
                    prescriptionViewModel = null;
            }
            return prescriptionViewModel;
        }

        public bool deletePrescription(int prescriptiontID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Prescription prescription = ctx.Prescriptions.Find(prescriptiontID);
                if (prescription != null)
                {
                    ctx.Prescriptions.Remove(prescription);
                    count = ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false;
        }

        public IEnumerable<PrescriptionViewModel> getPrescriptionList(int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<PrescriptionViewModel> PrescriptionList;

                var PrescriptionIQ = ctx.Prescriptions;

                PrescriptionList = (from p in PrescriptionIQ
                                   where p.PatientID == patientID
                                   select new PrescriptionViewModel{ Dose= p.Dose, Notice=p.Notice}).ToList();

                return PrescriptionList;
            }
        }
    }
}
