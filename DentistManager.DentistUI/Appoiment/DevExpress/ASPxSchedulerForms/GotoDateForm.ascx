<%--
{****************************************************************************************}
{    This file contains the default dialog template. The changes will affect the default }
{    dialog of the ASPxScheduler in your web project.                                    }
{    The file location is specified in the 'OptionsForms.GotoDateFormTemplateUrl'        }
{    property of the ASPxScheduler control.                                              }
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the 'OptionsForms.GotoDateFormTemplateUrl'       }
{          property of the ASPxScheduler control.                                        }
{       3. Perform required modifications.                                               }
{                                                                                        }
{       You can learn more about this online at:                                         }
{       http://documentation.devexpress.com/#AspNet/CustomDocument9591                   }
{                                                                                        }
{****************************************************************************************}
--%>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="GotoDateForm" Codebehind="GotoDateForm.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
    <%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<table class="dxscBorderSpacing" style="width:100%; height:100%">
    <tr>
        <td class="dxscCellWithPadding">
            <dxe:ASPxLabel ID="lblDate" runat="server" AssociatedControlID="edtDate" />
        </td>
        <td class="dxscCellWithPadding" style="width:100%">
            <dxe:ASPxDateEdit ClientInstanceName="_dx" ID="edtDate" runat="server" Width="100%" Date='<%#((GotoDateFormTemplateContainer)Container).Date %>' />
        </td> 
    </tr>
    <tr>
        <td class="dxscCellWithPadding">
            <span style="white-space: nowrap;">
            <dxe:ASPxLabel ID="lblView" runat="server" AssociatedControlID="cbView"></dxe:ASPxLabel>
            </span>
        </td>
        <td class="dxscCellWithPadding" style="width:100%">
            <dxe:ASPxComboBox ClientInstanceName="_dx" ID="cbView" runat="server" Width="100%" DataSource='<%#((GotoDateFormTemplateContainer)Container).ViewsDataSource %>'></dxe:ASPxComboBox>
        </td>
    </tr>
    <tr>
        <td class="dx-ac dxscCellWithPadding" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "center", null) %> colspan="2" style="width: 100%">
            <table class="dxscButtonTable">
                <tr>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton ID="btnOk" ClientInstanceName="_dx" runat="server" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" Width="91px" />
                    </td>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton ID="btnCancel" ClientInstanceName="_dx" runat="server" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" 
                            Width="91px" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>    


