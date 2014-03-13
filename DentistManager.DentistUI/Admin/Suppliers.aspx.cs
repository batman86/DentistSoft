using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

namespace DentistManager.DentistUI.Admin
{
    public partial class Suppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fvDetails_DataBinding(object sender, EventArgs e)
        {
            FormView fv = (FormView)sender;
            GridViewDetailRowTemplateContainer row = (GridViewDetailRowTemplateContainer)fv.Parent;
            fv.DataSource = dsSuppliersDetails;
            dsSuppliersDetails.SelectParameters["SuppID"].DefaultValue = row.KeyValue.ToString();
        }
    }
}