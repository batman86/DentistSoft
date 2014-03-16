using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class PrescriptionPresnetViewModel
    {
        public int PrescriptionID { get; set; }
        public string Notice { get; set; }
        public string MedicineName { get; set; }
        public string DoctorName { get; set; }
        public double? Dose { get; set; }
        public DateTime AppointmentDate{ get; set; }
    }
}
