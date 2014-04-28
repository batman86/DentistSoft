using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DentistManager.Domain.ViewModel
{
    public class PaymentReceiptViewModel
    {

        public int ReceiptID { get; set; }
        public System.DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public int PatientID { get; set; }
        public string UserID { get; set; }
        public int ClinicID { get; set; }
        public int doctorID { get; set; }
    }
}
