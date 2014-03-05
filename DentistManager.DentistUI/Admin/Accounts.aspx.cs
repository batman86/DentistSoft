using DentistManager.DentistUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete;

namespace DentistManager.DentistUI.Admin
{
    public partial class Accounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                if (cbRoles.SelectedItem.Value.ToString() != "3")
                {
                  
                    var doc = new Doctor() { DoctorID = int.Parse(cbEmployee.SelectedItem.Value.ToString()),UserID=identiyRole.UserId};
                    DoctorRepository doctorRepository = new DoctorRepository();
                    doctorRepository.updateDoctorUserID(doc);
                }
                else
                {
                    var sec = new DentistManager.Domain.Entities.Secretary() { SecretaryID = int.Parse(cbEmployee.SelectedItem.ValueString), UserID = identiyRole.UserId };
                    SecertaryRepository secertaryRepository = new SecertaryRepository();
                    secertaryRepository.updateSecertaryUserID(sec);
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved sucessfully');window.location ='Accounts.aspx';", true);  
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Password"] = Password.Text;
            if (cbRoles.SelectedItem.Value.ToString() != "3")
            {
                dsEmployees.SelectCommand = "SELECT [DoctorID], [Name] FROM [Doctors] WHERE [UserID] IS NULL";
                dsEmployees.ConnectionString = ConfigurationManager.ConnectionStrings["Dentist"].ToString();
                cbEmployee.DataBind();
                cbEmployee.TextField = "Name";
                cbEmployee.ValueField = "DoctorID";
            }
            else
            {
                dsEmployees.SelectCommand = "SELECT [SecretaryID],[Name] FROM [Dentist].[dbo].[Secretary] where [UserID] IS NULL";
                dsEmployees.ConnectionString = ConfigurationManager.ConnectionStrings["Dentist"].ToString();
                cbEmployee.DataBind();
                cbEmployee.TextField = "Name";
                cbEmployee.ValueField = "SecretaryID";
                    
            }
        }

       
    }
}