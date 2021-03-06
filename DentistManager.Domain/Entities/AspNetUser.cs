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
    
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.Doctors = new HashSet<Doctor>();
            this.PaymentReceipts = new HashSet<PaymentReceipt>();
            this.Secretaries = new HashSet<Secretary>();
            this.AspNetRoles = new HashSet<AspNetRole>();
        }
    
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Discriminator { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<PaymentReceipt> PaymentReceipts { get; set; }
        public virtual ICollection<Secretary> Secretaries { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
