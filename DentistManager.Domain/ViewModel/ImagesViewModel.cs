using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class ImagesViewModel
    {
        public int ImageID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notice { get; set; }
        [Required]
        public int appointmentID { get; set; }
        [Required]
        public int ImageCategoryID { get; set; }
        [Required]
        public int PatientID { get; set; }

        public string FullImageURL { get; set; }
        public string MediumImageURL { get; set; }
        public string MinImageURL { get; set; }
        public string LocalImageURL { get; set; }
    }
}
