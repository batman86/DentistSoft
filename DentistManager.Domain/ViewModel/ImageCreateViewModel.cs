using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.ViewModel
{
    public class ImageCreateViewModel
    {
        public ImagesViewModel ImagesViewModel { get; set; }
        public IEnumerable<AppointmentViewModel> appointmentList { get; set; }
        public IEnumerable<ImageCategoryViewModel> imageCategoryList { get; set; }
    }
}
