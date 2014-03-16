using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface ITreatmentRepository 
    {
        IEnumerable<Treatment> getPatientTreatmentList(int patientID);
        IEnumerable<TreatmentPresntViewModel> getPatientPresntTreatmentList(int patientID);
        bool RemoveTreatmentByID(int treatmentID);
        bool addTreatment(Treatment treatment);
        bool updateTreatment(Treatment treatment);

        bool addTreatmentList(IEnumerable<TreatmentPresntViewModel> treatmentList, int AppointmentID, int DoctorID, int PatientID);
        bool updateTreatmentList(IEnumerable<TreatmentPresntViewModel> treatmentList);
    }
}
