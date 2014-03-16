using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.BL.Concrete;
namespace DentistManager.DentistUI.Admin
{
    public partial class Receiving : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvxReceiving_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            WarehouseBL warehouseMangement = new WarehouseBL();
            warehouseMangement.InsertMangment(int.Parse(e.NewValues["ItemID"].ToString()), int.Parse(e.NewValues["StorageID"].ToString()), int.Parse(e.NewValues["Amount"].ToString()));

        }

        protected void gvxReceiving_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            if (e.OldValues["ItemID"] != e.NewValues["ItemID"] || e.OldValues["StorageID"] != e.NewValues["StorageID"])
            {
                WarehouseBL warhouseManagement = new WarehouseBL();
                warhouseManagement.UpdateMangment(int.Parse(e.OldValues["ItemID"].ToString()), int.Parse(e.OldValues["StorageID"].ToString()), int.Parse(e.OldValues["Amount"].ToString()));
                warhouseManagement.InsertMangment(int.Parse(e.NewValues["ItemID"].ToString()), int.Parse(e.NewValues["StorageID"].ToString()), int.Parse(e.NewValues["Amount"].ToString()));
 
            }
        }

     
    }
}