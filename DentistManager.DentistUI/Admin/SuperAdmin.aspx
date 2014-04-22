<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperAdmin.aspx.cs" Inherits="DentistManager.DentistUI.Admin.SuperAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxGridView ID="gvAccounts" runat="server" AutoGenerateColumns="False" DataSourceID="dsAccounts" KeyFieldName="Id">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0">
                    <EditButton Visible="True">
                    </EditButton>
                    <ClearFilterButton Visible="True">
                    </ClearFilterButton>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UserName" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PasswordHash" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SecurityStamp" VisibleIndex="4">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Discriminator" VisibleIndex="5">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="6">
                </dx:GridViewDataCheckColumn>
            </Columns>
            <Settings ShowFilterRow="True" />
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="dsAccounts" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [AspNetUsers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [Active]) VALUES (@Id, @UserName, @PasswordHash, @SecurityStamp, @Discriminator, @Active)" SelectCommand="SELECT * FROM [AspNetUsers]" UpdateCommand="UPDATE [AspNetUsers] SET [UserName] = @UserName, [PasswordHash] = @PasswordHash, [SecurityStamp] = @SecurityStamp, [Discriminator] = @Discriminator, [Active] = @Active WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="String" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="PasswordHash" Type="String" />
                <asp:Parameter Name="SecurityStamp" Type="String" />
                <asp:Parameter Name="Discriminator" Type="String" />
                <asp:Parameter Name="Active" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="PasswordHash" Type="String" />
                <asp:Parameter Name="SecurityStamp" Type="String" />
                <asp:Parameter Name="Discriminator" Type="String" />
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="Id" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
