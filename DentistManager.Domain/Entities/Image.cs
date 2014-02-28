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
    using System.ComponentModel.DataAnnotations;

    public partial class Image
    {
        public int ImageID { get; set; }
        public string Name { get; set; }
        public string Notice { get; set; }
        public int appointmentID { get; set; }
        public int ImageCategoryID { get; set; }
        public int PatientID { get; set; }
        public string FullImageURL { get; set; }
        public string MediumImageURL { get; set; }
        public string MinImageURL { get; set; }
        public string LocalImageURL { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual ImageCategory ImageCategory { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
