using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class MatrailToSaveWrapViewModel
    {
        public int treatmentID { get; set; }
        public IEnumerable<MatrailToSaveViewModel> vmMatrailListToSave { get; set; }
    }
}
