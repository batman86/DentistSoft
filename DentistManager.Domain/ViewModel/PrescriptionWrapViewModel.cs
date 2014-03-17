using System.Collections.Generic;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.ViewModel
{
    public class PrescriptionWrapViewModel
    {
        public IEnumerable<MedicineMiniViewModel> MedicineList { get; set; }
        public IEnumerable<AppointmentViewModel> appointmentList { get; set; }
        public PrescriptionViewModel prescriptionViewModel { get; set; }
    }
}
