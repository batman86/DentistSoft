<%--
{****************************************************************************************}
{    This file contains the default selection tooltip template. The changes will affect  }
{    the default selection tooltip of the ASPxScheduler in your web project.             }
{    The file location is specified in the 'OptionsToolTips.SelectionToolTipUrl' property}
{    of the ASPxScheduler control.                                                       }
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the 'OptionsToolTips.SelectionToolTipUrl'        }
{          property of the ASPxScheduler control.                                        }
{       3. Perform required modifications.                                               }
{                                                                                        }
{        You can learn more about this online at:                                        }
{        http://documentation.devexpress.com/#AspNet/CustomDocument9591                  }
{                                                                                        }
{****************************************************************************************}
--%>

<%@ Control Language="C#" AutoEventWireup="true" Inherits="SelectionToolTip" Codebehind="SelectionToolTip.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<div runat="server" id="buttonDiv">
    <dxe:ASPxButton ID="btnShowMenu" runat="server" AutoPostBack="False" AllowFocus="False">
        <Border BorderWidth="0px" />
        <Paddings Padding="0px" />
        <FocusRectPaddings Padding="4px" />
        <FocusRectBorder BorderStyle="None" BorderWidth="0px" />
    </dxe:ASPxButton>
</div>