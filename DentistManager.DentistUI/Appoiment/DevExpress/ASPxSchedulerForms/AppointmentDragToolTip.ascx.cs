/*
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
*/

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Localization;

public partial class AppointmentDragToolTip : ASPxSchedulerToolTipBase {
    public override string ClassName { get { return "ASPxClientAppointmentDragTooltip"; } }
    public override bool ToolTipShowStem { get { return true; } }

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        Localize();
        //DevExpress.Web.ASPxClasses.ASPxWebControl.RegisterBaseScript(Page);
    }
    void Localize() {
        lblInfo.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_OperationToolTip);
    }    
    protected override Control[] GetChildControls() {
        Control[] controls = new Control[] { lblInterval };
        return controls;
    }
}
