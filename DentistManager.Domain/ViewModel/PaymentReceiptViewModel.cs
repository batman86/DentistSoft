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
        [Required]
        public int ReceiptID { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int PatientPaymentID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public int ClinicID { get; set; }
    }
}
