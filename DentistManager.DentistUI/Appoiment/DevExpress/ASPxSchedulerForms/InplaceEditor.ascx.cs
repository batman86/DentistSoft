/*
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
*/

using System;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxScheduler.Localization;

public partial class InplaceEditor : InplaceEditorBaseFormControl {
	protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        PrepareMainContainer();
        Localize();
		memSubject.Focus();
    }
    void PrepareMainContainer() {
        RenderUtils.SetTableSpacings(mainContainer, 2, 0);
        RenderUtils.SetAlignAttributes(buttonContainer, null, "top");
    }
    void Localize() {
        btnSave.ToolTip = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Save);
        btnCancel.ToolTip = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonCancel);
        btnEditForm.ToolTip = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_OpenEditForm);
    }
	public override void DataBind() {
		base.DataBind();
		AppointmentInplaceEditorTemplateContainer container = (AppointmentInplaceEditorTemplateContainer)Parent;

        btnCancel.Image.Assign(container.Control.Images.GetInplaceEditorCancelImage(Page));
        btnSave.Image.Assign(container.Control.Images.GetInplaceEditorSaveImage(Page));
        btnEditForm.Image.Assign(container.Control.Images.GetInplaceEditorEditFormImage(Page));

		btnSave.ClientSideEvents.Click = container.SaveHandler;
		btnCancel.ClientSideEvents.Click = container.CancelHandler;
		btnEditForm.ClientSideEvents.Click = container.EditFormHandler;
	}
	protected override ASPxEditBase[] GetChildEditors() {
		ASPxEditBase[] edits = new ASPxEditBase[] { memSubject };
		return edits;
	}
	protected override ASPxButton[] GetChildButtons() {
		ASPxButton[] buttons = new ASPxButton[] {
			btnSave, btnCancel, btnEditForm
		};
		return buttons;
	}
}
