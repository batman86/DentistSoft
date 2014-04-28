using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using DentistManager.Domain.DAL.Concrete;
namespace DentistManager.DentistUI.Appoiment
{
    public partial class Appoiments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if(User.IsInRole("Secretary"))
          {
              SecertaryRepository sec = new SecertaryRepository();
              dsAppoiments.SelectParameters["ClinicID"].DefaultValue = sec.getClinecIDByUserID(User.Identity.GetUserId()).ToString();
          }
          else if (User.IsInRole("Doctor"))
          {
              DoctorRepository doc = new DoctorRepository();
              dsAppoiments.SelectParameters["ClinicID"].DefaultValue = doc.getClinecIDByUserID(User.Identity.GetUserId()).ToString();
          }
            if(!IsPostBack)
            { ASPxScheduler1.Start = DateTime.Now.Date; }
         
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            if (User.IsInRole("Secretary"))
            {
                Response.Redirect("~/SecretaryDashboard/PatientStatus/PatientStatusList"); 
            }
            else if (User.IsInRole("Doctor"))
            {
                Response.Redirect("~/DoctorDashboard/PatientStatus/PatientStatusList");
 
            }
        }
    }
}