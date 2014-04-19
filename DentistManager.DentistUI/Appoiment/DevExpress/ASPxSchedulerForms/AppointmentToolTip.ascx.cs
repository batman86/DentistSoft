/*
{****************************************************************************************}
{    This file contains the default appointment tooltip template. The changes will affect}
{    the default appointment tooltip of the ASPxScheduler in your web project.           }
{    The file location is specified in the 'OptionsToolTips.AppointmentToolTipUrl'       }
{    property of the ASPxScheduler control.                                              }
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the 'OptionsToolTips.AppointmentToolTipUrl'      }
{          property of the ASPxScheduler control.                                        }
{       3. Perform required modifications.                                               }
{                                                                                        }
{        You can learn more about this online at:                                        }
{        http://documentation.devexpress.com/#AspNet/CustomDocument9591                  }
{                                                                                        }
{****************************************************************************************}
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

public partial class AppointmentToolTip : ASPxSchedulerToolTipBase {
    public override bool ToolTipShowStem { get { return false; } }
    public override string ClassName { get { return "ASPxClientAppointmentToolTip"; } }

    protected void Page_Load(object sender, EventArgs e) {
        //DevExpress.Web.ASPxClasses.ASPxWebControl.RegisterBaseScript(Page);
    }
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        btnShowMenu.Image.Assign(GetSmartTagImage());
    }
    protected override Control[] GetChildControls() {
        Control[] controls = new Control[] { buttonDiv};
        return controls;
    }
}
