<%--
{****************************************************************************************}
{    This file contains the default dialog template. The changes will affect the default }
{    dialog of the ASPxScheduler in your web project.                                    }
{    The file location is specified in the 'OptionsForms.RemindersFormTemplateUrl'       }
{    property of the ASPxScheduler control.                                              }
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the 'OptionsForms.RemindersFormTemplateUrl'      }
{          property of the ASPxScheduler control.                                        }
{       3. Perform required modifications.                                               }
{                                                                                        }
{       You can learn more about this online at:                                         }
{       http://documentation.devexpress.com/#AspNet/CustomDocument9591                   }
{                                                                                        }
{****************************************************************************************}
--%>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="ReminderForm" Codebehind="ReminderForm.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<table class="dxscBorderSpacing" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width:100%; padding-bottom:15px;">
    <tr><td> 
         <dxe:ASPxListBox ID="lbItems" runat="server" Width="100%" style="padding-bottom:15px;"></dxe:ASPxListBox>
    </td></tr>
</table>
<table class="dxscButtonTable" style="width: 100%" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
    <tr>
        <td style="width:100%;"><dxe:ASPxButton ID="btnDismissAll" runat="server" AutoPostBack="false"></dxe:ASPxButton></td>
        <td class="dx-ar" style="width:80px;" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "right", null) %>>
            <dxe:ASPxButton ID="btnDismiss" runat="server" Width="80px" AutoPostBack="false"></dxe:ASPxButton></td>
    </tr>
    <tr>
        <td colspan="2" style="padding:8px 0 4px 0;"><dxe:ASPxLabel ID="lblClickSnooze" runat="server"></dxe:ASPxLabel></td>
    </tr>
    <tr>
        <td style="width:100%;padding-right:20px;"><dxe:ASPxComboBox ID="cbSnooze" runat="server" Width="100%">
        </dxe:ASPxComboBox></td>
        <td style="width:80px;"><dxe:ASPxButton ID="btnSnooze" runat="server" Width="80px" AutoPostBack="false"></dxe:ASPxButton></td>
    </tr>
</table>





