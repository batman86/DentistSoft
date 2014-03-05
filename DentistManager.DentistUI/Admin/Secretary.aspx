<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Secretary.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Secretary" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:800px ">
        <tr>
            <td style="width:500px "> <dx:ASPxGridView ID="gvxSecretary" runat="server" AutoGenerateColumns="False" ClientInstanceName="SecretaryGrid"
                DataSourceID="dsSecretary" EnableTheming="True" KeyFieldName="SecretaryID" Theme="Office2003Silver" OnInitNewRow="gvxSecretary_InitNewRow" Width="100%" style="margin-bottom: 5px">
                
                <Columns>
                    
                    <dx:GridViewCommandColumn VisibleIndex="0">
                        <EditButton Visible="True">
                        </EditButton>
                        <DeleteButton Visible="True" >
                        </DeleteButton>
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                        <HeaderTemplate>
                             <table class="auto-style1">
                                    <tr>
                                        <td> <dx:ASPxButton ID="btnAddNew" runat="server" Text="Add Secretary" AutoPostBack="false">
                                    <ClientSideEvents Click="function(s, e) { SecretaryGrid.AddNewRow(); }" />
                                </dx:ASPxButton>
                                </table>
                        </HeaderTemplate>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="SecretaryID" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UserID" VisibleIndex="2" ReadOnly="True" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="3">
                        <PropertiesTextEdit>
                            <ValidationSettings ErrorDisplayMode="ImageWithText">
                                <RegularExpression ErrorText="Enter Full Name" ValidationExpression="^[a-zA-Z ]{3,}$" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Gender" Visible="False" VisibleIndex="4">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Male" Value="Male" />
                                <dx:ListEditItem Text="Female" Value="Female" />
                            </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataDateColumn FieldName="BrithDate" VisibleIndex="5" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="6">
                        <PropertiesTextEdit>
                            <ValidationSettings>
                                <RegularExpression ErrorText="Wrong Format" ValidationExpression="\d{9}" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Mobile" VisibleIndex="7">
                        <PropertiesTextEdit>
                            <ValidationSettings ErrorDisplayMode="ImageWithText">
                                <RegularExpression ErrorText="Wrong Format" ValidationExpression="^\d{10,11}$" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="8" Visible="False">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="E_mail" VisibleIndex="9" Visible="False">
                        <PropertiesTextEdit>
                            <ValidationSettings>
                                <RegularExpression ErrorText="Wrong Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="10">
                    </dx:GridViewDataCheckColumn>
                </Columns>
                <Settings ShowFilterRow="True" />
                <SettingsDetail ShowDetailRow="True" />
                <Templates >
                    
                    <DetailRow>
                        <asp:FormView ID="fvDetails" runat="server" CellPadding="4" DataKeyNames="SecretaryID"  ForeColor="#333333"  OnDataBinding="fvDetails_DataBinding">

                            
                            <ItemTemplate>
                                SecretaryID:
                                <asp:Label ID="SecretaryIDLabel" runat="server" Text='<%# Eval("SecretaryID") %>' />
                                <br />
                                UserID:
                                <asp:Label ID="UserIDLabel" runat="server" Text='<%# Bind("UserID") %>' />
                                <br />
                                Name:
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                                <br />
                                Gender:
                                <asp:Label ID="GenderLabel" runat="server" Text='<%# Bind("Gender") %>' />
                                <br />
                                BrithDate:
                                <asp:Label ID="BrithDateLabel" runat="server" Text='<%# Bind("BrithDate") %>' />
                                <br />
                                Phone:
                                <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
                                <br />
                                Mobile:
                                <asp:Label ID="MobileLabel" runat="server" Text='<%# Bind("Mobile") %>' />
                                <br />
                                Address:
                                <asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>' />
                                <br />
                                E_mail:
                                <asp:Label ID="E_mailLabel" runat="server" Text='<%# Bind("E_mail") %>' />
                                <br />
                                Active:
                                <asp:CheckBox ID="ActiveCheckBox" runat="server" Checked='<%# Bind("Active") %>' Enabled="false" />
                                <br />
                            </ItemTemplate>
                           
                        </asp:FormView>
                    </DetailRow>
                    
                </Templates>
                </dx:ASPxGridView> 
                <asp:SqlDataSource ID="dsSecretary" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="update Secretary set Active = 0 where SecretaryID = @SecretaryID" InsertCommand="INSERT INTO [Secretary] ([Name], [Gender], [BrithDate], [Phone], [Mobile], [Address], [E_mail], [Active]) VALUES ( @Name, @Gender, @BrithDate, @Phone, @Mobile, @Address, @column1, @Active)" SelectCommand="SELECT * FROM [Secretary]" UpdateCommand="UPDATE [Secretary] SET [Name] = @Name, [Gender] = @Gender, [BrithDate] = @BrithDate, [Phone] = @Phone, [Mobile] = @Mobile, [Address] = @Address, [E_mail] = @column1, [Active] = @Active WHERE [SecretaryID] = @SecretaryID">
                    <DeleteParameters>
                        <asp:Parameter Name="SecretaryID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Gender" Type="String" />
                        <asp:Parameter DbType="Date" Name="BrithDate" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="column1" Type="String" />
                        <asp:Parameter Name="Active" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Gender" Type="String" />
                        <asp:Parameter DbType="Date" Name="BrithDate" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="column1" Type="String" />
                        <asp:Parameter Name="Active" Type="Boolean" />
                        <asp:Parameter Name="SecretaryID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT * FROM [Secretary] WHERE ([SecretaryID] = @SecretaryID)">
                    <SelectParameters>
                        <asp:Parameter Name="SecretaryID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </td>
        </tr>

    </table>

</asp:Content>
