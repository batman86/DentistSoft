/*
{****************************************************************************************}
{    This file contains the default dialog template. The changes will affect the default }
{    dialog of the ASPxScheduler in your web project.                                    }
{    The file location is specified in the                                               }
{    'OptionsForms.RecurrentAppointmentDeleteFormTemplateUrl' property of the            }
{    ASPxScheduler control.                                                              }
{                                                                                        }
{    To modify a default template, perform the following steps:                          }
{       1. Save a copy of this file in another location to prevent accidental deletion.  }
{       2. Specify new file location in the                                              }
{          'OptionsForms.RecurrentAppointmentDeleteFormTemplateUrl' property of the      }
{          ASPxScheduler control.                                                        }
{       3. Perform required modifications.                                               }
{                                                                                        }
{       You can learn more about this online at:                                         }
{       http://documentation.devexpress.com/#AspNet/CustomDocument9591                   }
{                                                                                        }
{****************************************************************************************}
*/

using System;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxScheduler.Localization;

public partial class RecurrentAppointmentDeleteForm : SchedulerFormControl {
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        Localize();
    }
    public override void DataBind() {
        base.DataBind();
        RecurrentAppointmentDeleteFormTemplateContainer container = (RecurrentAppointmentDeleteFormTemplateContainer)Parent;
        rbAction.SelectedIndex = 0;
        Localize(container);
        ImageProperties imageProperties = container.Control.Images.GetWarningImage(this.Page);
        AssignImageProperties(imgWarning, imageProperties);
        btnOk.ClientSideEvents.Click = container.ApplyHandler;
        btnCancel.ClientSideEvents.Click = container.CancelHandler;
    }
    void Localize() {
        btnOk.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonOk);
        btnCancel.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonCancel);

        if (rbAction.Items.Count == 2) {
            ListEditItem seriesItem = rbAction.Items[0];
            seriesItem.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Series);
            ListEditItem occurrenceItem = rbAction.Items[1];
            occurrenceItem.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Occurrence);
        }
    }
    void Localize(RecurrentAppointmentDeleteFormTemplateContainer container) {
        string formatString = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ConfirmDelete);
        lblConfirm.Text = String.Format(formatString, container.Appointment.Subject);
    }
    void AssignImageProperties(ASPxImage image, ImageProperties imageProperties) {
        image.ImageUrl = EmptyImageProperties.GetGlobalEmptyImage(this.Page).Url;
        image.CssClass = imageProperties.SpriteProperties.CssClass;
        image.Width = imageProperties.Width;
        image.Height = imageProperties.Height;
        image.SpriteLeft = imageProperties.SpriteProperties.Left;
        image.SpriteTop = imageProperties.SpriteProperties.Top;
    }
    protected override ASPxEditBase[] GetChildEditors() {
        ASPxEditBase[] edits = new ASPxEditBase[] { lblConfirm, rbAction };
        return edits;
    }
    protected override ASPxButton[] GetChildButtons() {
        ASPxButton[] buttons = new ASPxButton[] {
            btnOk, btnCancel
        };
        return buttons;
    }
}
