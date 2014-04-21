<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Warehouse" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td>
                <dx:ASPxGridView ID="gvxWarehouse" runat="server" AutoGenerateColumns="False" DataSourceID="dsWarehouse" EnableTheming="True" KeyFieldName="WarehouseID" Theme="RedWine">
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="WarehouseID" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="StorageID" VisibleIndex="2">
                            <PropertiesComboBox DataSourceID="dsStorages" TextField="name" ValueField="StorageID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ItemID" VisibleIndex="3">
                            <PropertiesComboBox DataSourceID="dsItems" TextField="ItemName" ValueField="ItemID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Available" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Reserved" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Total" ReadOnly="True" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CostPrice" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsWarehouse" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT * FROM [Warehouse] WHERE ([Total] &gt; @Total)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="Total" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="dsItems" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [ItemID], [ItemName] FROM [Material]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsStorages" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [StorageID], [Name] FROM [Storages]">
                </asp:SqlDataSource>
                s</td>
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
