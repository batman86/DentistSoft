using DentistManager.Domain.DAL.Abstract;
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
                                                                   select new MedicineMiniViewModel { MedicineID = m.MedicineID, Name = m.Name, Dose=m.Dose, ScaleType=m.ScaleType, Concentration=m.Concentration, SideEffectDecsription=m.SideEffectDecsription }).ToList();
                return medicineList;
            }
        }
    }
}
