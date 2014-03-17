using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Concrete
{
    public class MaterialRepository : IMaterialRepository
    {

        public IEnumerable<MaterialMiniViewModel> getMatrailMiniList()
        {
            using(Entities.Entities ctx=new Entities.Entities ())
            {
                var matrailIQ = ctx.Materials;

                IEnumerable<MaterialMiniViewModel> matrailList= (from m in matrailIQ
                                                                select new MaterialMiniViewModel{ ItemID=m.ItemID, ItemName=m.ItemName }).ToList();
                return matrailList;
            }
        }
    }
}
