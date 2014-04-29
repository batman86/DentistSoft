using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DentistManager.Domain.DAL.Concrete;
using DevExpress.Web.ASPxGridView;

using DentistManager.DentistUI.core;

namespace DentistManager.DentistUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            security ob = new security();
            ob.mainCreate();
        }
    }
}