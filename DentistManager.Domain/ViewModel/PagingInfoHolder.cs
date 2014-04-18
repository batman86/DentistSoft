using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class PagingInfoHolder
    {
        public int pageNumber { get; set; }
        public int ItemTotal { get; set; }
        public int pageSize { get; set; }

        //public string areaName { get; set; }
        //public string controllerName { get; set; }
        //public string ActionName { get; set; }
    }
}
