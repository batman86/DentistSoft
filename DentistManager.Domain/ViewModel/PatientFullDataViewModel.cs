using System;
using System.ComponentModel.DataAnnotations;

namespace DentistManager.Domain.ViewModel
{
    public class PatientFullDataViewModel
    {
        public int PatientID { get; set; }
        public int ClinicID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Mobile { get; set; }
        public Nullable<int> Age { get; set; }
        [Required]
        public DateTime BrithDate { get; set; }
        [Required]
        [StringLength(50)]
        public string gender { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string E_mail { get; set; }
        [StringLength(50)]
        public string Notice { get; set; }
        [Required]
        public Nullable<int> DoctorID { get; set; }
    }
}
