<%--
{****************************************************************************************}
{    This file contains the default dialog template. The changes will affect the default }
{    dialog of the ASPxScheduler in your web project.                                    }
{    The file location is specified in the                                               }
{    'OptionsForms.AppointmentInplaceEditorFormTemplateUrl' property of the ASPxScheduler} 
{    control.                                                                            }
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the                                              }
{         'OptionsForms.AppointmentInplaceEditorFormTemplateUrl' property of the         }
{          ASPxScheduler control.                                                        }
{       3. Perform required modifications.                                               }
{                                                                                        }
{       You can learn more about this online at:                                         }
{       http://documentation.devexpress.com/#AspNet/CustomDocument9591                   }
{                                                                                        }
{****************************************************************************************}
--%>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="InplaceEditor" Codebehind="InplaceEditor.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls"
    TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<table runat="server" id="mainContainer" style="width:100%; height:100%">
    <tr>
        <td class="dx-p2" style="width:100%">
            <dxe:ASPxMemo ClientInstanceName="_dx" ID="memSubject" runat="server" Width="100%" Rows="5" Text='<%# ((AppointmentInplaceEditorTemplateContainer)Container).Appointment.CustomFields["Text"] %>'>
            </dxe:ASPxMemo>
        </td>
        <td runat="server" id="buttonContainer" class="dx-p2" style="vertical-align: top">

        <div>
            <cc1:NoBorderButton runat="server" ClientInstanceName="_dx" ID="btnSave" Width="19px" Height="19px"  
                Image-IsResourcePng="True">
            </cc1:NoBorderButton> 
        </div>
        
        <div style="padding-top:1px;">
            <cc1:NoBorderButton runat="server" ClientInstanceName="_dx" ID="btnCancel" Width="19px" Height="19px"
                 Image-IsResourcePng="True">
            </cc1:NoBorderButton> 
        </div>

        <div style="padding-top:6px;">
            <cc1:NoBorderButton runat="server" ClientInstanceName="_dx" ID="btnEditForm" Width="19px" Height="19px"
                Image-IsResourcePng="True">
            </cc1:NoBorderButton>
        </div>
        </td>
    </tr>
</table>