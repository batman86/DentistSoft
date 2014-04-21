<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Medicine.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Medicine" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <table style="width:800px ">
        <tr>
            
            <td style="width:500px ">
                <dx:ASPxGridView ID="gvxMedicine" runat="server" AutoGenerateColumns="False" DataSourceID="dsMedicine"
                     EnableTheming="True" KeyFieldName="MedicineID" Theme="RedWine" ClientInstanceName="MedicinGrid" 
                   >
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <EditButton Visible="True">
                            </EditButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                            <HeaderTemplate>
                                <dx:ASPxButton ID="btnAddNew" runat="server" Text="Add Medicine" AutoPostBack="false">
                                    <ClientSideEvents Click="function(s, e) { MedicinGrid.AddNewRow(); }" />
                                    </dx:ASPxButton>
                            </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="MedicineID" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="SideEffectDecsription" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ScaleType" VisibleIndex="4">
                            <PropertiesComboBox>
                                <Items>
                                    <dx:ListEditItem Text="Pill" Value="Pill" />
                                    <dx:ListEditItem Text="liquid" Value="liquid" />
                                </Items>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="Dose" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Concentration" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsMedicine" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [Medicine] WHERE [MedicineID] = @MedicineID" InsertCommand="INSERT INTO [Medicine] ([Name], [SideEffectDecsription], [ScaleType], [Dose], [Concentration]) VALUES (@Name, @SideEffectDecsription, @ScaleType, @Dose, @Concentration)" SelectCommand="SELECT * FROM [Medicine]" UpdateCommand="UPDATE [Medicine] SET [Name] = @Name, [SideEffectDecsription] = @SideEffectDecsription, [ScaleType] = @ScaleType, [Dose] = @Dose, [Concentration] = @Concentration WHERE [MedicineID] = @MedicineID">
                    <DeleteParameters>
                        <asp:Parameter Name="MedicineID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="SideEffectDecsription" Type="String" />
                        <asp:Parameter Name="ScaleType" Type="String" />
                        <asp:Parameter Name="Dose" Type="String" />
                        <asp:Parameter Name="Concentration" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="SideEffectDecsription" Type="String" />
                        <asp:Parameter Name="ScaleType" Type="String" />
                        <asp:Parameter Name="Dose" Type="String" />
                        <asp:Parameter Name="Concentration" Type="String" />
                        <asp:Parameter Name="MedicineID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

</asp:Content>
