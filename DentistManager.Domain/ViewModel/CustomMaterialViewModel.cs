using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class CustomMaterialViewModel
    {
        public int CustomMaterialID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ReciveDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int clinecid { get; set; }
        public int payed { get; set; }
    }
}
