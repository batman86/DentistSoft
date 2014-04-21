<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PaymentByPeriod.aspx.cs" Inherits="DentistManager.DentistUI.Admin.PaymentByPeriod" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 800px;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td colspan="4">
                <table style="width: 800px">
                    <tr>
                        <td style="width: 49px">From :</td>
                        <td>
                            <dx:ASPxDateEdit ID="txtDateFrom" runat="server">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49px">To :</td>
                        <td>
                            <dx:ASPxDateEdit ID="txtDateTo" runat="server">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49px">&nbsp;</td>
                        <td>
                            <dx:ASPxButton ID="btnGet" runat="server" OnClick="btnGet_Click" Text="Get">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
&nbsp;</td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvxPaymentClinics" runat="server" AutoGenerateColumns="False" DataSourceID="dsClinis" EnableTheming="True" KeyFieldName="ClinicID" OnCustomUnboundColumnData="gvxPaymentClinics_CustomUnboundColumnData" Theme="RedWine" OnDataBound="gvxPaymentClinics_DataBound">
                    <TotalSummary>
                        <dx:ASPxSummaryItem SummaryType="Sum" />
                    </TotalSummary>
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="ClinicID" ReadOnly="True" Visible="False" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Clinics" FieldName="Name" VisibleIndex="2">
                            <PropertiesComboBox DataSourceID="dsClinis" TextField="Name" ValueField="ClinicID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Total Required" UnboundType="Decimal" VisibleIndex="3">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Total Payed" UnboundType="Decimal" VisibleIndex="4">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Total Deserved" UnboundType="Decimal" VisibleIndex="5">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                    <SettingsDetail ShowDetailRow="True" />
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="gvxDoctor" runat="server" AutoGenerateColumns="False" DataSourceID="dsDoctors" EnableTheming="True" KeyFieldName="DoctorID" OnBeforePerformDataSelect="gvxDoctor_BeforePerformDataSelect" OnCustomUnboundColumnData="gvxDoctor_CustomUnboundColumnData" OnDataBound="gvxDoctor_DataBound" Theme="RedWine">
                                <Columns>
                                    <dx:GridViewCommandColumn VisibleIndex="0">
                                        <ClearFilterButton Visible="True">
                                        </ClearFilterButton>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="DoctorID" ReadOnly="True" Visible="False" VisibleIndex="1">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="Doctor" FieldName="Name" VisibleIndex="2">
                                        <PropertiesComboBox DataSourceID="dsDoctors" TextField="Name" ValueField="DoctorID">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="Total Required" UnboundType="Decimal" VisibleIndex="3">
                                        <PropertiesSpinEdit DisplayFormatString="g">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="Total Payed" UnboundType="Decimal" VisibleIndex="4">
                                        <PropertiesSpinEdit DisplayFormatString="g">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="Total Deserved" UnboundType="Decimal" VisibleIndex="5">
                                        <PropertiesSpinEdit DisplayFormatString="g">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                </Columns>
                                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                                <SettingsDetail ShowDetailRow="True" />
                                <Templates>
                                    <DetailRow>
                                        <dx:ASPxGridView ID="gvxPatients" runat="server" AutoGenerateColumns="False" DataSourceID="dsPatients" EnableTheming="True" KeyFieldName="PatientID" OnBeforePerformDataSelect="gvxPatients_BeforePerformDataSelect" OnCustomUnboundColumnData="gvxPatients_CustomUnboundColumnData" OnDataBound="gvxPatients_DataBound" Theme="RedWine">
                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0">
                                                    <ClearFilterButton Visible="True">
                                                    </ClearFilterButton>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn FieldName="PatientID" ReadOnly="True" Visible="False" VisibleIndex="1">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataComboBoxColumn Caption="Patients" FieldName="Name" VisibleIndex="2">
                                                    <PropertiesComboBox DataSourceID="dsPatients" TextField="Name" ValueField="PatientID">
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Total Required" UnboundType="Decimal" VisibleIndex="3">
                                                    <PropertiesSpinEdit DisplayFormatString="g">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Total Payed" UnboundType="Decimal" VisibleIndex="4">
                                                    <PropertiesSpinEdit DisplayFormatString="g">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn FieldName="Total Deserved" UnboundType="Decimal" VisibleIndex="5">
                                                    <PropertiesSpinEdit DisplayFormatString="g">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataTextColumn Caption="Receipts" VisibleIndex="6">
                                                    <DataItemTemplate>
                                                        <dx:ASPxButton ID="btnReceipts" runat="server" OnClick="btnReceipts_Click" Text="Get Receipts">
                                                        </dx:ASPxButton>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Settings ShowFilterRow="True" ShowFooter="True" />
                                        </dx:ASPxGridView>
                                    </DetailRow>
                                </Templates>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsClinis" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [ClinicID], [Name] FROM [Clinics]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsDoctors" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [DoctorID], [Name] FROM [Doctors] WHERE ([ClinicID] = @ClinicID)">
                    <SelectParameters>
                        <asp:Parameter Name="ClinicID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsPatients" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [PatientID], [Name] FROM [Patients] WHERE (([ClinicID] = @ClinicID) AND ([DoctorID] = @DoctorID))">
                    <SelectParameters>
                        <asp:Parameter Name="ClinicID" Type="Int32" />
                        <asp:Parameter Name="DoctorID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                <dx:ASPxPopupControl ID="popupReceipts" runat="server" RenderMode="Lightweight" Theme="RedWine" HeaderText="Patien Receipts">
                    <ContentCollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxGridView ID="gvReceipts" runat="server" AutoGenerateColumns="False" DataSourceID="dsReceipts" EnableTheming="True" KeyFieldName="ReceiptID" Theme="RedWine">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="ReceiptID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="0">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="Date" ShowInCustomizationForm="True" VisibleIndex="1">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Amount" ShowInCustomizationForm="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserName" ShowInCustomizationForm="True" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Name" ShowInCustomizationForm="True" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="dsReceipts" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT PaymentReceipt.ReceiptID , PaymentReceipt.Date, PaymentReceipt.Amount, AspNetUsers.UserName, Doctors.Name FROM PaymentReceipt INNER JOIN AspNetUsers ON PaymentReceipt.UserID = AspNetUsers.Id INNER JOIN Doctors ON PaymentReceipt.DoctorID = Doctors.DoctorID WHERE (PaymentReceipt.PatientID = @PatientID) AND (PaymentReceipt.DoctorID = @DoctorID) AND (PaymentReceipt.ClinicID = @ClinicID)
and PaymentReceipt.Date  BETWEEN  @From and @To">
        <SelectParameters>
            <asp:Parameter Name="PatientID" />
            <asp:Parameter Name="DoctorID" />
            <asp:Parameter Name="ClinicID" />
            <asp:Parameter Name="From" />
            <asp:Parameter Name="To" />
        </SelectParameters>
    </asp:SqlDataSource>
                        </dx:PopupControlContentControl>
</ContentCollection>
                </dx:ASPxPopupControl>
            </td>
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

