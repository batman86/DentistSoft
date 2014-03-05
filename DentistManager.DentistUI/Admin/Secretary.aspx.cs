using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
namespace DentistManager.DentistUI.Admin
{
    public partial class Secretary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvxSecretary_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["Active"] = true;
        }
        protected void fvDetails_DataBinding(object sender, EventArgs e)
        {
            FormView fv = (FormView)sender;
            GridViewDetailRowTemplateContainer row = (GridViewDetailRowTemplateContainer)fv.Parent;
            fv.DataSource = dsDetails;
            dsDetails.SelectParameters["SecretaryID"].DefaultValue = row.KeyValue.ToString();
        }

       
    }
}