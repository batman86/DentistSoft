<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Suppliers" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:800px ">
        <tr>
            <td style="width:500px ">

                 <dx:ASPxGridView ID="gvxSuppliers" runat="server" AutoGenerateColumns="False" ClientInstanceName="SuppliersGrid"
                DataSourceID="dsSuppliers" EnableTheming="True" 
                  KeyFieldName="SuppID" Theme="RedWine"  Width="100%" style="margin-bottom: 5px">
                
                <Columns>
                    
                    <dx:GridViewCommandColumn VisibleIndex="0">
                        <EditButton Visible="True">
                        </EditButton>
               <HeaderTemplate>
                    <dx:ASPxButton ID="btnAddNew" runat="server" AutoPostBack="False" Text="Add Supplier" Width="108px">
                                    <ClientSideEvents Click="function(s, e) {SuppliersGrid.AddNewRow();}" />
                        </dx:ASPxButton>
               </HeaderTemplate>
                    </dx:GridViewCommandColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="SuppID" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="2">
                        <PropertiesTextEdit>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="3" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="City" VisibleIndex="4" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Countery" VisibleIndex="5" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="6">
                        <PropertiesTextEdit>
                            <ValidationSettings ErrorDisplayMode="ImageWithText">
                                <RegularExpression ErrorText="Wrong Format" ValidationExpression="\d{9}" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Mobile" VisibleIndex="7" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="8" FieldName="Fax" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="WebSite" VisibleIndex="9" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="TaxFileNo" VisibleIndex="10" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="TaxCommision" VisibleIndex="11" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="TaxRegNo" VisibleIndex="12" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Notes" VisibleIndex="13" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataSpinEditColumn FieldName="openbalance" Visible="False" VisibleIndex="14">
                        <PropertiesSpinEdit DisplayFormatString="g">
                        </PropertiesSpinEdit>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataSpinEditColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Type" VisibleIndex="15">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Selected="True" Text="Vendor" Value="Vendor" />
                                <dx:ListEditItem Text="Services" Value="Services" />
                            </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                <Settings ShowFilterRow="True" />
                <SettingsDetail ShowDetailRow="True" />
                <Templates >
                    
                    <DetailRow>
                        <asp:FormView ID="fvDetails" runat="server" CellPadding="4" DataKeyNames="SuppID"  ForeColor="#333333"  OnDataBinding="fvDetails_DataBinding" >
  
                            <ItemTemplate>
                                SuppID:
                                <asp:Label ID="SuppIDLabel" runat="server" Text='<%# Eval("SuppID") %>' />
                                <br />
                                CompanyName:
                                <asp:Label ID="CompanyNameLabel" runat="server" Text='<%# Bind("CompanyName") %>' />
                                <br />
                                Address:
                                <asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>' />
                                <br />
                                City:
                                <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>' />
                                <br />
                                Countery:
                                <asp:Label ID="CounteryLabel" runat="server" Text='<%# Bind("Countery") %>' />
                                <br />
                                Phone:
                                <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
                                <br />
                                Mobile:
                                <asp:Label ID="MobileLabel" runat="server" Text='<%# Bind("Mobile") %>' />
                                <br />
                                Fax:
                                <asp:Label ID="FaxLabel" runat="server" Text='<%# Bind("Fax") %>' />
                                <br />
                                WebSite:
                                <asp:Label ID="WebSiteLabel" runat="server" Text='<%# Bind("WebSite") %>' />
                                <br />
                                TaxFileNo:
                                <asp:Label ID="TaxFileNoLabel" runat="server" Text='<%# Bind("TaxFileNo") %>' />
                                <br />
                                TaxCommision:
                                <asp:Label ID="TaxCommisionLabel" runat="server" Text='<%# Bind("TaxCommision") %>' />
                                <br />
                                TaxRegNo:
                                <asp:Label ID="TaxRegNoLabel" runat="server" Text='<%# Bind("TaxRegNo") %>' />
                                <br />
                                Notes:
                                <asp:Label ID="NotesLabel" runat="server" Text='<%# Bind("Notes") %>' />
                                <br />
                                openbalance:
                                <asp:Label ID="openbalanceLabel" runat="server" Text='<%# Bind("openbalance") %>' />
                                <br />
                                Type:
                                <asp:Label ID="TypeLabel" runat="server" Text='<%# Bind("Type") %>' />
                                <br />
                               
                            </ItemTemplate>
                           
                        </asp:FormView>
                    </DetailRow>
                    
                </Templates>
                </dx:ASPxGridView> 
                <asp:SqlDataSource ID="dsSuppliers" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [suppliers] WHERE [SuppID] = @SuppID" InsertCommand="INSERT INTO [suppliers] ([CompanyName], [Address], [City], [Countery], [Phone], [Mobile], [Fax], [WebSite], [TaxFileNo], [TaxCommision], [TaxRegNo], [Notes], [openbalance], [Type]) VALUES (@CompanyName, @Address, @City, @Countery, @Phone, @Mobile, @Fax, @WebSite, @TaxFileNo, @TaxCommision, @TaxRegNo, @Notes, @openbalance, @Type)" SelectCommand="SELECT * FROM [suppliers]" UpdateCommand="UPDATE [suppliers] SET [CompanyName] = @CompanyName, [Address] = @Address, [City] = @City, [Countery] = @Countery, [Phone] = @Phone, [Mobile] = @Mobile, [Fax] = @Fax, [WebSite] = @WebSite, [TaxFileNo] = @TaxFileNo, [TaxCommision] = @TaxCommision, [TaxRegNo] = @TaxRegNo, [Notes] = @Notes, [openbalance] = @openbalance, [Type] = @Type WHERE [SuppID] = @SuppID">
                    <DeleteParameters>
                        <asp:Parameter Name="SuppID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="City" Type="String" />
                        <asp:Parameter Name="Countery" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Fax" Type="String" />
                        <asp:Parameter Name="WebSite" Type="String" />
                        <asp:Parameter Name="TaxFileNo" Type="String" />
                        <asp:Parameter Name="TaxCommision" Type="String" />
                        <asp:Parameter Name="TaxRegNo" Type="String" />
                        <asp:Parameter Name="Notes" Type="String" />
                        <asp:Parameter Name="openbalance" Type="Decimal" />
                        <asp:Parameter Name="Type" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="City" Type="String" />
                        <asp:Parameter Name="Countery" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Fax" Type="String" />
                        <asp:Parameter Name="WebSite" Type="String" />
                        <asp:Parameter Name="TaxFileNo" Type="String" />
                        <asp:Parameter Name="TaxCommision" Type="String" />
                        <asp:Parameter Name="TaxRegNo" Type="String" />
                        <asp:Parameter Name="Notes" Type="String" />
                        <asp:Parameter Name="openbalance" Type="Decimal" />
                        <asp:Parameter Name="Type" Type="String" />
                        <asp:Parameter Name="SuppID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsSuppliersDetails" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [suppliers] WHERE [SuppID] = @SuppID" InsertCommand="INSERT INTO [suppliers] ([CompanyName], [Address], [City], [Countery], [Phone], [Mobile], [Fax], [WebSite], [TaxFileNo], [TaxCommision], [TaxRegNo], [Notes], [openbalance], [Type]) VALUES (@CompanyName, @Address, @City, @Countery, @Phone, @Mobile, @Fax, @WebSite, @TaxFileNo, @TaxCommision, @TaxRegNo, @Notes, @openbalance, @Type)" SelectCommand="SELECT * FROM [suppliers] WHERE ([SuppID] = @SuppID)" UpdateCommand="UPDATE [suppliers] SET [CompanyName] = @CompanyName, [Address] = @Address, [City] = @City, [Countery] = @Countery, [Phone] = @Phone, [Mobile] = @Mobile, [Fax] = @Fax, [WebSite] = @WebSite, [TaxFileNo] = @TaxFileNo, [TaxCommision] = @TaxCommision, [TaxRegNo] = @TaxRegNo, [Notes] = @Notes, [openbalance] = @openbalance, [Type] = @Type WHERE [SuppID] = @SuppID">
                    <DeleteParameters>
                        <asp:Parameter Name="SuppID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="City" Type="String" />
                        <asp:Parameter Name="Countery" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Fax" Type="String" />
                        <asp:Parameter Name="WebSite" Type="String" />
                        <asp:Parameter Name="TaxFileNo" Type="String" />
                        <asp:Parameter Name="TaxCommision" Type="String" />
                        <asp:Parameter Name="TaxRegNo" Type="String" />
                        <asp:Parameter Name="Notes" Type="String" />
                        <asp:Parameter Name="openbalance" Type="Decimal" />
                        <asp:Parameter Name="Type" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter Name="SuppID" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="City" Type="String" />
                        <asp:Parameter Name="Countery" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Fax" Type="String" />
                        <asp:Parameter Name="WebSite" Type="String" />
                        <asp:Parameter Name="TaxFileNo" Type="String" />
                        <asp:Parameter Name="TaxCommision" Type="String" />
                        <asp:Parameter Name="TaxRegNo" Type="String" />
                        <asp:Parameter Name="Notes" Type="String" />
                        <asp:Parameter Name="openbalance" Type="Decimal" />
                        <asp:Parameter Name="Type" Type="String" />
                        <asp:Parameter Name="SuppID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <br />
               
            </td>
        </tr>
    </table>
</asp:Content>
