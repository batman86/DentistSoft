using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.Entities;

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


        public bool SaveTreatmentMatrail(IEnumerable<MatrailToSaveViewModel> matrailList, int treatmentID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                foreach (var item in matrailList)
                {
                    MaterialTreatment materialTreatment = ctx.MaterialTreatments.Where(x => x.TeratmentID == treatmentID && x.MaterialID == item.MatrailID).FirstOrDefault();
                    if(materialTreatment == null)
                    {
                        materialTreatment = ctx.MaterialTreatments.Create();
                        materialTreatment.TeratmentID = treatmentID;
                        materialTreatment.MaterialID = item.MatrailID;
                        materialTreatment.MaterialCost = ctx.Materials.Find(item.MatrailID).MaterialCost;
                        materialTreatment.Quantity = item.Quantity;
                        ctx.MaterialTreatments.Add(materialTreatment);
                    }
                    else
                    {
                        materialTreatment.Quantity = item.Quantity;
                        ctx.Entry(materialTreatment).State = System.Data.Entity.EntityState.Modified;
                    }

                  count +=  ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false ;
        }


        public IEnumerable<MaterialMiniPresentViewModel> getTreatmentMatrailList(int treatmentID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var matrailIQ = ctx.Materials;
                var MaterialTreatmentsIQ = ctx.MaterialTreatments;

                IEnumerable<MaterialMiniPresentViewModel> matrailList = (from mt in MaterialTreatmentsIQ
                                                                         join m in matrailIQ on mt.MaterialID equals m.ItemID
                                                                         where mt.TeratmentID == treatmentID
                                                                         select new MaterialMiniPresentViewModel { ItemID = m.ItemID, ItemName = m.ItemName, Quantity = (int)mt.Quantity }).ToList();
                return matrailList;
            }
        }


        public bool removeTreatmentMatrail(int matrailID, int treatmentID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var matrailIQ = ctx.Materials;

                MaterialTreatment mt= ctx.MaterialTreatments.Where(x=>x.MaterialID == matrailID && x.TeratmentID == treatmentID).FirstOrDefault();
                if(mt == null)
                    return false;

                ctx.MaterialTreatments.Remove(mt);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }


        public int getQuanityOfMatrailTreatment(int matrailID, int treatmentID)
        {
           int quantity = 0;
           using (Entities.Entities ctx = new Entities.Entities())
           {
               MaterialTreatment mt = ctx.MaterialTreatments.Where(x => x.MaterialID == matrailID && x.TeratmentID == treatmentID).FirstOrDefault();
               if (mt == null)
                   return 0;

               quantity =(int) mt.Quantity;
           }
           return quantity;
        }
    }
}
