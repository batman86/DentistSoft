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

<%@ Control Language="C#" AutoEventWireup="true" Inherits="AppointmentFormEx" Codebehind="AppointmentFormEx.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxsc" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
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
                        <dxe:ASPxTextBox ClientInstanceName="_dx" ID="tbSubject" runat="server" Width="100%" Text='<%# ((AppointmentFormTemplateContainer)Container).Appointment.Subject %>' />
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
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtLabel" runat="server" Width="100%" DataSource='<%# ((AppointmentFormTemplateContainer)Container).LabelDataSource %>' />
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
                        <dxe:ASPxDateEdit ClientInstanceName="_dx" ID="edtStartDate" runat="server" Width="100%" Date='<%# ((AppointmentFormTemplateContainer)Container).Start %>' EditFormat="DateTime" DateOnError="Undo" AllowNull="false"/> 
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
                        <dxe:ASPxDateEdit id="edtEndDate" runat="server" Date='<%# ((AppointmentFormTemplateContainer)Container).End %>'
                            EditFormat="DateTime" Width="100%" DateOnError="Undo" AllowNull="false">
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
                        <dxe:ASPxComboBox ClientInstanceName="_dx" ID="edtStatus" runat="server" Width="100%" DataSource='<%# ((AppointmentFormTemplateContainer)Container).StatusDataSource %>' />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell" style="padding-left: 22px;">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td style="width: 20px; height: 20px;">
                        <dxe:ASPxCheckBox ClientInstanceName="_dx" ID="chkAllDay" runat="server" Checked='<%# ((AppointmentFormTemplateContainer)Container).Appointment.AllDay %>' />
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
                                <dxe:ASPxListBox id="edtMultiResource" runat="server" width="100%" SelectionMode="CheckColumn" DataSource='<%# ResourceDataSource %>' Border-BorderWidth="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                        var resourceNames = new Array();
                                        var items = s.GetSelectedItems();
                                        var count = items.length;
                                        if (count > 0) {
                                            for(var i=0; i<count; i++) 
                                                resourceNames.push(items[i].text);
                                        }
                                        else
                                            resourceNames.push(ddResource.cp_Caption_ResourceNone);
                                        ddResource.SetValue(resourceNames.join(', '));
                                    }"></ClientSideEvents>
                                </dxe:ASPxListBox>
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
                                    <dxe:ASPxCheckBox ClientInstanceName="_dx" ID="chkReminder" runat="server"> 
                                        <ClientSideEvents CheckedChanged="function(s, e) { OnChkReminderCheckedChanged(s, e); }" />
                                    </dxe:ASPxCheckBox>
                                </td>
                                <td style="padding-left: 2px;">
                                    <dxe:ASPxLabel ID="lblReminder" runat="server" AssociatedControlID="chkReminder" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="dxscControlCell" style="padding-left: 3px">
                        <dxe:ASPxComboBox  ID="cbReminder" ClientInstanceName="_dxAppointmentForm_cbReminder" runat="server" Width="100%" DataSource='<%# ((AppointmentFormTemplateContainer)Container).ReminderDataSource %>' />
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
                        
<table>
    <tr>
        <td  class="dxscDoubleCell" colspan="2">
            <dxe:ASPxCheckBox ID="chkRecurrence" runat="server" Checked='<%# ((AppointmentFormTemplateContainer)Container).Appointment.IsRecurring %>'>
                <ClientSideEvents CheckedChanged="function(s,e) { if (s.GetChecked()) { if (RecurrencePanel.mainElement.innerHTML.replace(/^\s*(\b.*\b|)\s*$/, '') == '') RecurrencePanel.PerformCallback(); else RecurrencePanel.SetVisible(true); } else RecurrencePanel.SetVisible(false); }" 
                />
            </dxe:ASPxCheckBox>
            <dxcp:ASPxCallbackPanel ID="RecurrencePanel" runat="server" Width="100%" ClientInstanceName="RecurrencePanel"
                OnCallback="OnCallback">
            </dxcp:ASPxCallbackPanel>
        </td>
    </tr>
</table>
                   
<table <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 35px;">
    <tr>
        <td class="dx-ac" style="width: 100%; height: 100%;" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "center", null) %>>
            <table class="dxscButtonTable" style="height: 100%">
                <tr>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnOk" UseSubmitBehavior="false" AutoPostBack="false" 
                            EnableViewState="false" Width="91px"/>
                    </td>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnCancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" 
                            Width="91px" CausesValidation="False" />
                    </td>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnDelete" UseSubmitBehavior="false"
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
        <td class="dx-al" style="width: 100%;" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "left", null) %>>
            <dxsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" MasterControlId='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).ControlId %>' />
        </td>
    </tr>
</table>
<script id="dxss_ASPxSchedulerAppoinmentForm" type="text/javascript">
    function OnChkReminderCheckedChanged(s, e) {
        var isReminderEnabled = s.GetValue();
        if (isReminderEnabled)
            _dxAppointmentForm_cbReminder.SetSelectedIndex(3);
        else
            _dxAppointmentForm_cbReminder.SetSelectedIndex(-1);
            
        _dxAppointmentForm_cbReminder.SetEnabled(isReminderEnabled);
        
    }
</script>