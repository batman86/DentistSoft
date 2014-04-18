<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appoiments.aspx.cs" Inherits="DentistManager.DentistUI.Appoiment.Appoiments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 800px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr style="vertical-align: top">
                <td>
                    <dx:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="dsAppoiments" ClientIDMode="AutoID" Start="2014-04-18" Theme="PlasticBlue">
                    </dx:ASPxScheduler>
                    <asp:SqlDataSource ID="dsAppoiments" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [Appointments] WHERE [AppointmentID] = @AppointmentID" InsertCommand="INSERT INTO [Appointments] ([DoctorID], [PatientID], [Reason], [ClinicID], [Status], [Start_date], [End_date], [Text]) VALUES (@DoctorID, @PatientID, @Reason, @ClinicID, @Status, @Start_date, @End_date, @Text)" SelectCommand="SELECT * FROM [Appointments]" UpdateCommand="UPDATE [Appointments] SET [DoctorID] = @DoctorID, [PatientID] = @PatientID, [Reason] = @Reason, [ClinicID] = @ClinicID, [Status] = @Status, [Start_date] = @Start_date, [End_date] = @End_date, [Text] = @Text WHERE [AppointmentID] = @AppointmentID">
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
                            <asp:Parameter Name="DoctorID" Type="Int32" />
                            <asp:Parameter Name="PatientID" Type="Int32" />
                            <asp:Parameter Name="Reason" Type="String" />
                            <asp:Parameter Name="ClinicID" Type="Int32" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="Start_date" Type="DateTime" />
                            <asp:Parameter Name="End_date" Type="DateTime" />
                            <asp:Parameter Name="Text" Type="String" />
                            <asp:Parameter Name="AppointmentID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <dx:ASPxDateNavigator ID="ASPxDateNavigator1" runat="server" ClientIDMode="AutoID" MasterControlID="ASPxScheduler1">
                    </dx:ASPxDateNavigator>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
