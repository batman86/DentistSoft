using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

namespace DentistManager.DentistUI.Admin
{
    public partial class PatientStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvxAppoiments.DataColumns["Start_date"].Settings.AutoFilterCondition = AutoFilterCondition.Equals;
            gvxAppoiments.AutoFilterByColumn(gvxAppoiments.Columns["Start_date"], DateTime.Now.Date.ToString());
            gvxAppoiments.SettingsText.Title = gvxAppoiments.FilterExpression;
        }

     
        

        }
}