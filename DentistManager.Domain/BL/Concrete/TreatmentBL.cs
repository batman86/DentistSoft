using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.BL.Concrete
{
    public class TreatmentBL :ITreatmentBL
    {
        public bool saveTreatment(IEnumerable<TreatmentPresntViewModel> treatmentList, int AppointmentID, int DoctorID, int PatientID)
        {
            throw new NotImplementedException();
        }
    }
}
