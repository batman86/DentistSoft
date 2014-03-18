<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Payment" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 800px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <dx:ASPxGridView ID="gvxPaymentClinics" runat="server" AutoGenerateColumns="False" DataSourceID="dsClinis" EnableTheming="True" KeyFieldName="ClinicID" OnCustomUnboundColumnData="gvxPaymentClinics_CustomUnboundColumnData" Theme="Office2003Silver">
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
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
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
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
                    <SettingsDetail ShowDetailRow="True" />
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="gvxDoctor" runat="server" AutoGenerateColumns="False" DataSourceID="dsDoctors" EnableTheming="True" KeyFieldName="DoctorID" OnBeforePerformDataSelect="gvxDoctor_BeforePerformDataSelect" OnCustomUnboundColumnData="gvxDoctor_CustomUnboundColumnData" Theme="Office2003Silver">
                                <Columns>
                                    <dx:GridViewCommandColumn VisibleIndex="0">
                                        <ClearFilterButton Visible="True">
                                        </ClearFilterButton>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="DoctorID" ReadOnly="True" Visible="False" VisibleIndex="1">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="Total Required" UnboundType="Decimal" VisibleIndex="3">
                                        <PropertiesSpinEdit DisplayFormatString="g">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataSpinEditColumn FieldName="Total Payed" UnboundType="Decimal" VisibleIndex="4">
                                        <PropertiesSpinEdit DisplayFormatString="g">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                </Columns>
                                <Settings ShowFilterRow="True" />
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
