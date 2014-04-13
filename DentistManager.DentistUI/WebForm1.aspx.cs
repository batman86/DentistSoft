using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DentistManager.Domain.DAL.Concrete;
using DevExpress.Web.ASPxGridView;
namespace DentistManager.DentistUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PaymentRepository pr = new PaymentRepository();
           Response.Write (pr.GetAllCostTreatmentByClinicByPeriod(1,new DateTime(2014,4,4),new DateTime(2014,4,4)).ToString());
           Response.Write(pr.GetAllPayedReceitsByClinicByPeriod(1, new DateTime(2014, 4, 4), new DateTime(2014, 4, 4)).ToString());
        }
    }
}