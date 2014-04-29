using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface IPrescriptionRepository
    {
        bool addNewPrescription(PrescriptionViewModel prescription);
        bool updatePrescription(PrescriptionViewModel prescription);
        PrescriptionPresnetViewModel getPrescriptionDetails(int prescriptiontID);
        bool deletePrescription(int prescriptiontID);
        IEnumerable<PrescriptionPresnetViewModel> getPrescriptionList(int patientID);
        PrescriptionPrintViewModel getPrescriptionDetailsForPrint(int prescriptiontID);
    }
}
