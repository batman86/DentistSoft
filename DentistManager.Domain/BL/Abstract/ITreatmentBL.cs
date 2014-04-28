using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.BL.Abstract
{
    public interface ITreatmentBL
    {
        bool saveTreatment(IEnumerable<TreatmentPresntViewModel> treatmentList, int AppointmentID, int DoctorID, int PatientID, int clinecID);

        bool SaveMatrailOfTreatment( IEnumerable<MatrailToSaveViewModel> matrailList, int treatmentID,int clinecID);
    }
}
