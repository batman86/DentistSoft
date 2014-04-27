using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Concrete
{
    public class MedicineReposditory : IMedicineRepository
    {
        public IEnumerable<MedicineMiniViewModel> getMedicineList()
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var medicenIQ= ctx.Medicines;
                IEnumerable<MedicineMiniViewModel> medicineList = (from m in medicenIQ
                                                                   select new MedicineMiniViewModel { MedicineID = m.MedicineID, Name = m.Name, ScaleType=m.ScaleType, Concentration=m.Concentration, SideEffectDecsription=m.SideEffectDecsription }).ToList();
                return medicineList;
            }
        }


        public void saveMedicineList(IEnumerable<MedicineMiniViewModel> midcList, int AppointmentID, int DoctorID, int PatientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Prescription pres = ctx.Prescriptions.Create();

                pres.AppointmentID = AppointmentID;
                pres.DoctorID = DoctorID;
                pres.PatientID = PatientID;
                pres.MedicineID = 1;

                foreach (MedicineMiniViewModel item in midcList)
                {
                  pres.Medicines.Add(ctx.Medicines.Find(item.MedicineID));
                }
                ctx.Prescriptions.Add(pres);
                ctx.SaveChanges();

            }
        }
    }
}
