<%--
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
--%>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="AppointmentForm" Codebehind="AppointmentForm.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxsc" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<div runat="server" id="ValidationContainer">
    <table class="dxscAppointmentForm" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 230px;">
    <tr>
        <td class="dxscDoubleCell" colspan="2">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblSubject" runat="server" AssociatedControlID="tbSubject">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxTextBox ClientInstanceName="_dx" ID="tbSubject" runat="server" Width="100%" Text='<%# ((AppointmentFormTemplateContainer)Container).Subject %>' />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr> 
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblLocation" runat="server" AssociatedControlID="tbLocation">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxTextBox ClientInstanceName="_dx" ID="tbLocation" runat="server" Width="100%" Text='<%# ((AppointmentFormTemplateContainer)Container).Appointment.Location %>' />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dxe:ASPxLabel ID="lblLabel" runat="server" AssociatedControlID="edtLabel">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtLabel" runat="server" Width="100%" ValueType="System.Int32" DataSource='<%# ((AppointmentFormTemplateContainer)Container).LabelDataSource %>' />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblStartDate" runat="server" AssociatedControlID="edtStartDate" Wrap="false">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxDateEdit ID="edtStartDate" runat="server" Width="100%" Date='<%# ((AppointmentFormTemplateContainer)Container).Start %>' EditFormat="DateTime" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" >
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dxe:ASPxLabel runat="server" ID="lblEndDate" Wrap="false" AssociatedControlID="edtEndDate"/>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxDateEdit id="edtEndDate" runat="server" Date='<%# ((AppointmentFormTemplateContainer)Container).End %>' EditFormat="DateTime" Width="100%" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblStatus" runat="server" AssociatedControlID="edtStatus" Wrap="false">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtStatus" runat="server" Width="100%" ValueType="System.Int32" DataSource='<%# ((AppointmentFormTemplateContainer)Container).StatusDataSource %>' />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell" style="padding-left: 22px;">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td style="width: 20px; height: 20px;">
                        <dxe:ASPxCheckBox ClientInstanceName="_dx" ID="chkAllDay" runat="server" Checked='<%# ((AppointmentFormTemplateContainer)Container).Appointment.AllDay %>'>
                        </dxe:ASPxCheckBox>
                    </td>
                    <td style="padding-left: 2px;">
                        <dxe:ASPxLabel ID="lblAllDay" runat="server" AssociatedControlID="chkAllDay" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
<% if(CanShowReminders) { %>
        <td class="dxscSingleCell">
<% } else { %>
        <td class="dxscDoubleCell" colspan="2">
<% } %>
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblResource" runat="server" AssociatedControlID="edtResource">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
<% if(ResourceSharing) { %>
                        <dxe:ASPxDropDownEdit id="ddResource" runat="server" Width="100%" ClientInstanceName="ddResource" Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanEditResource %>' AllowUserInput="false">
                            <DropDownWindowTemplate>
                                <dxe:ASPxListBox id="edtMultiResource" runat="server" width="100%" SelectionMode="CheckColumn" DataSource='<%# ResourceDataSource %>' Border-BorderWidth="0"/>
                            </DropDownWindowTemplate>
                        </dxe:ASPxDropDownEdit>                        
<% } else { %>           
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtResource" runat="server" Width="100%" DataSource='<%# ResourceDataSource %> ' Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanEditResource %>' />
<% } %>             
                    </td>

                </tr>
            </table>
        </td>
<% if(CanShowReminders) { %>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 22px;">
                        <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                            <tr>
                                <td style="width: 20px; height: 20px;">
                                    <dxe:ASPxCheckBox ID="chkReminder" runat="server"> 
                                    </dxe:ASPxCheckBox>
                                </td>
                                <td style="padding-left: 2px;">
                                    <dxe:ASPxLabel ID="lblReminder" runat="server" AssociatedControlID="chkReminder" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="dxscControlCell" style="padding-left: 3px">
                        <dxe:ASPxComboBox  ID="cbReminder" runat="server" Width="100%" DataSource='<%# ((AppointmentFormTemplateContainer)Container).ReminderDataSource %>' />
                    </td>
                </tr>
            </table>
        </td>
<% } %>
    </tr>
    <tr>
        <td class="dxscDoubleCell" colspan="2" style="height: 90px;">
            <dxe:ASPxMemo ClientInstanceName="_dx" ID="tbDescription" runat="server" Width="100%" Rows="6" Text='<%# ((AppointmentFormTemplateContainer)Container).Appointment.Description %>' />
        </td>
    </tr>
