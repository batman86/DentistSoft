<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Accounts" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .auto-style2 {
            width: 93px;
        }
        .auto-style3 {
            height: 32px;
            width: 93px;
        }
    </style>
    </asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" />
    <asp:Panel runat="server">  
       
        <table style="width:800px">
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
                                           
                                            <dx:ASPxComboBox ID="cbRoles" runat="server" AutoPostBack="True" DataSourceID="dsRole" OnSelectedIndexChanged="cbRoles_SelectedIndexChanged" TextField="Name" ValueField="Id">
                                                <ValidationSettings>
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="dsRole" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT * FROM [AspNetRoles]"></asp:SqlDataSource>
                                            

                                        </td>
                                    </tr>
                                    <tr>
                                          
                                        <td align="right" class="auto-style2">Employee:</td>
                                        <td>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                            <dx:ASPxComboBox ID="cbEmployee" runat="server" DataSourceID="dsEmployees">
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="dsEmployees" runat="server"></asp:SqlDataSource>
                                           </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="cbRoles" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
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
</asp:Content>
