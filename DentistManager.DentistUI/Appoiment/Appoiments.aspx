<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appoiments.aspx.cs" Inherits="DentistManager.DentistUI.Appoiment.Appoiments" %>
<%@ Register Src="~/Appoiment/DevExpress/ASPxSchedulerForms/VerticalAppointmentTemplate.ascx" TagName="VerticalAppointment" TagPrefix="va" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%
            ;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr style="vertical-align: top">
                <td>
                    <dx:ASPxButton ID="btnGoBack" runat="server" OnClick="btnGoBack_Click" Text="Go Back " Theme="RedWine">
                    </dx:ASPxButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="vertical-align: top">
                <td>
                    <dx:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="dsAppoiments" 
                        ClientIDMode="AutoID" Start="2014-04-18" Theme="RedWine">
                        <Storage>
                            <Appointments AutoRetrieveId="True">
                                <Mappings AppointmentId="AppointmentID" End="End_date" Start="Start_date" />
                                <CustomFieldMappings>
                                    <dx:ASPxAppointmentCustomFieldMapping Member="ClinicID" Name="ClinicID" />
                                    <dx:ASPxAppointmentCustomFieldMapping Member="DoctorID" Name="DoctorID" />
                                    <dx:ASPxAppointmentCustomFieldMapping Member="PatientID" Name="PatientID" />
                                    <dx:ASPxAppointmentCustomFieldMapping Member="Reason" Name="Reason" />
                                    <dx:ASPxAppointmentCustomFieldMapping Member="Status" Name="Status" />
                                    <dx:ASPxAppointmentCustomFieldMapping Member="Text" Name="Text" />
                                </CustomFieldMappings>
                            </Appointments>
                        </Storage>
                        <Views>
<DayView><TimeRulers>
<dx:TimeRuler></dx:TimeRuler>
</TimeRulers>
     <Templates>
        <VerticalAppointmentTemplate>
             <va:VerticalAppointment ID="VerticalAppointment1" runat="server"/>
        </VerticalAppointmentTemplate>
    </Templates>
</DayView>

<WorkWeekView><TimeRulers>
<dx:TimeRuler></dx:TimeRuler>
</TimeRulers>
    <Templates>
        <VerticalAppointmentTemplate>
             <va:VerticalAppointment ID="VerticalAppointment2" runat="server"/>
        </VerticalAppointmentTemplate>
    </Templates>
</WorkWeekView>
    <TimelineView Enabled="False">
    </TimelineView>
</Views>

                        <OptionsCustomization AllowInplaceEditor="None" />
                        <OptionsBehavior ShowRemindersForm="False" />
                        <OptionsForms AppointmentFormTemplateUrl="~/Appoiment/UserAppoiment/UserAppForm.ascx" GotoDateFormTemplateUrl="~/Appoiment/DevExpress/ASPxSchedulerForms/GotoDateForm.ascx" RecurrentAppointmentDeleteFormTemplateUrl="~/Appoiment/DevExpress/ASPxSchedulerForms/RecurrentAppointmentDeleteForm.ascx" RecurrentAppointmentEditFormTemplateUrl="~/Appoiment/DevExpress/ASPxSchedulerForms/RecurrentAppointmentEditForm.ascx" RemindersFormTemplateUrl="~/Appoiment/DevExpress/ASPxSchedulerForms/ReminderForm.ascx" />
                        <OptionsToolTips AppointmentDragToolTipUrl="~/Appoiment/DevExpress/ASPxSchedulerForms/AppointmentDragToolTip.ascx" AppointmentToolTipUrl="~/Appoiment/DevExpress/ASPxSchedulerForms/AppointmentToolTip.ascx" SelectionToolTipUrl="~/Appoiment/DevExpress/ASPxSchedulerForms/SelectionToolTip.ascx" />
                    </dx:ASPxScheduler>
    
                </td>
                <td>
    
                    <dx:ASPxDateNavigator ID="ASPxDateNavigator1" runat="server" ClientIDMode="AutoID" MasterControlID="ASPxScheduler1">
                        <Properties Rows="4">
                        </Properties>
                    </dx:ASPxDateNavigator>
                    </td>
            </tr>
        </table>
    
    </div>
                    <asp:SqlDataSource ID="dsAppoiments" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [Appointments] WHERE [AppointmentID] = @AppointmentID" InsertCommand="INSERT INTO [Appointments] ([DoctorID], [PatientID], [Reason], [ClinicID], [Status], [Start_date], [End_date], [Text]) VALUES (@DoctorID, @PatientID, @Reason, @ClinicID, @Status, @Start_date, @End_date, @Text)" SelectCommand="SELECT * FROM [Appointments] where ClinicID =@ClinicID" UpdateCommand="UPDATE [Appointments] SET   [Start_date] = @Start_date, [End_date] = @End_date
 WHERE [AppointmentID] = @AppointmentID">
                        <DeleteParameters>
                            <asp:Parameter Name="AppointmentID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="DoctorID" Type="Int32" />
                            <asp:Parameter Name="PatientID" Type="Int32" />
                            <asp:Parameter Name="Reason" Type="String" />
                            <asp:Parameter Name="ClinicID" Type="Int32" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="Start_date" Type="DateTime" />
                            <asp:Parameter Name="End_date" Type="DateTime" />
                            <asp:Parameter Name="Text" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter Name="ClinicID" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Start_date" Type="DateTime" />
                            <asp:Parameter Name="End_date" Type="DateTime" />
                            <asp:Parameter Name="AppointmentID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
    </form>
</body>
</html>
