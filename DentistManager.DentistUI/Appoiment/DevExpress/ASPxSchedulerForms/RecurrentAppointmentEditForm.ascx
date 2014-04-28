<%--
{****************************************************************************************}
{    This file contains the default dialog template. The changes will affect the default }
{    dialog of the ASPxScheduler in your web project.                                    }
{    The file location is specified in the                                               }
{    'OptionsForms.RecurrentAppointmentEditFormTemplateUrl' property of the ASPxScheduler}
{    control.                                                                            } 
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the                                              }
{          'OptionsForms.RecurrentAppointmentEditFormTemplateUrl' property of the        }
{          ASPxScheduler control.                                                        }
{       3. Perform required modifications.                                               }
{                                                                                        }
{       You can learn more about this online at:                                         }
{       http://documentation.devexpress.com/#AspNet/CustomDocument9591                   }
{                                                                                        }
{****************************************************************************************}
--%>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="RecurrentAppointmentEditForm" Codebehind="RecurrentAppointmentEditForm.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<table style="width:100%; height:100%">
    <tr>
        <td rowspan="2"  style="vertical-align:top;">
            <dxe:ASPxImage id="Image" runat="server" EnableViewState="False" Width="48px" Height="48px" IsPng="true">
            </dxe:ASPxImage>
        </td>
        <td style="width:100%;">
            <dxe:ASPxLabel ID="lblConfirm" runat="server"/>
        </td>
    </tr>
    <tr>
        <td style="width:100%;">
            <dxe:ASPxRadioButtonList ID="rbAction" runat="server" ValueType="System.Int32">
                                <Border BorderStyle="None" />
                                <Items>
                                    <dxe:ListEditItem Value="1" />
                                    <dxe:ListEditItem Value="2" />
                                </Items>
                            </dxe:ASPxRadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="dx-ac" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "center", null) %> style="width:100%" colspan="2">
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
