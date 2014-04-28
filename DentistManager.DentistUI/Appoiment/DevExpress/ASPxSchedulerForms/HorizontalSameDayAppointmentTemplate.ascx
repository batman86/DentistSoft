<%--
{************************************************************************************}
{                                                                                    }
{   This file contains the default template and is required for the appointment      }
{   rendering. Improper modifications may result in incorrect appearance of the      }
{   appointment.                                                                     }
{                                                                                    }
{   In order to create and use your own custom template, perform the following       }
{   steps:                                                                           }
{       1. Save a copy of this file with a different name in another location.       }
{       2. Add a Register tag in the .aspx page header for each template you use,    }
{          as follows: <%@ Register Src="PathToTemplateFile" TagName="NameOfTemplate"}
{          TagPrefix="ShortNameOfTemplate" %>                                        }
{       3. In the .aspx page find the tags for different scheduler views within      }
{          the ASPxScheduler control tag. Insert template tags into the tags         }
{          for the views which should be customized.                                 }
{          The template tag should satisfy the following pattern:                    }
{          <Templates>                                                               }
{              <HorizontalSameDayAppointmentTemplate>                                }
{                  <ShortNameOfTemplate: NameOfTemplate runat="server"/>             }
{              </HorizontalSameDayAppointmentTemplate>                               }
{          </Templates>                                                              }
{          where ShortNameOfTemplate, NameOfTemplate are the names of the            }
{          registered templates, defined in step 2.                                  }
{************************************************************************************}
--%>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="HorizontalSameDayAppointmentTemplate" Codebehind="HorizontalSameDayAppointmentTemplate.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<div id="appointmentDiv" runat="server" class='<%#((HorizontalAppointmentTemplateContainer)Container).Items.AppointmentStyle.CssClass %>'>
    <table <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%">
        <tr>
            <td runat="server" id="statusContainer" style="vertical-align: top">    
            </td>
        </tr>
        <tr>
            <td>
                <table <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 1, 0) %> style="width: 100%">
                    <tr class="dx-al" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "left", "middle") %> style="vertical-align: middle;">
                        <td runat="server" id="startTimeClockContainer" class="dxscCellWithPadding"> 
                        </td>
                        <td class="dxscCellWithPadding">
                            <dxe:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblStartTime" Text='<%#((HorizontalAppointmentTemplateContainer)Container).Items.StartTimeText.Text%>' Visible='<%#((HorizontalAppointmentTemplateContainer)Container).Items.StartTimeText.Visible%>'></dxe:ASPxLabel>            
                        </td>
                        <td runat="server" id="endTimeClockContainer" class="dxscCellWithPadding">
                        </td>
                        <td class="dxscCellWithPadding">
                            <dxe:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblEndTime" Text='<%#((HorizontalAppointmentTemplateContainer)Container).Items.EndTimeText.Text%>' Visible='<%#((HorizontalAppointmentTemplateContainer)Container).Items.EndTimeText.Visible%>'></dxe:ASPxLabel>
                        </td>
                        <td class="dxscCellWithPadding">
                            <table id="imageContainer" runat="server" style="vertical-align: middle;">                            
                            </table>
                        </td>
                        <td class="dxscCellWithPadding" style="width: 100%">
                            <dxe:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblTitle" Text='<%#((HorizontalAppointmentTemplateContainer)Container).AppointmentViewInfo.Appointment.CustomFields["Text"]%>'> </dxe:ASPxLabel>            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>