using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class PatientBillInfoWrap
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? TotalCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? treatmentCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? opperationCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? materialCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? customMatrialCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? PatientPayment { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Remain { get; set; }

        public string patientName { get; set; }
        public int patientID { get; set; }
    }
}
