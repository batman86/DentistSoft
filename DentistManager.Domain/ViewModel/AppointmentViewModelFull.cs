using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class AppointmentViewModelFull
    {
        public int id { get; set; }
        public string text { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int DoctorID { get; set; }
        public string Reason { get; set; }

        public int PatientID { get; set; }
        public int ClinicID { get; set; }
        public string Status { get; set; }
    }
}
