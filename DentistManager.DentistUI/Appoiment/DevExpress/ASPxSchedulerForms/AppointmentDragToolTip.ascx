<%--
{*****************************************************************************************}
{    This file contains the default appointment drag tooltip template. The changes will   }
{    affect the default appointment drag tooltip of the ASPxScheduler in your web project.}
{    The file location is specified in the 'OptionsToolTips.AppointmentDragToolTipUrl'    }
{    property of the ASPxScheduler control.                                               }
{                                                                                         }
{    To modify a default template, perform the following steps:                           }
{       1. Save a copy of this file in another location to prevent accidental deletion.   }
{       2. Specify new file location in the 'OptionsToolTips.AppointmentDragToolTipUrl'   }
{          property of the ASPxScheduler control.                                         }
{       3. Perform required modifications.                                                }
{                                                                                         }
{        You can learn more about this online at:                                         }
{        http://documentation.devexpress.com/#AspNet/CustomDocument9591                   }
{                                                                                         }
{*****************************************************************************************}
--%>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="AppointmentDragToolTip" Codebehind="AppointmentDragToolTip.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<div style="white-space:nowrap;">
    <dxe:ASPxLabel ID="lblInterval" runat="server" Text="CustomDragAppointmentTooltip" EnableClientSideAPI="true">
        </dxe:ASPxLabel>
    <br />
    
    <dxe:ASPxLabel ID="lblInfo" runat="server" EnableClientSideAPI="true"></dxe:ASPxLabel>
</div>

<script id="dxss_ASPxClientAppointmentDragTooltip" type="text/javascript"><!--
    ASPxClientAppointmentDragTooltip = _aspxCreateClass(ASPxClientToolTipBase, {
        CalculatePosition: function(bounds) {
            return new ASPxClientPoint(bounds.GetLeft(), bounds.GetTop() - bounds.GetHeight());
        },
        Update: function (toolTipData) {
            var stringInterval = this.GetToolTipContent(toolTipData);
            var oldText = this.controls.lblInterval.GetText();
            if (oldText != stringInterval)
                this.controls.lblInterval.SetText(stringInterval);
        },
        GetToolTipContent: function(toolTipData) {	
            var interval = toolTipData.GetInterval();
            return this.ConvertIntervalToString(interval);
        }
    });
//--></script>