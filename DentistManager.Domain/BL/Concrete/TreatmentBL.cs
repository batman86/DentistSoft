using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.DAL.Concrete;

namespace DentistManager.Domain.BL.Concrete
{
    public class TreatmentBL :ITreatmentBL
    {
        public bool saveTreatment(IEnumerable<TreatmentPresntViewModel> treatmentList, int AppointmentID, int DoctorID, int PatientID,int clinecID)
        {
            bool check = false;
            IEnumerable<TreatmentPresntViewModel> treatmentListToAdd = treatmentList.Where(x => x.TeratmentID == 0);
            IEnumerable<TreatmentPresntViewModel> treatmentListToupdate = treatmentList.Where(x => x.TeratmentID != 0);

            TreatmentRepository tr = new TreatmentRepository();

            tr.updateTreatmentList(treatmentListToupdate);
            tr.addTreatmentList(treatmentListToAdd, AppointmentID, DoctorID, PatientID, clinecID);

            return check;
        }
    }
}
