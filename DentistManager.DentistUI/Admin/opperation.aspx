<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="opperation.aspx.cs" Inherits="DentistManager.DentistUI.Admin.opperation" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:800px ">
        <tr>
            <td style="width:500px ">
                <dx:ASPxGridView ID="gvxMedicine" runat="server" AutoGenerateColumns="False" DataSourceID="dsOpperation"
                     EnableTheming="True" KeyFieldName="OpperationID" Theme="Office2003Silver" ClientInstanceName="MedicinGrid" 
                   >
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <NewButton Visible="True">
                            </NewButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="OpperationID" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Color" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Price" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsOpperation" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [opperation] WHERE [OpperationID] = @OpperationID" InsertCommand="INSERT INTO [opperation] ([Name], [Color], [Price], [MaterialID]) VALUES (@Name, @Color, @Price, @MaterialID)" SelectCommand="SELECT * FROM [opperation]" UpdateCommand="UPDATE [opperation] SET [Name] = @Name, [Color] = @Color, [Price] = @Price, [MaterialID] = @MaterialID WHERE [OpperationID] = @OpperationID">
                    <DeleteParameters>
                        <asp:Parameter Name="OpperationID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Color" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="MaterialID" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Color" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="MaterialID" Type="Int32" />
                        <asp:Parameter Name="OpperationID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>