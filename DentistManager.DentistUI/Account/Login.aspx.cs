using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DentistManager.Domain.Entities;
namespace DentistManager.DentistUI.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (tbUserName.Text == "Master" && tbPassword.Text == "zKCNMOHviKdajR")

            {
                Session["SuperAdmin"] = true;
                Response.Redirect("~/Account/SuperAdmin.aspx");
 
            }

            //using (Entities ctx = new Entities())
            //{
            //    AspNetUser user = ctx.AspNetUsers.Where(u => u.UserName == tbUserName.Text && u.PasswordHash == tbPassword.Text).FirstOrDefault();
            //    if (user != null)
            //    {
            //        Session["SuperAdmin"] = true;
            //        Response.Redirect("~/Admin/SuperAdmin.aspx");
 
            //    }
            //}



            //if (Membership.ValidateUser(tbUserName.Text, tbPassword.Text))
            //{

            //    if (string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            //    {
            //        FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
            //        Response.Redirect("~/");
            //    }
            //    else
            //        FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
            //}
            //else
            //{
            //    tbUserName.ErrorText = "Invalid user";
            //    tbUserName.IsValid = false;
            //}
        }
    }
}