using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.DentistUI.Models;
using Microsoft.AspNet.Identity;
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
                var sec = new DentistManager.Domain.Entities.Secretary() { SecretaryID = int.Parse(ViewState["SecretaryID"].ToString()), UserID = identiyRole.UserId };
                SecertaryRepository secertaryRepository = new SecertaryRepository();
                secertaryRepository.updateSecertaryUserID(sec);


                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved sucessfully');window.location ='Secretary.aspx';", true);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

       

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            string key = ASPxGridView.GetDetailRowKeyValue((Control)sender).ToString();
            ViewState["SecretaryID"] = key;
            SecertaryRepository  secertaryRepository = new SecertaryRepository();
            string UserID = secertaryRepository.GetUserIDBySecertaryID(int.Parse(key));
            if (UserID == null)
            { 
                popup.Left = 400;
                popup.Top = 600;
                popup.ResizingMode = DevExpress.Web.ASPxClasses.ResizingMode.Live;
                popup.ShowOnPageLoad = true;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This Secretary Has An Account ');", true);
            }



        }

        protected void ChangePasswordpopup_Click(object sender, EventArgs e)
        {
            string key = ASPxGridView.GetDetailRowKeyValue((Control)sender).ToString();
            ViewState["SecretaryID"] = key;
            SecertaryRepository secertaryRepository = new SecertaryRepository();
            string UserID = secertaryRepository.GetUserIDBySecertaryID(int.Parse(key));
            ViewState["UserID"] = UserID;
            if (UserID != null)
            {
                lblUserName.Text = secertaryRepository.getUserNameByUserID(UserID);
                ChangePSpopup.Left = 400;
                ChangePSpopup.Top = 600;
                ChangePSpopup.ResizingMode = DevExpress.Web.ASPxClasses.ResizingMode.Live;
                ChangePSpopup.ShowOnPageLoad = true;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This Secretary Don't Have An Account ');", true);
            }

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            UserManager user = new UserManager();
            string userid = ViewState["UserID"].ToString();
            user.RemovePassword(userid);
            IdentityResult result = user.AddPassword(userid, tbPassword.Text);
            if (result.Succeeded)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Changed ');window.location ='Secretary.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Changed Faild ');", true);
            }
        }
    }
}