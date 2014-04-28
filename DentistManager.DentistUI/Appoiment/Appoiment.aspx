<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appoiment.aspx.cs" Inherits="DentistManager.DentistUI.Appoiment.Appoiment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1" style="vertical-align: top">
            <tr>
                <td>
                    <dx:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="dsAppoiments" ClientIDMode="AutoID" Start="2014-04-27" Theme="RedWine">
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
</DayView>

<WorkWeekView><TimeRulers>
<dx:TimeRuler></dx:TimeRuler>
</TimeRulers>
</WorkWeekView>
</Views>
                    </dx:ASPxScheduler>
                    <asp:SqlDataSource ID="dsAppoiments" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [Appointments] WHERE [AppointmentID] = @AppointmentID" InsertCommand="INSERT INTO [Appointments] ([DoctorID], [PatientID], [Reason], [ClinicID], [Status], [Start_date], [End_date], [Text]) VALUES (@DoctorID, @PatientID, @Reason, @ClinicID, @Status, @Start_date, @End_date, @Text)" SelectCommand="SELECT * FROM [Appointments]" UpdateCommand="UPDATE [Appointments] SET   [Start_date] = @Start_date, [End_date] = @End_date
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
                        <UpdateParameters>
                            <asp:Parameter Name="Start_date" Type="DateTime" />
                            <asp:Parameter Name="End_date" Type="DateTime" />
                            <asp:Parameter Name="AppointmentID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td style="vertical-align: top">
                    <dx:ASPxDateNavigator ID="ASPxDateNavigator1" runat="server" ClientIDMode="AutoID" MasterControlID="ASPxScheduler1">
                    </dx:ASPxDateNavigator>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
