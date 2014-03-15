using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete;
namespace DentistManager.DentistUI.Admin
{
    public partial class Receiving : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvxReceiving_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            Warehouse warehouse = new Warehouse() { ItemID = int.Parse(e.NewValues["ItemID"].ToString())
                , StorageID = int.Parse(e.NewValues["StorageID"].ToString())};
            WarehouseRepository warehouseRepository = new WarehouseRepository();
          Warehouse Getwarehouse = warehouseRepository.Getwarehouse(warehouse);
            if (Getwarehouse == null )
            {
                warehouse.Available = int.Parse(e.NewValues["Amount"].ToString());
                warehouseRepository.AddNewWarehouse(warehouse);
            }
            else
            {
                Getwarehouse.Available += int.Parse(e.NewValues["Amount"].ToString());
                warehouseRepository.UpdateWarehouse(Getwarehouse);
               

            }
          


        }

     
    }
}