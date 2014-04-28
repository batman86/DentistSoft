using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Concrete
{
    class StorgeRepository : IstorgeRepository
    {
        public IEnumerable<int> getClinecStorgesList(int clinecID)
        {
            using(Entities.Entities ctx =new Entities.Entities ())
            {
                 IEnumerable<int> storages=  ctx.Storages.Where(x => x.ClinicID == clinecID && x.Active == true).Select(x => x.StorageID).ToList();
                 return storages;
            }
        }

        public List<StorageMatrailViewModel> getStrogesMatrailsQuantity(IEnumerable<int> storagesIDList, int matrailID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                List<StorageMatrailViewModel> storageMatrailList=new List<StorageMatrailViewModel> ();

                var warehouseIQ = ctx.Warehouses;
                StorageMatrailViewModel storageMatrailViewModel;

                foreach (int item in storagesIDList)
	            {
                    storageMatrailViewModel = (from w in warehouseIQ
                                              where w.StorageID == item
                                              select new StorageMatrailViewModel { StorageID = item, Quantity = w.Available }).FirstOrDefault();

                    if (storageMatrailViewModel != null)
                        storageMatrailList.Add(storageMatrailViewModel);
	            }

                storageMatrailList.TrimExcess();


                return storageMatrailList;
            }
        }


        public bool withdrawMatrailFromWarehouse(int matrailID, int? storgeID, int quantity)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Warehouse warehouse = ctx.Warehouses.Where(x => x.StorageID == storgeID && x.ItemID == matrailID).FirstOrDefault();
                if (warehouse == null)
                    return false;
                warehouse.Available -= quantity;
                ctx.Entry(warehouse).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }
    }
}
