using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class PrescriptionViewModel
    {
        public int PrescriptionID { get; set; }
        public int AppointmentID { get; set; }
        public int MedicineID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public double? Dose { get; set; }
        public string Notice { get; set; }

    }
}