</table>
</div>
                        
<dxsc:AppointmentRecurrenceForm ID="AppointmentRecurrenceForm1" runat="server"
    IsRecurring='<%# ((AppointmentFormTemplateContainer)Container).Appointment.IsRecurring %>' 
    DayNumber='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceDayNumber %>' 
    End='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceEnd %>' 
    Month='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceMonth %>' 
    OccurrenceCount='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceOccurrenceCount %>' 
    Periodicity='<%# ((AppointmentFormTemplateContainer)Container).RecurrencePeriodicity %>' 
    RecurrenceRange='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceRange %>' 
    Start='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceStart %>' 
    WeekDays='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceWeekDays %>' 
    WeekOfMonth='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceWeekOfMonth %>' 
    RecurrenceType='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceType %>'
    IsFormRecreated='<%# ((AppointmentFormTemplateContainer)Container).IsFormRecreated %>' >
</dxsc:AppointmentRecurrenceForm>
                   
<table <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 35px;">
    <tr>
        <td class="dx-ac" style="width: 100%; height: 100%;" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "center", null) %>>
            <table class="dxscButtonTable" style="height: 100%">
                <tr>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ID="btnOk" UseSubmitBehavior="false" AutoPostBack="false" 
                            EnableViewState="false" Width="91px" EnableClientSideAPI="true"/>
                    </td>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ID="btnCancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" 
                            Width="91px" CausesValidation="False" EnableClientSideAPI="true" />
                    </td>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ID="btnDelete" UseSubmitBehavior="false"
                            AutoPostBack="false" EnableViewState="false" Width="91px"
                            Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanDeleteAppointment %>'
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%;">
    <tr>
        <td class="dx-al" style="width: 100%;"  <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "left", null) %>>
            <dxsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" MasterControlId='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).ControlId %>' />
        </td>
    </tr>
</table>
<script id="dxss_ASPxSchedulerAppoinmentForm" type="text/javascript">
    ASPxAppointmentForm = _aspxCreateClass(ASPxClientFormBase, {
        Initialize: function () {
            this.controls.edtStartDate.Validation.AddHandler(_aspxCreateDelegate(this.OnEdtStartDateValidate, this));
            this.controls.edtEndDate.Validation.AddHandler(_aspxCreateDelegate(this.OnEdtEndDateValidate, this));
            this.controls.edtStartDate.ValueChanged.AddHandler(_aspxCreateDelegate(this.OnUpdateStartEndValue, this));
            this.controls.edtEndDate.ValueChanged.AddHandler(_aspxCreateDelegate(this.OnUpdateStartEndValue, this));
            if (this.controls.chkReminder)
                this.controls.chkReminder.CheckedChanged.AddHandler(_aspxCreateDelegate(this.OnChkReminderCheckedChanged, this));
            if (this.controls.edtMultiResource)
                this.controls.edtMultiResource.SelectedIndexChanged.AddHandler(_aspxCreateDelegate(this.OnEdtMultiResourceSelectedIndexChanged, this));
        },
        OnEdtMultiResourceSelectedIndexChanged: function (s, e) {
            var resourceNames = new Array();
            var items = s.GetSelectedItems();
            var count = items.length;
            if (count > 0) {
                for (var i = 0; i < count; i++)
                    resourceNames.push(items[i].text);
            }
            else
                resourceNames.push(ddResource.cp_Caption_ResourceNone);
            ddResource.SetValue(resourceNames.join(', '));
        },
        OnEdtStartDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnEdtEndDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnUpdateStartEndValue: function (s, e) {
            var isValid = ASPxClientEdit.ValidateEditorsInContainer(null);
            this.controls.btnOk.SetEnabled(isValid);
        },
        OnChkReminderCheckedChanged: function (s, e) {
            var isReminderEnabled = this.controls.chkReminder.GetValue();
            if (isReminderEnabled)
                this.controls.cbReminder.SetSelectedIndex(3);
            else
                this.controls.cbReminder.SetSelectedIndex(-1);
            this.controls.cbReminder.SetEnabled(isReminderEnabled);
        }
    });
</script>