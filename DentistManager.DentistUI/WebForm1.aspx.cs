using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete;
namespace DentistManager.DentistUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PatientRepository pt = new PatientRepository();
            var patient = pt.getPatinetBasicInfo(1);
            Response.Write(patient.Name);
         
            

        }
    }
}