<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Doctors" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
        .auto-style2 {
            width: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <div style="width: 100%; height: 100%; position: relative">
                <dx:ASPxGridView ID="gvxDoctors" runat="server" AutoGenerateColumns="False" ClientInstanceName="MainGirdDoctors" 
                    DataSourceID="dsDoctors" EnableTheming="True" KeyFieldName="DoctorID" Theme="Office2003Silver" Width="100%" OnInitNewRow="gvxDoctors_InitNewRow">
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <EditButton Visible="True">
                            </EditButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                            <HeaderTemplate>
                                <table class="auto-style1">
                                    <tr>
                                        <td> <dx:ASPxButton ID="btnAddNew" runat="server" Text="Add Doctor" AutoPostBack="false">
                                    <ClientSideEvents Click="function(s, e) { MainGirdDoctors.AddNewRow(); }" />
                                </dx:ASPxButton>

                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="DoctorID" ReadOnly="True" VisibleIndex="1" Visible="False">
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
                            <PropertiesComboBox EnableFocusedStyle="False">
                                <Items>
                                    <dx:ListEditItem Text="Male" Value="Male" />
                                    <dx:ListEditItem Text="Female" Value="Female" />
                                </Items>
                                <ItemStyle>
                                <Border BorderWidth="0px" />
                                </ItemStyle>
                            </PropertiesComboBox>
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Age" VisibleIndex="5" Visible="False">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="BrithDate" VisibleIndex="6" Visible="False">
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="7">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorDisplayMode="ImageWithText" SetFocusOnError="True">
                                    <RegularExpression ErrorText="Wrong Format" ValidationExpression="\d{9}" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Mobile" VisibleIndex="8">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorDisplayMode="ImageWithText">
                                    <RegularExpression ErrorText="Wrong Format" ValidationExpression="^\d{10,11}$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="9" Visible="False">
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="E-mail" VisibleIndex="10" Visible="False">
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="11" Name="checkActive">
                            <PropertiesCheckEdit ClientInstanceName="chkAcitve">
                            </PropertiesCheckEdit>
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                    <SettingsDetail ShowDetailRow="True" />
                    <Templates>
                        <DetailRow>
                            <asp:FormView ID="fvDetails" runat="server" DataKeyNames="DoctorID"  OnDataBinding="fvDetails_DataBinding">
                                 <ItemTemplate>
                                    DoctorID:
                                    <asp:Label ID="DoctorIDLabel" runat="server" Text='<%# Eval("DoctorID") %>' />
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
                                    Age:
                                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Bind("Age") %>' />
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
                                    E-mail:
                                    <asp:Label ID="E_mailLabel" runat="server" Text='<%# Bind("[E-mail]") %>' />
                                    <br />
                                    Active:
                                    <asp:CheckBox ID="ActiveCheckBox" runat="server" Checked='<%# Bind("Active") %>' Enabled="false" />
                                    <br />
                                  
                                </ItemTemplate>
                            </asp:FormView>
                        </DetailRow>
                    </Templates>
                </dx:ASPxGridView>
                    <asp:SqlDataSource ID="dsDoctors" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="UPDATE [Doctors] SET Active= 0  where DoctorID=@DoctorID" InsertCommand="INSERT INTO [Doctors] ( [Name], [Gender], [BrithDate], [Phone], [Mobile], [Address], [E-mail], [Active]) VALUES ( @Name, @Gender, @BrithDate, @Phone, @Mobile, @Address, @column1, @Active)" SelectCommand="SELECT * FROM [Doctors]" UpdateCommand="UPDATE [Doctors] SET  [Name] = @Name, [Gender] = @Gender, [BrithDate] = @BrithDate, [Phone] = @Phone, [Mobile] = @Mobile, [Address] = @Address, [E-mail] = @column1, [Active] = @Active WHERE [DoctorID] = @DoctorID">
                        <DeleteParameters>
                            <asp:Parameter  Name="DoctorID" />
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
                            <asp:Parameter Name="DoctorID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT * FROM [Doctors] WHERE ([DoctorID] = @DoctorID)">
                        <SelectParameters>
                            <asp:Parameter Name="DoctorID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
