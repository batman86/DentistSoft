using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.Entities;
namespace DentistManager.Domain.BL.Concrete
{
   public class WarehouseBL
    {

       public bool InsertMangment(int ItemID , int StorageID , int Amount)
       {

           Warehouse warehouse = new Warehouse() { ItemID = ItemID, StorageID = StorageID };
           WarehouseRepository warehouseRepository = new WarehouseRepository();
           Warehouse Getwarehouse = warehouseRepository.Getwarehouse(warehouse);
            if (Getwarehouse == null )
            {
                warehouse.Available = Amount;
                warehouseRepository.AddNewWarehouse(warehouse);
                return true;
            }
            else
            {
                Getwarehouse.Available += Amount;
                warehouseRepository.UpdateWarehouse(Getwarehouse);
                return true;
            }
          
       }

       public bool UpdateMangment(int ItemID, int StorageID, int Amount)
       {
           try
           {
               Warehouse warehouse = new Warehouse() { ItemID = ItemID, StorageID = StorageID };
               WarehouseRepository warehouseRepository = new WarehouseRepository();
               Warehouse Getwarehouse = warehouseRepository.Getwarehouse(warehouse);
               Getwarehouse.Available -= Amount;
               warehouseRepository.UpdateWarehouse(Getwarehouse);

               return true;
           }
           catch (Exception)
           {
               return false;
           }
           
           
 
       }

    }
}
