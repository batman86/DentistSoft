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
    
    public partial class Patient
    {
        public Patient()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Images = new HashSet<Image>();
            this.PatientHistories = new HashSet<PatientHistory>();
            this.Prescriptions = new HashSet<Prescription>();
        }
    
        public int PatientID { get; set; }
        public Nullable<int> ClinicID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> Age { get; set; }
        public System.DateTime BrithDate { get; set; }
        public string gender { get; set; }
        public string E_mail { get; set; }
        public string Notice { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PatientHistory> PatientHistories { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
