using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class AppointmentStatusViewModelWrap
    {
        public  IEnumerable<AppointmentStatusViewModel> AppointmentStatusViewModelList { get; set; }
        public string statusFilter { get; set; }
        public string timeFilter { get; set; }
    }
}
