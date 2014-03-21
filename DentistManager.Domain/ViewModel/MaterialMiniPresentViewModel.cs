using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class MaterialMiniPresentViewModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
    }
}
