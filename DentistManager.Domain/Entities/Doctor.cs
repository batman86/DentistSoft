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
    
    public partial class Doctor
    {
        public Doctor()
        {
            this.Appointments = new HashSet<Appointment>();
            this.CustomMaterials = new HashSet<CustomMaterial>();
            this.Prescriptions = new HashSet<Prescription>();
            this.Treatments = new HashSet<Treatment>();
        }
    
        public int DoctorID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> BrithDate { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string E_mail { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<CustomMaterial> CustomMaterials { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
