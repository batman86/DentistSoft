using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class patientListViewModelWrap
    {
        public IEnumerable<PatientMiniData> patientList  { get; set; }
        public PagingInfoHolder pagingInfoHolder { get; set; }
    }
}
