using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class ImagesPresentViewModel
    {
        public int ImageID { get; set; }
        public string Name { get; set; }
        public string Notice { get; set; }
        public DateTime appointmentDate { get; set; }
        public string ImageCategoryName { get; set; }
        //public int PatientID { get; set; }

        public string FullImageURL { get; set; }
        public string MediumImageURL { get; set; }
        public string MinImageURL { get; set; }
        public string LocalImageURL { get; set; }
    }
}
