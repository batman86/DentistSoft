using DentistManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DentistManager.Domain.ViewModel
{
    public class PrescriptionPrintViewModel
    {
        public int PrescriptionID { get; set; }
        public string Notice { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string patientName { get; set; }

        public ICollection<Medicine> Medicines { get; set; }
    }
}
