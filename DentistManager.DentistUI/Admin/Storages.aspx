<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Storages.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Storages" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width:800px ">
        <tr>
            <td style="width:500px ">
                <dx:ASPxGridView ID="gvxStorages" runat="server" AutoGenerateColumns="False" DataSourceID="dsStorages"
                     EnableTheming="True" KeyFieldName="StorageID" Theme="RedWine"
                     ClientInstanceName="StoragesGrid" OnInitNewRow="gvxStorages_InitNewRow" 
                   >
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <EditButton Visible="True">
                            </EditButton>
                          <HeaderTemplate >
                              <dx:ASPxButton ID="btnAdd" runat="server" AutoPostBack="false" Text="Add Storages" ClientSideEvents-Click="function(s, e){StoragesGrid.AddNewRow();}"></dx:ASPxButton>
                          </HeaderTemplate>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="StorageID" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Mobile" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ClinicID" VisibleIndex="6">
                            <PropertiesComboBox DataSourceID="dsClinics" TextField="Name" ValueField="ClinicID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="7">
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                    
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsClinics" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [ClinicID], [Name] FROM [Clinics]"></asp:SqlDataSource>
                <br />
               
                <asp:SqlDataSource ID="dsStorages" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="UPDATE Storages SET Active = 0 WHERE (StorageID = @StorageID)" 
                    InsertCommand="INSERT INTO [Storages] ([Name], [Address], [Phone], [Mobile], [ClinicID], [Active]) VALUES (@Name, @Address, @Phone, @Mobile, @ClinicID, @Active)"
                     SelectCommand="SELECT * FROM [Storages]" 
                    UpdateCommand="UPDATE [Storages] SET [Name] = @Name, [Address] = @Address, [Phone] = @Phone, [Mobile] = @Mobile, [ClinicID] = @ClinicID, [Active] = @Active WHERE [StorageID] = @StorageID" 
                    >
                    <DeleteParameters>
                        <asp:Parameter Name="StorageID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter  Name="Mobile" Type="String" />
                        <asp:Parameter Name="ClinicID" Type="Int32" />
                        <asp:Parameter Name="Active" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="ClinicID" Type="Int32" />
                        <asp:Parameter Name="Active" Type="Boolean" />
                        <asp:Parameter Name="StorageID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
