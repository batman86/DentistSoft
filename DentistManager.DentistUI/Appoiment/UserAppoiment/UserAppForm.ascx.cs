using System;
using System.Web.UI;
using DevExpress.XtraScheduler;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using System.Collections;
using System.Collections.Generic;
using DevExpress.XtraScheduler.Localization;
using DevExpress.Web.ASPxScheduler.Localization;
using DevExpress.Utils;
using DentistManager.Domain.Entities;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.ViewModel;
namespace DentistManager.DentistUI.Appoiment.UserAppoiment
{
    public partial class UserAppForm : SchedulerFormControl
    {
        public override string ClassName { get { return "ASPxAppointmentForm"; } }

        public bool CanShowReminders
        {
            get
            {
                return ((AppointmentFormTemplateContainer)Parent).Control.Storage.EnableReminders;
            }
        }
        public bool ResourceSharing
        {
            get
            {
                return ((AppointmentFormTemplateContainer)Parent).Control.Storage.ResourceSharing;
            }
        }
        public IEnumerable ResourceDataSource
        {
            get
            {
                return ((AppointmentFormTemplateContainer)Parent).ResourceDataSource;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Localize();
          
              
            
        }
        void Localize()
        {
         
            lblStartDate.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_StartTime);
            lblEndDate.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_EndTime);
         
            if (CanShowReminders)
              
            btnOk.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonOk);
            btnCancel.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonCancel);
            btnDelete.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonDelete);
            btnOk.Wrap = DefaultBoolean.False;
            btnCancel.Wrap = DefaultBoolean.False;
            btnDelete.Wrap = DefaultBoolean.False;
        }
        public override void DataBind()
        {
            base.DataBind();

            AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
           DevExpress.XtraScheduler.Appointment apt = container.Appointment;
           

            PopulateResourceEditors(apt, container);

            AppointmentRecurrenceForm1.Visible = container.ShouldShowRecurrence;

            if (container.Appointment.HasReminder)
            {
               
            }
            else
            {
               
            }
            btnOk.ClientSideEvents.Click = container.SaveHandler;
            btnCancel.ClientSideEvents.Click = container.CancelHandler;
            btnDelete.ClientSideEvents.Click = container.DeleteHandler;
            //fill data on Edit
            if (container.Appointment.CustomFields["PatientID"] != null)
            {
                cbDoctors.SelectedIndex = cbDoctors.Items.IndexOfValue(container.Appointment.CustomFields["DoctorID"].ToString());
                cbPatients.SelectedIndex = cbPatients.Items.IndexOfValue(container.Appointment.CustomFields["PatientID"].ToString());
                cbClinics.SelectedIndex = cbClinics.Items.IndexOfValue(container.Appointment.CustomFields["ClinicID"].ToString());
                cbStatus.SelectedIndex = cbStatus.Items.IndexOfText(container.Appointment.CustomFields["Status"].ToString());
            }

            //btnDelete.Enabled = !container.IsNewAppointment;
        }
        private void PopulateResourceEditors(DevExpress.XtraScheduler.Appointment apt, AppointmentFormTemplateContainer container)
        {
           
        }
        List<String> GetListBoxSeletedItemsText(ASPxListBox listBox)
        {
            List<String> result = new List<string>();
            foreach (ListEditItem editItem in listBox.Items)
            {
                if (editItem.Selected)
                    result.Add(editItem.Text);
            }
            return result;
        }
        void SetListBoxSelectedValues(ASPxListBox listBox, IEnumerable values)
        {
            listBox.Value = null;
            foreach (object value in values)
            {
                ListEditItem item = listBox.Items.FindByValue(value.ToString());
                if (item != null)
                    item.Selected = true;
            }
        }
        protected override void PrepareChildControls()
        {
            AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
            ASPxScheduler control = container.Control;
            AppointmentRecurrenceForm1.EditorsInfo = new EditorsInfo(control, control.Styles.FormEditors, control.Images.FormEditors, control.Styles.Buttons);
            base.PrepareChildControls();

            // me 
            //AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
            //string s = container.Appointment.Id.ToString();
           
        }
        protected override ASPxEditBase[] GetChildEditors()
        {
            ASPxEditBase[] edits = new ASPxEditBase[] {
         
            
            lblStartDate, edtStartDate,
            lblEndDate, edtEndDate,
         
            tbDescription, GetMultiResourceEditor()
        };

            return edits;
        }
        ASPxEditBase GetMultiResourceEditor()
        {
            
            return null;
        }
        protected override ASPxButton[] GetChildButtons()
        {
            ASPxButton[] buttons = new ASPxButton[] {
            btnOk, btnCancel, btnDelete
        };
            return buttons;
        }
        protected override Control[] GetChildControls()
        {
            return new Control[] { ValidationContainer };
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
            if (cbPatients.SelectedItem != null || cbDoctors.SelectedItem != null || cbClinics.SelectedItem != null || cbStatus.SelectedItem != null)
            {

                if (container.IsNewAppointment)
                {
                    AppointmentViewModelFull app = new AppointmentViewModelFull()
                    {
                        ClinicID = int.Parse(cbClinics.SelectedItem.Value.ToString()),
                        DoctorID = int.Parse(cbDoctors.SelectedItem.Value.ToString()),
                        PatientID = int.Parse(cbPatients.SelectedItem.Value.ToString()),
                        start_date = edtStartDate.Date,
                        end_date = edtEndDate.Date,
                        Reason = string.Empty,
                        Status = cbStatus.SelectedItem.Text,
                        text = tbDescription.Text

                    };
                    AppointmentRepository apprep = new AppointmentRepository();
                    apprep.AddNewAppointment(app);
                }


                else
                {
                    AppointmentViewModelFull app = new AppointmentViewModelFull()
                    {
                        id = int.Parse(container.Appointment.Id.ToString()),
                        ClinicID = int.Parse(cbClinics.SelectedItem.Value.ToString()),
                        DoctorID = int.Parse(cbDoctors.SelectedItem.Value.ToString()),
                        PatientID = int.Parse(cbPatients.SelectedItem.Value.ToString()),
                        start_date = edtStartDate.Date,
                        end_date = edtEndDate.Date,
                        Reason = string.Empty,
                        Status = cbStatus.SelectedItem.Text,
                        text = tbDescription.Text
                    };
                    AppointmentRepository apprep = new AppointmentRepository();
                    apprep.alterAppointment(app);
                }
                Response.Redirect("~/Appoiment/Appoiments.aspx");
                
            }
            else
            {
                //warining
 
            }
          
           
        }

        protected void cbPatients_DataBound(object sender, EventArgs e)
        {
            
           
        } 
    }
}