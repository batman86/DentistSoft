using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DentistManager.Domain.ViewModel
{
    public class PatientHistoryViewModel
    {
        
        public int HistoryID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descripation { get; set; }
    }
}
