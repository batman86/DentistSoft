using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentistManager.DentistUI.Admin
{
    public partial class SuperAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["SuperAdmin"] == null || !(bool)Session["SuperAdmin"] )
            {
                Response.Redirect("~/Account/login.aspx");
            }
          
        }
    }
}