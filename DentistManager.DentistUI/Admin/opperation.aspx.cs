using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete; 
namespace DentistManager.DentistUI.Admin
{
    public partial class opperation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvxOpperation_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
           // insert materials
            try
            {
              
                int opperationID = int.Parse(ViewState ["OpperatioinID"].ToString());
                ASPxDropDownEdit dd = (ASPxDropDownEdit)gvxOpperation.FindEditFormTemplateControl("ddMaterails");
                ASPxCheckBoxList list = (ASPxCheckBoxList)dd.FindControl("chlMaterails");
                List<OpperationMaterial> opperMatList = new List<OpperationMaterial>();
                foreach (ListEditItem item in list.Items)
                {
                    if (item.Selected)
                    {
                        opperMatList.Add(new OpperationMaterial() { OpperationID = opperationID, ItemID = int.Parse(item.Value.ToString()) });
 
                    }
                        
                }
                OpperationMaterialsRepository oppRepository = new OpperationMaterialsRepository();
                bool result = oppRepository.AddMaterialForOpperations(opperMatList);
                

            }
            catch (Exception)
            {
                
               
            }
            
        }

        protected void dsOpperation_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            ViewState ["OpperatioinID"] = e.Command.Parameters["@GetOpperationID"].Value.ToString();
        }

        protected void gvxOpperation_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            
        }

       
    }
}