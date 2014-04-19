<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DentistManager.DentistUI.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
        <div class="accountHeader">
    <h2>
        Log In</h2>
    <p>
        Please enter your username and password. 
	</p>
</div>
<dx:ASPxLabel ID="lblUserName" runat="server" AssociatedControlID="tbUserName" Text="User Name:" />
<div class="form-field">
	<dx:ASPxTextBox ID="tbUserName" runat="server" Width="200px">
	    <ValidationSettings ValidationGroup="LoginUserValidationGroup">
	        <RequiredField ErrorText="User Name is required." IsRequired="true" />
	    </ValidationSettings>
	</dx:ASPxTextBox>
</div>
<dx:ASPxLabel ID="lblPassword" runat="server" AssociatedControlID="tbPassword" Text="Password:" />
<div class="form-field">
	<dx:ASPxTextBox ID="tbPassword" runat="server" Password="true" Width="200px">
	    <ValidationSettings ValidationGroup="LoginUserValidationGroup">
	        <RequiredField ErrorText="Password is required." IsRequired="true" />
	    </ValidationSettings>
	</dx:ASPxTextBox>
</div>
<dx:ASPxButton ID="btnLogin" runat="server" Text="Log In" ValidationGroup="LoginUserValidationGroup"
    OnClick="btnLogin_Click">
</dx:ASPxButton>
</asp:Content>
