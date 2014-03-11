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
using System.Data; 
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

        protected void gvxOpperation_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ViewState["OpperatioinID"] = e.EditingKeyValue;
          
        }

       

        protected void gvxOpperation_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            try
            {
                int opperationID = int.Parse(ViewState["OpperatioinID"].ToString());
                ASPxDropDownEdit dd = (ASPxDropDownEdit)gvxOpperation.FindEditFormTemplateControl("ddMaterails");
                ASPxCheckBoxList list = (ASPxCheckBoxList)dd.FindControl("chlMaterails");
                dsOpperationMaterails.SelectParameters[0].DefaultValue = opperationID.ToString();
                DataView SelectedItemView = (DataView)dsOpperationMaterails.Select(new DataSourceSelectArguments());
                DataTable SelectedItems = SelectedItemView.ToTable();
                foreach (DataRow item in SelectedItems.Rows)
                {
                    
                    list.Items.FindByValue(item[0].ToString()).Selected = true;

                }
          

            }
            catch (Exception)
            {
                
               
            }

          
        }

        protected void gvxOpperation_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            try
            {
                int opperationID = int.Parse(e.Keys[0].ToString());
                ASPxDropDownEdit dd = (ASPxDropDownEdit)gvxOpperation.FindEditFormTemplateControl("ddMaterails");
                ASPxCheckBoxList list = (ASPxCheckBoxList)dd.FindControl("chlMaterails");
                dsOpperationMaterails.SelectParameters[0].DefaultValue = opperationID.ToString();
                dsOpperationMaterails.DeleteParameters[0].DefaultValue = opperationID.ToString();
                dsOpperationMaterails.InsertParameters[0].DefaultValue = opperationID.ToString();
                DataView SelectedItemView = (DataView)dsOpperationMaterails.Select(new DataSourceSelectArguments());
                DataTable SelectedItems = SelectedItemView.ToTable();
                foreach (DataRow item in SelectedItems.Rows)
                {
                    if (!list.Items.FindByValue(item[0].ToString()).Selected)
                    {
                        dsOpperationMaterails.DeleteParameters[1].DefaultValue = item[0].ToString();
                        dsOpperationMaterails.Delete();
                        list.Items.Remove(list.Items.FindByValue(item[0].ToString()));
                    }
                    else
                    {
                        list.Items.Remove(list.Items.FindByValue(item[0].ToString()));
                    }
                }

                foreach (ListEditItem item in list.Items)
                {
                    if (item.Selected)
                    {
                        dsOpperationMaterails.InsertParameters[1].DefaultValue = item.Value.ToString();
                        dsOpperationMaterails.Insert();
                        
                    }
                    
                }


            }
            catch (Exception)
            {


            }
        }
       
    }
}