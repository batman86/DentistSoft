using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class AppointmentStatusViewModel
    {
        public int id { get; set; }
        public DateTime start_date { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string Status { get; set; }
        public string DoctorName { get; set; }
    }
}
