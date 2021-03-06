/*
{****************************************************************************************}
{    This file contains the default dialog template. The changes will affect the default }
{    dialog of the ASPxScheduler in your web project.                                    }
{    The file location is specified in the 'OptionsForms.AppointmentFormTemplateUrl'     }
{    property of the ASPxScheduler control.                                              }
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the 'OptionsForms.AppointmentFormTemplateUrl'    }
{          property of the ASPxScheduler control.                                        }
{       3. Perform required modifications.                                               }
{       4. If you need custom fields to be displayed and processed, review the How to:   }
{          Modify the Appointment Editing Form for Working with Custom Fields document   }
{          available online at                                                           }
{          http://documentation.devexpress.com/#AspNet/CustomDocument5464.               }
{                                                                                        }
{       You can learn more about this online at:                                         }
{       http://documentation.devexpress.com/#AspNet/CustomDocument9591                   }
{                                                                                        }
{****************************************************************************************}
*/
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

public partial class AppointmentForm : SchedulerFormControl {
    public override string ClassName { get { return "ASPxAppointmentForm"; } }

    public bool CanShowReminders {
        get {
            return ((AppointmentFormTemplateContainer)Parent).Control.Storage.EnableReminders;
        }
    }
    public bool ResourceSharing {
        get {
            return ((AppointmentFormTemplateContainer)Parent).Control.Storage.ResourceSharing;
        }
    }
    public IEnumerable ResourceDataSource {
        get {
            return ((AppointmentFormTemplateContainer)Parent).ResourceDataSource;
        }
    }

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        Localize();
        tbSubject.Focus();
    }
    void Localize() {
        lblSubject.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Subject);
        lblLocation.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Location);
        lblLabel.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Label);
        lblStartDate.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_StartTime);
        lblEndDate.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_EndTime);
        lblStatus.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Status);
        lblAllDay.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_AllDayEvent);
        lblResource.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Resource);
        if (CanShowReminders)
            lblReminder.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Reminder);
        btnOk.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonOk);
        btnCancel.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonCancel);
        btnDelete.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonDelete);
        btnOk.Wrap = DefaultBoolean.False;
        btnCancel.Wrap = DefaultBoolean.False;
        btnDelete.Wrap = DefaultBoolean.False;
    }
    public override void DataBind() {
        base.DataBind();

        AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
        Appointment apt = container.Appointment;
        edtLabel.SelectedIndex = apt.LabelId;
        edtStatus.SelectedIndex = apt.StatusId;

        PopulateResourceEditors(apt, container);

        AppointmentRecurrenceForm1.Visible = container.ShouldShowRecurrence;

        if(container.Appointment.HasReminder) {
            cbReminder.Value = container.Appointment.Reminder.TimeBeforeStart.ToString();
            chkReminder.Checked = true;
        }
        else {
            cbReminder.ClientEnabled = false;
        }

        btnOk.ClientSideEvents.Click = container.SaveHandler;
        btnCancel.ClientSideEvents.Click = container.CancelHandler;
        btnDelete.ClientSideEvents.Click = container.DeleteHandler;

        //btnDelete.Enabled = !container.IsNewAppointment;
    }
    private void PopulateResourceEditors(Appointment apt, AppointmentFormTemplateContainer container) {
        if(ResourceSharing) {
            ASPxListBox edtMultiResource = ddResource.FindControl("edtMultiResource") as ASPxListBox;
            if(edtMultiResource == null)
                return;
            SetListBoxSelectedValues(edtMultiResource, apt.ResourceIds);
            List<String> multiResourceString = GetListBoxSeletedItemsText(edtMultiResource);
            string stringResourceNone = SchedulerLocalizer.GetString(SchedulerStringId.Caption_ResourceNone);
            ddResource.Value = stringResourceNone;
            if(multiResourceString.Count > 0)
                ddResource.Value = String.Join(", ", multiResourceString.ToArray());
            ddResource.JSProperties.Add("cp_Caption_ResourceNone", stringResourceNone);
        }
        else {
            if(!Object.Equals(apt.ResourceId, Resource.Empty.Id))
                edtResource.Value = apt.ResourceId.ToString();
            else
                edtResource.Value = SchedulerIdHelper.EmptyResourceId;
        }
    }
    List<String> GetListBoxSeletedItemsText(ASPxListBox listBox) {
        List<String> result = new List<string>();
        foreach(ListEditItem editItem in listBox.Items) {
            if(editItem.Selected)
                result.Add(editItem.Text);
        }
        return result;
    }
    void SetListBoxSelectedValues(ASPxListBox listBox, IEnumerable values) {
        listBox.Value = null;
        foreach(object value in values) {
            ListEditItem item = listBox.Items.FindByValue(value.ToString());
            if(item != null)
                item.Selected = true;
        }
    }
    protected override void PrepareChildControls() {
        AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
        ASPxScheduler control = container.Control;

        AppointmentRecurrenceForm1.EditorsInfo = new EditorsInfo(control, control.Styles.FormEditors, control.Images.FormEditors, control.Styles.Buttons);
        base.PrepareChildControls();
    }
    protected override ASPxEditBase[] GetChildEditors() {
        ASPxEditBase[] edits = new ASPxEditBase[] {
            lblSubject, tbSubject,
            lblLocation, tbLocation,
            lblLabel, edtLabel,
            lblStartDate, edtStartDate,
            lblEndDate, edtEndDate,
            lblStatus, edtStatus,
            lblAllDay, chkAllDay,
            lblResource, edtResource,
            tbDescription, cbReminder,
            ddResource, chkReminder, GetMultiResourceEditor()
        };
        
        return edits;
    }
    ASPxEditBase GetMultiResourceEditor() {
        if (ddResource != null) 
            return ddResource.FindControl("edtMultiResource") as ASPxEditBase;
        return null;
    }
    protected override ASPxButton[] GetChildButtons() {
        ASPxButton[] buttons = new ASPxButton[] {
            btnOk, btnCancel, btnDelete
        };
        return buttons;
    }
    protected override Control[] GetChildControls() {
        return new Control[] { ValidationContainer };
    }  
}
