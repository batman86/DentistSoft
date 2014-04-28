<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAppForm.ascx.cs" Inherits="DentistManager.DentistUI.Appoiment.UserAppoiment.UserAppForm" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxsc" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>
<style type="text/css">
    .auto-style1 {
        width: 239px;
    }
    .auto-style2 {
        height: 30px;
    }
    .auto-style4 {
        width: 239px;
        height: 43px;
    }
    .auto-style5 {
        height: 43px;
    }
    .auto-style6 {
        width: 239px;
        height: 38px;
    }
    .auto-style7 {
        height: 38px;
    }
    .auto-style9 {
        width: 214px;
    }
    .auto-style10 {
        width: 146px;
    }
</style>

<div runat="server" id="ValidationContainer">
    <table class="dxscAppointmentForm" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 230px;">
    <tr>
        <td class="auto-style2" colspan="2">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                   
                        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Font-Size="Medium" Text="Patient :">
                        </dxe:ASPxLabel>
                   
                    </td>
                    <td class="dxscControlCell">
                        
                        <dxe:ASPxComboBox ID="cbPatients" runat="server" DataSourceID="dsPatients"  TextField="Name" ValueField="PatientID" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" OnDataBound="cbPatients_DataBound">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dxe:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr> 
        <td class="auto-style1">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                   
                        <dxe:ASPxLabel ID="lblDoctor" runat="server" Font-Size="Medium" Text="Doctor :">
                        </dxe:ASPxLabel>
                   
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxComboBox ID="cbDoctors" runat="server" DataSourceID="dsDoctors" TextField="Name" ValueField="DoctorID" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dxe:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td style=" width:300px;">
                   
                        <table style="width:200px !important">
                            <tr style="width:200px">
                                <td style="width:100px">
                        <dxe:ASPxLabel ID="lblClinic" runat="server" Font-Size="Medium" Text="Clinic">
                        </dxe:ASPxLabel>
                   
                                </td>
                                <td><dxe:ASPxComboBox ID="cbClinics" runat="server" DataSourceID="dsClinics" TextField="Name" ValueField="ClinicID" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" style="margin-left: 12px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dxe:ASPxComboBox>
                                </td>
                            </tr>
                        </table>
                   
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                        <dxe:ASPxLabel ID="lblStartDate" runat="server" AssociatedControlID="edtStartDate" Wrap="false">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxDateEdit ID="edtStartDate" runat="server" Width="100%" Date='<%# ((AppointmentFormTemplateContainer)Container).Start %>' EditFormat="DateTime" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" >
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
            </table>
        </td>
        <td class="auto-style5">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dxe:ASPxLabel runat="server" ID="lblEndDate" Wrap="false" AssociatedControlID="edtEndDate"/>
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxDateEdit id="edtEndDate" runat="server" Date='<%# ((AppointmentFormTemplateContainer)Container).End %>' EditFormat="DateTime" Width="100%" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                   
                        <dxe:ASPxLabel ID="lblStatus" runat="server" Font-Size="Medium" Text="Status :">
                        </dxe:ASPxLabel>
                   
                    </td>
                    <td class="dxscControlCell">
                        <dxe:ASPxComboBox ID="cbStatus" runat="server" TextField="Name" ValueField="DoctorID" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" EnableIncrementalFiltering="True" SelectedIndex="0">
                            <Items>
                                <dxe:ListEditItem Selected="True" Text="Reserved" Value="Reserved" />
                                <dxe:ListEditItem Text="waiting" Value="waiting" />
                                <dxe:ListEditItem Text="InProgress" Value="InProgress" />
                                <dxe:ListEditItem Text="Finished" Value="Finished" />
                                <dxe:ListEditItem Text="Postponed" Value="Postponed" />
                            </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dxe:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
        <td class="auto-style7" style="padding-left: 22px;">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td style="width: 20px; height: 20px;">
                        &nbsp;</td>
                    <td style="padding-left: 2px;">
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <% if(CanShowReminders) { %>
        <td class="auto-style1">
            <% } else { %>
        <td class="dxscDoubleCell" colspan="2">
            <% } %>
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell">
                        &nbsp;</td>
                    <td class="dxscControlCell">
                        <% if(ResourceSharing) { %><% } else { %><% } %>             
                    </td>

                </tr>
            </table>
        </td>
        <% if(CanShowReminders) { %>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 22px;">
                        <table class="dxscLabelControlPair" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %>>
                            <tr>
                                <td style="width: 20px; height: 20px;">
                                    &nbsp;</td>
                                <td style="padding-left: 2px;">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td class="dxscControlCell" style="padding-left: 3px">
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <% } %>
    </tr>
    <tr>
        <td class="dxscDoubleCell" colspan="2" style="height: 90px;">
            <dxe:ASPxMemo ClientInstanceName="_dx" ID="tbDescription" runat="server" Width="100%" Rows="6" Text='<%# ((AppointmentFormTemplateContainer)Container).Appointment.CustomFields["Text"] %>' >
                <ValidationSettings>
                    <RequiredField IsRequired="True" />
                </ValidationSettings>
            </dxe:ASPxMemo>
        </td>
    </tr>
