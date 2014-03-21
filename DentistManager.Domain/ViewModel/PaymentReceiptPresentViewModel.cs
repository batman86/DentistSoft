using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class PaymentReceiptPresentViewModel
    {
        public int receiptID { get; set; }
        public decimal receiptAmount { get; set; }
        public DateTime ReviceDate { get; set; }
        public string reciverName { get; set; }
    }
}
