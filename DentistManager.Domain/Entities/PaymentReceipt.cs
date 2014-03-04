//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentistManager.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentReceipt
    {
        public int ReceiptID { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int PatientPaymentID { get; set; }
        public string UserID { get; set; }
        public int ClinicID { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
