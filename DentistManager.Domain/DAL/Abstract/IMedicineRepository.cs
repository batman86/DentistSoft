using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface IMedicineRepository
    {
        IEnumerable<MedicineMiniViewModel> getMedicineList();
        void saveMedicineList(IEnumerable<MedicineMiniViewModel> midcList, int AppointmentID, int DoctorID, int PatientID);
    }
}
