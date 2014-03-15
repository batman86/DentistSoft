using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.Entities;
namespace DentistManager.Domain.DAL.Concrete
{
   public class WarehouseRepository
    {
       public Warehouse Getwarehouse(Warehouse warehouse)
       {
           using (Entities.Entities ctx = new Entities.Entities())
           {
               var Warehouse = ctx.Warehouses;
              warehouse =  Warehouse.Where(w=>w.ItemID == warehouse.ItemID && w.StorageID==warehouse.StorageID ).FirstOrDefault();

           }
           return warehouse;
       }
       public bool AddNewWarehouse(Warehouse warehouse)
       {
           int result = 0 ;
           using (Entities.Entities ctx = new Entities.Entities())
           {
               ctx.Warehouses.Add(warehouse);
               result = ctx.SaveChanges();
           }
           return result > 0 ? true : false;
       }
       public bool UpdateWarehouse(Warehouse warehouse)
       {
           int result = 0;
           using (Entities.Entities ctx = new Entities.Entities())
           {
               ctx.Entry(warehouse).State = System.Data.Entity.EntityState.Modified;
               result = ctx.SaveChanges();
               
           }
           return false;
       }
    }
}
