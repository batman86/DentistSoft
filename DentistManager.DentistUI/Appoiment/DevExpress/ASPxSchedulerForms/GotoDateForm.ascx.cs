/*
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
*/

using System;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Localization;

public partial class GotoDateForm : SchedulerFormControl {
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        Localize();
        //PrepareChildControls();
        edtDate.Focus();
    }
    void Localize() {
        lblDate.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Date);
        lblView.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ShowIn);
        btnOk.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonOk);
        btnCancel.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonCancel);
    }
    public override void DataBind() {
        base.DataBind();
        GotoDateFormTemplateContainer container = (GotoDateFormTemplateContainer)Parent;
        cbView.Value = container.ActiveViewType.ToString();

        btnOk.ClientSideEvents.Click = container.ApplyHandler;
        btnCancel.ClientSideEvents.Click = container.CancelHandler;

        ASPxScheduler scheduler = container.Control;
        string actualSchedulerInstanceName = scheduler.ClientInstanceName;
        if(String.IsNullOrEmpty(actualSchedulerInstanceName))
            actualSchedulerInstanceName = scheduler.ClientID;
        edtDate.ClientSideEvents.LostFocus = String.Format(@"function(s,e) {{
                var date = s.GetDate();
                if (date == null || date == false) {{
                    var selectionInterval = {0}.GetSelectedInterval();
                    var startDate = selectionInterval.GetStart();
                    s.SetDate(startDate);
                }}
            }}", actualSchedulerInstanceName);
    }
    protected override ASPxEditBase[] GetChildEditors() {
        ASPxEditBase[] edits = new ASPxEditBase[] {
            lblDate, edtDate,
            lblView, cbView
        };
        return edits;
    }
    protected override ASPxButton[] GetChildButtons() {
        ASPxButton[] buttons = new ASPxButton[] {
            btnOk, btnCancel
        };
        return buttons;
    }
}