using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class PatientCreateWrap
    {
        public IEnumerable<DoctorMiniInfoViewModel> DoctorsList { get; set; }
        public PatientFullDataViewModel PatientInfo { get; set; }
    }
}
