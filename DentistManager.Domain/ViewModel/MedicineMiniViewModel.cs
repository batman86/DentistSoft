using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class MedicineMiniViewModel
    {
        public int MedicineID { get; set; }
        public string Name { get; set; }

        public string SideEffectDecsription { get; set; }
        public string ScaleType { get; set; }
        public string Dose { get; set; }
        public string Concentration { get; set; }
    }
}
