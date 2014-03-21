using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class ImageListWrapViewModel
    {
        public IEnumerable<ImagesViewModel> patientImageList { get; set; }
        public IEnumerable<AppointmentViewModel> appointmentList { get; set; }
        public IEnumerable<ImageCategoryViewModel> imageCategoryList { get; set; }
    }
}
