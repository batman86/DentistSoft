using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class CustomMaterialPresentViewModel
    {
        public int CustomMaterialID { get; set; }
        public string patienName { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ReciveDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public bool? payed { get; set; }
    }
}
