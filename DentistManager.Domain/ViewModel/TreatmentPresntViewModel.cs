using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class TreatmentPresntViewModel
    {
        public int TeratmentID { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string opperatioName { get; set; }
        public decimal TeratmentCost { get; set; }
        public string treatmentState { get; set; }
        public string toothNumber { get; set; }
        public string toothSideNumber { get; set; }
        public string opperationColor { get; set; }
        public int OpperationID { get; set; }

    }
}
