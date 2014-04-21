<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PatientStatus.aspx.cs" Inherits="DentistManager.DentistUI.Admin.PatientStatus" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <dx:ASPxGridView ID="gvxAppoiments" runat="server" AutoGenerateColumns="False" DataSourceID="dsAppoiment" EnableTheming="True" KeyFieldName="AppointmentID" Theme="RedWine">
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="AppointmentID" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Doctors" FieldName="DoctorID" VisibleIndex="2">
                            <PropertiesComboBox DataSourceID="dsDoctors" TextField="Name" ValueField="DoctorID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Patients" FieldName="PatientID" VisibleIndex="3">
                            <PropertiesComboBox DataSourceID="dsPatient" TextField="Name" ValueField="PatientID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Reason" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Clinic" FieldName="ClinicID" VisibleIndex="5">
                            <PropertiesComboBox DataSourceID="dsClinic" TextField="Name" ValueField="ClinicID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="Status" VisibleIndex="6">
                            <PropertiesComboBox>
                                <Items>
                                    <dx:ListEditItem Text="Waiting" Value="Waiting" />
                                    <dx:ListEditItem Text="Postponed" Value="Postponed" />
                                    <dx:ListEditItem Text="Progress" Value="Progress" />
                                    <dx:ListEditItem Text="Finished" Value="Finished" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataDateColumn FieldName="Start_date" VisibleIndex="7">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="End_date" VisibleIndex="8">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Text" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsAppoiment" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT * FROM [Appointments]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsDoctors" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [DoctorID], [Name] FROM [Doctors]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsPatient" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [PatientID], [Name] FROM [Patients]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsClinic" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [ClinicID], [Name] FROM [Clinics]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
