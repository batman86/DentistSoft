using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.DentistUI.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;
namespace DentistManager.DentistUI.Admin
{
    public partial class Doctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvxDoctors_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["Active"] = true;

        }

        protected void fvDetails_DataBinding(object sender, EventArgs e)
        {
            FormView fv = (FormView)sender;
            GridViewDetailRowTemplateContainer row = (GridViewDetailRowTemplateContainer)fv.Parent;
            fv.DataSource = dsDetails;
            dsDetails.SelectParameters["DoctorID"].DefaultValue = row.KeyValue.ToString();
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = UserName.Text };
            var identiyRole = new IdentityUserRole();
            identiyRole.RoleId = cbRoles.SelectedItem.Value.ToString();
            identiyRole.UserId = user.Id;
            user.Roles.Add(identiyRole);
            IdentityResult result = manager.Create(user, Password.Text);
            
            if (result.Succeeded)
            {
                  var doc = new Doctor() { DoctorID = int.Parse(ViewState["DoctorID"].ToString()), UserID = identiyRole.UserId };
                    DoctorRepository doctorRepository = new DoctorRepository();
                    doctorRepository.updateDoctorUserID(doc);
               

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved sucessfully');window.location ='Doctors.aspx';", true);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Password"] = Password.Text;
            
        }

      

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            string key = ASPxGridView.GetDetailRowKeyValue((Control)sender).ToString();
            ViewState["DoctorID"] = key;
            DoctorRepository doctorRepository = new DoctorRepository();
            string UserID = doctorRepository.GetUserIDByDoctorID(int.Parse(key));
            if (UserID == null )
            {
             popup.Left = 400;
             popup.Top = 600;
             popup.ResizingMode = DevExpress.Web.ASPxClasses.ResizingMode.Live;
             popup.ShowOnPageLoad = true;
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This Doctor Has An Account ');", true);
            }

     
           
        }

        protected void gvxDoctors_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
           
          
        }

        protected void btnChangePasswordpopup_Click(object sender, EventArgs e)
        {
            string key = ASPxGridView.GetDetailRowKeyValue((Control)sender).ToString();
            ViewState["DoctorID"] = key;
            DoctorRepository doctorRepository = new DoctorRepository();
            string UserID = doctorRepository.GetUserIDByDoctorID(int.Parse(key));
            ViewState["UserID"] = UserID;
            if (UserID!= null)
            {
                lblUserName.Text = doctorRepository.getUserNameByUserID(UserID);
                ChangePSpopup.Left = 400;
                ChangePSpopup.Top = 600;
                ChangePSpopup.ResizingMode = DevExpress.Web.ASPxClasses.ResizingMode.Live;
                ChangePSpopup.ShowOnPageLoad = true;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This Doctor Don't Have An Account ');", true);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            //MembershipUser user = Membership.GetUser(lblUserName.Text);
            UserManager user = new UserManager();
            string userid = ViewState["UserID"].ToString();
            user.RemovePassword(userid);
            IdentityResult result = user.AddPassword(userid, tbPassword.Text);
           if(result.Succeeded)
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Changed ');window.location ='Doctors.aspx';", true);
           }
           else
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Changed Faild ');", true);
           }
        }

        
    }
}