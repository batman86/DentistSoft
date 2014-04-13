using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using System.Data.SqlClient;
using System.Configuration;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Concrete
{
    public class OpperationRepository : IOpperationRepository
    {
        public IEnumerable<opperationMiniDataViewModel> getOpperationList()
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var opperatioIQ = ctx.opperations;

                IEnumerable<opperationMiniDataViewModel> opperationList = (from o in opperatioIQ
                                                                           select new opperationMiniDataViewModel { OpperationID = o.OpperationID, Name = o.Name, FillColor = o.Color }).ToList();
                return opperationList;
            }
        }


        // add quantity to the viewModel 

        public IEnumerable<MaterialMiniPresentViewModel> getOpperationMatrailList(int opperationID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var matrailIQ = ctx.Materials;
                var opperationMatrialIQ = ctx.OpperationMaterials;

                IEnumerable<MaterialMiniPresentViewModel> matrailList = (from om in opperationMatrialIQ
                                                                         join m in matrailIQ on om.ItemID equals m.ItemID
                                                                         where  om.OpperationID == opperationID
                                                                         select new MaterialMiniPresentViewModel { ItemID = m.ItemID, ItemName = m.ItemName , Quantity= om.Quantity}).ToList();
                return matrailList;
            }
        }
    }
}
