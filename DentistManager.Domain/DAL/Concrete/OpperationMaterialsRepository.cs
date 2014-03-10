using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
namespace DentistManager.Domain.DAL.Concrete
{
   public class OpperationMaterialsRepository
    {
       public bool AddMaterialForOpperations(List<OpperationMaterial> opperMaterials)
       {
            int result = 0;
           using (Entities.Entities ctx = new Entities.Entities())
           {

               foreach (OpperationMaterial opperMaterial in opperMaterials)
               {
                   var opperMat = ctx.OpperationMaterials.Create();
                   opperMat.OpperationID = opperMaterial.OpperationID;
                   opperMat.ItemID = opperMaterial.ItemID;
                   ctx.OpperationMaterials.Add(opperMat);
                   result += ctx.SaveChanges();

               }
              
           }
           return result == opperMaterials.Count ? true : false;
       }

       
    }
}
