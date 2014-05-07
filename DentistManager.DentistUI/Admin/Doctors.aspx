<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Doctors" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
        .auto-style2 {
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="sm" runat="server" />
      
    <dx:ASPxPopupControl ID="popup" runat="server" ClientInstanceName="popup" RenderMode="Lightweight"
         Height="251px" Theme="RedWine" Width="328px" AllowResize="True"
         PopupHorizontalAlign ="Center" AllowDragging="True" >
        <ContentCollection>
            <dx:PopupControlContentControl>
                <asp:Panel runat="server">  
        <table style="width:231px">
                                    <tr>
                                        <td align="center" colspan="2"><strong>Sign Up for Your New Account</strong></td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style2">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="UserName" runat="server" Width="170px" Theme="Office2003Silver">
                                                <ValidationSettings SetFocusOnError="True">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style3">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <dx:ASPxTextBox ID="Password" runat="server" Password="True" Width="170px" Theme="Office2010Silver">
                                                <ValidationSettings CausesValidation="True" SetFocusOnError="True">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style2">
                                            <asp:Label ID="PasswordLabel0" runat="server" AssociatedControlID="Password">Role:</asp:Label>
                                        </td>
                                        <td>
                                           
                                            <dx:ASPxComboBox ID="cbRoles" runat="server" DataSourceID="dsRole" OnSelectedIndexChanged="cbRoles_SelectedIndexChanged" TextField="Name" ValueField="Id">
                                                <ValidationSettings>
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="dsRole" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT * FROM [AspNetRoles]"></asp:SqlDataSource>
                                            

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style3">
                                            </td>
                                        <td style="text-align: right" class="auto-style1">
                                            <dx:ASPxButton ID="CreateUser" runat="server" OnClick="CreateUser_Click" Text="Create User" Theme="RedWine">
                                            </dx:ASPxButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    </table>
        </asp:Panel> 
            </dx:PopupControlContentControl>     
        </ContentCollection>
           
    </dx:ASPxPopupControl>

    <table class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="2">
      
    <dx:ASPxPopupControl ID="ChangePSpopup" runat="server" ClientInstanceName="popup" RenderMode="Lightweight"
         Height="203px" Theme="RedWine" Width="328px" AllowResize="True"
         PopupHorizontalAlign ="Center" AllowDragging="True" >
        <ContentCollection>
            <dx:PopupControlContentControl>
                <asp:Panel runat="server">  
        <table style="width:231px">
                                    <tr>
                                        <td align="center" colspan="2" style="font-weight: 700; font-style: italic">Change Password</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style2">
                                            UserName:</td>
                                        <td>
                                            &nbsp;&nbsp;
                                            <dx:ASPxLabel ID="lblUserName" runat="server">
                                            </dx:ASPxLabel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style3">
                                            Password:</td>
                                        <td class="auto-style1">
                                            <dx:ASPxTextBox ID="tbPassword" runat="server" Password="True" Width="170px" Theme="Office2010Silver">
                                                <ValidationSettings CausesValidation="True" SetFocusOnError="True">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style2">
                                            &nbsp;</td>
                                        <td>
                                           
                                            <dx:ASPxButton ID="btnChangePassword0" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" Theme="RedWine" ValidationGroup="ChangeUserPasswordValidationGroup">
                                            </dx:ASPxButton>
                                            

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style3">
                                            </td>
                                        <td style="text-align: right" class="auto-style1">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Literal ID="ChangePasswordErrorMessage" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    </table>
        </asp:Panel> 
            </dx:PopupControlContentControl>     
        </ContentCollection>
           
    </dx:ASPxPopupControl>

            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <div style="width: 100%; height: 100%; position: relative">
                <dx:ASPxGridView ID="gvxDoctors" runat="server" AutoGenerateColumns="False" ClientInstanceName="MainGirdDoctors" 
                    DataSourceID="dsDoctors" EnableTheming="True" KeyFieldName="DoctorID" Theme="RedWine" Width="100%" OnInitNewRow="gvxDoctors_InitNewRow" OnCustomButtonCallback="gvxDoctors_CustomButtonCallback">
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
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Age" VisibleIndex="5" Visible="False">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="BrithDate" VisibleIndex="6" Visible="False">
                            <PropertiesDateEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesDateEdit>
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
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="9" Visible="False">
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="E_mail" VisibleIndex="10" Visible="False">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="11" Name="checkActive">
                            <PropertiesCheckEdit ClientInstanceName="chkAcitve">
                            </PropertiesCheckEdit>
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn Caption="Create" VisibleIndex="13">
                            <EditFormSettings Visible="False" />
                            <DataItemTemplate >
                                <dx:ASPxButton ID="CreateButton" runat="server" AutoPostBack="true"
                                Text="CreateUser" OnClick="CreateButton_Click">
                                </dx:ASPxButton>
                                   <%--<a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')">
                                      Create User </a>--%>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ClinicID" VisibleIndex="12">
                            <PropertiesComboBox DataSourceID="dsClinics" TextField="Name" ValueField="ClinicID">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Change Password" VisibleIndex="14">
                            <EditFormSettings Visible="False" />
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btnChangePasswordpopup" runat="server" OnClick="btnChangePasswordpopup_Click" Text="Change Password">
                                </dx:ASPxButton>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
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
                                    <asp:Label ID="E_mailLabel" runat="server" Text='<%# Bind("[E_mail]") %>' />
                                    <br />
                                    Active:
                                    <asp:CheckBox ID="ActiveCheckBox" runat="server" Checked='<%# Bind("Active") %>' Enabled="false" />
                                    <br />
                                  
                                </ItemTemplate>
                            </asp:FormView>
                        </DetailRow>
                    </Templates>
                </dx:ASPxGridView>
                    <asp:SqlDataSource ID="dsDoctors" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="UPDATE [Doctors] SET Active= 0  where DoctorID=@DoctorID" InsertCommand="INSERT INTO [Doctors] ([UserID], [Name], [Gender], [BrithDate], [Phone], [Mobile], [Address], [E_mail], [Active], [ClinicID]) VALUES (@UserID, @Name, @Gender, @BrithDate, @Phone, @Mobile, @Address, @E_mail, @Active, @ClinicID)" SelectCommand="SELECT * FROM [Doctors]" UpdateCommand="UPDATE [Doctors] SET [UserID] = @UserID, [Name] = @Name, [Gender] = @Gender, [BrithDate] = @BrithDate, [Phone] = @Phone, [Mobile] = @Mobile, [Address] = @Address, [E_mail] = @E_mail, [Active] = @Active, [ClinicID] = @ClinicID WHERE [DoctorID] = @DoctorID">
                        <DeleteParameters>
                            <asp:Parameter  Name="DoctorID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="UserID" Type="String" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Gender" Type="String" />
                            <asp:Parameter Name="BrithDate" DbType="Date" />
                            <asp:Parameter Name="Phone" Type="String" />
                            <asp:Parameter Name="Mobile" Type="String" />
                            <asp:Parameter Name="Address" Type="String" />
                            <asp:Parameter Name="E_mail" Type="String" />
                            <asp:Parameter Name="Active" Type="Boolean" />
                            <asp:Parameter Name="ClinicID" Type="Int32" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="UserID" Type="String" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Gender" Type="String" />
                            <asp:Parameter Name="BrithDate" DbType="Date" />
                            <asp:Parameter Name="Phone" Type="String" />
                            <asp:Parameter Name="Mobile" Type="String" />
                            <asp:Parameter Name="Address" Type="String" />
                            <asp:Parameter Name="E_mail" Type="String" />
                            <asp:Parameter Name="Active" Type="Boolean" />
                            <asp:Parameter Name="ClinicID" Type="Int32" />
                            <asp:Parameter Name="DoctorID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsDetails" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT * FROM [Doctors] WHERE ([DoctorID] = @DoctorID)">
                        <SelectParameters>
                            <asp:Parameter Name="DoctorID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsClinics" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [ClinicID], [Name] FROM [Clinics]">
                    </asp:SqlDataSource>
                    <br />
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
