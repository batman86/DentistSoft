<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Receiving.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Receiving" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td style="width: auto; vertical-align: top; text-align: left">

    <dx:ASPxGridView ID="gvxReceiving" runat="server" AutoGenerateColumns="False" 
        DataSourceID="dsReceiving" EnableTheming="True" ClientInstanceName="ReceivingGrid"
         KeyFieldName="ReciveID" Theme="RedWine" OnRowInserted="gvxReceiving_RowInserted" OnRowUpdated="gvxReceiving_RowUpdated">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0">
                <EditButton Visible="True">
                </EditButton>
                <HeaderTemplate>
                    <dx:ASPxButton ID="btnAddNew" AutoPostBack="false"
                         ClientSideEvents-Click="function(s,e) {ReceivingGrid.AddNewRow();}" 
                        runat="server" Text="ReceiveItems"></dx:ASPxButton>
                </HeaderTemplate>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ReciveID" ReadOnly="True" VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Items" FieldName="ItemID" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="dsItems" TextField="ItemName" ValueField="ItemID">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Suppliers" FieldName="SuppID" VisibleIndex="3">
                <PropertiesComboBox DataSourceID="dsSuppliers" TextField="CompanyName" ValueField="SuppID">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn FieldName="Amount" VisibleIndex="4">
                <PropertiesSpinEdit DisplayFormatString="g">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataDateColumn FieldName="ExpireDate" VisibleIndex="5">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ReciveDate" VisibleIndex="6">
                <PropertiesDateEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataComboBoxColumn Caption="Storages" FieldName="StorageID" VisibleIndex="7">
                <PropertiesComboBox DataSourceID="dsStorages" TextField="Name" ValueField="StorageID">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn FieldName="Recived" VisibleIndex="8">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataSpinEditColumn Caption="ByPice" FieldName="ByoneCost" VisibleIndex="9">
                <PropertiesSpinEdit DisplayFormatString="g">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="TotalCost" VisibleIndex="10">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataSpinEditColumn>
        </Columns>
        <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsReceiving" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [RecivingItems] WHERE [ReciveID] = @ReciveID" InsertCommand="INSERT INTO [RecivingItems] ([ItemID], [SuppID], [Amount], [ExpireDate], [ReciveDate], [StorageID], [Recived], [ByoneCost]) VALUES (@ItemID, @SuppID, @Amount, @ExpireDate, @ReciveDate, @StorageID, @Recived, @ByoneCost)" SelectCommand="SELECT * FROM [RecivingItems]" UpdateCommand="UPDATE [RecivingItems] SET [ItemID] = @ItemID, [SuppID] = @SuppID, [Amount] = @Amount, [ExpireDate] = @ExpireDate, [ReciveDate] = @ReciveDate, [StorageID] = @StorageID, [Recived] = @Recived, [ByoneCost] = @ByoneCost WHERE [ReciveID] = @ReciveID">
                    <DeleteParameters>
                        <asp:Parameter Name="ReciveID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ItemID" Type="Int32" />
                        <asp:Parameter Name="SuppID" Type="Int32" />
                        <asp:Parameter Name="Amount" Type="Int32" />
                        <asp:Parameter DbType="Date" Name="ExpireDate" />
                        <asp:Parameter DbType="Date" Name="ReciveDate" />
                        <asp:Parameter Name="StorageID" Type="Int32" />
                        <asp:Parameter Name="Recived" Type="Boolean" />
                        <asp:Parameter Name="ByoneCost" Type="Decimal" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ItemID" Type="Int32" />
                        <asp:Parameter Name="SuppID" Type="Int32" />
                        <asp:Parameter Name="Amount" Type="Int32" />
                        <asp:Parameter DbType="Date" Name="ExpireDate" />
                        <asp:Parameter DbType="Date" Name="ReciveDate" />
                        <asp:Parameter Name="StorageID" Type="Int32" />
                        <asp:Parameter Name="Recived" Type="Boolean" />
                        <asp:Parameter Name="ByoneCost" Type="Decimal" />
                        <asp:Parameter Name="ReciveID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsItems" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [ItemID], [ItemName] FROM [Material]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsSuppliers" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [SuppID], [CompanyName] FROM [suppliers]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsStorages" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [StorageID], [Name] FROM [Storages]">
                </asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