</table>
</div>
                        
<dxsc:AppointmentRecurrenceForm ID="AppointmentRecurrenceForm1" runat="server"
    IsRecurring='<%# ((AppointmentFormTemplateContainer)Container).Appointment.IsRecurring %>' 
    DayNumber='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceDayNumber %>' 
    End='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceEnd %>' 
    Month='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceMonth %>' 
    OccurrenceCount='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceOccurrenceCount %>' 
    Periodicity='<%# ((AppointmentFormTemplateContainer)Container).RecurrencePeriodicity %>' 
    RecurrenceRange='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceRange %>' 
    Start='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceStart %>' 
    WeekDays='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceWeekDays %>' 
    WeekOfMonth='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceWeekOfMonth %>' 
    RecurrenceType='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceType %>'
    IsFormRecreated='<%# ((AppointmentFormTemplateContainer)Container).IsFormRecreated %>' >
</dxsc:AppointmentRecurrenceForm>
                   
<table <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 35px;">
    <tr>
        <td class="dx-ac" style="width: 100%; height: 100%;" <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "center", null) %>>
            <table class="dxscButtonTable" style="height: 100%">
                <tr>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ID="btnOk" UseSubmitBehavior="false" AutoPostBack="false" 
                            EnableViewState="false" Width="91px" EnableClientSideAPI="true" Visible="False"/>
                        <dxe:ASPxButton ID="btnSave" runat="server" AutoPostBack="False" OnClick="btnSave_Click" Text="Save" Width="91px">
                        </dxe:ASPxButton>
                    </td>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ID="btnCancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" 
                            Width="91px" CausesValidation="False" EnableClientSideAPI="true" />
                    </td>
                    <td class="dxscCellWithPadding">
                        <dxe:ASPxButton runat="server" ID="btnDelete" UseSubmitBehavior="false"
                            AutoPostBack="false" EnableViewState="false" Width="91px"
                            Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanDeleteAppointment %>'
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%;">
    <tr>
        <td class="dx-al" style="width: 100%;"  <%= DevExpress.Web.ASPxClasses.Internal.RenderUtils.GetAlignAttributes(this, "left", null) %>>
            <dxsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" MasterControlId='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).ControlId %>' />
            <asp:SqlDataSource ID="dsDoctors" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [DoctorID], [Name] FROM [Doctors]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsPatients" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [PatientID], [Name] FROM [Patients]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsClinics" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [Name], [ClinicID] FROM [Clinics]"></asp:SqlDataSource>
        </td>
    </tr>
</table>
<script id="dxss_ASPxSchedulerAppoinmentForm" type="text/javascript">
    ASPxAppointmentForm = _aspxCreateClass(ASPxClientFormBase, {
        Initialize: function () {
            this.controls.edtStartDate.Validation.AddHandler(_aspxCreateDelegate(this.OnEdtStartDateValidate, this));
            this.controls.edtEndDate.Validation.AddHandler(_aspxCreateDelegate(this.OnEdtEndDateValidate, this));
            this.controls.edtStartDate.ValueChanged.AddHandler(_aspxCreateDelegate(this.OnUpdateStartEndValue, this));
            this.controls.edtEndDate.ValueChanged.AddHandler(_aspxCreateDelegate(this.OnUpdateStartEndValue, this));
            if (this.controls.chkReminder)
                this.controls.chkReminder.CheckedChanged.AddHandler(_aspxCreateDelegate(this.OnChkReminderCheckedChanged, this));
            if (this.controls.edtMultiResource)
                this.controls.edtMultiResource.SelectedIndexChanged.AddHandler(_aspxCreateDelegate(this.OnEdtMultiResourceSelectedIndexChanged, this));
        },
        OnEdtMultiResourceSelectedIndexChanged: function (s, e) {
            var resourceNames = new Array();
            var items = s.GetSelectedItems();
            var count = items.length;
            if (count > 0) {
                for (var i = 0; i < count; i++)
                    resourceNames.push(items[i].text);
            }
            else
                resourceNames.push(ddResource.cp_Caption_ResourceNone);
            ddResource.SetValue(resourceNames.join(', '));
        },
        OnEdtStartDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnEdtEndDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnUpdateStartEndValue: function (s, e) {
            var isValid = ASPxClientEdit.ValidateEditorsInContainer(null);
            this.controls.btnOk.SetEnabled(isValid);
        },
        OnChkReminderCheckedChanged: function (s, e) {
            var isReminderEnabled = this.controls.chkReminder.GetValue();
            if (isReminderEnabled)
                this.controls.cbReminder.SetSelectedIndex(3);
            else
                this.controls.cbReminder.SetSelectedIndex(-1);
            this.controls.cbReminder.SetEnabled(isReminderEnabled);
        }
    });
</script>