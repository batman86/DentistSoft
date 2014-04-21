<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Clinics.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Clinics" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width:800px ">
        <tr>
            <td style="width:500px "> 
                <dx:ASPxGridView ID="gvxClinics" runat="server" AutoGenerateColumns="False" DataSourceID="dsClinics"
                     EnableTheming="True" KeyFieldName="ClinicID" Theme="RedWine" ClientInstanceName="ClinicGrid" 
                    OnInitNewRow="gvxClinics_InitNewRow">
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <EditButton Visible="True">
                            </EditButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                            <HeaderTemplate>
                             <table class="auto-style1">
                                    <tr>
                                        <td> <dx:ASPxButton ID="btnAddNew" runat="server" Text="Add Clinic" AutoPostBack="false">
                                    <ClientSideEvents Click="function(s, e) { ClinicGrid.AddNewRow(); }" />
                                </dx:ASPxButton>
                                </table>
                        </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="ClinicID" ReadOnly="True" VisibleIndex="1" Visible="False">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorDisplayMode="ImageWithText">
                                    <RegularExpression ErrorText="Wrong Format" ValidationExpression="^[a-zA-Z ]{3,}$" />
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="4">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorDisplayMode="ImageWithText">
                                    <RegularExpression ErrorText="Wrong Format" ValidationExpression="\d{9}" />
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Mobile" VisibleIndex="5">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorDisplayMode="ImageWithText">
                                    <RegularExpression ErrorText="Wrong Format" ValidationExpression="^\d{10,11}$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="Acitve" VisibleIndex="6">
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="dsClinics" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="update [Clinics] set Acitve = 0 where ClinicID= @ClinicID" InsertCommand="INSERT INTO [Clinics] ([Name], [Address], [Phone], [Mobile], [Acitve]) VALUES (@Name, @Address, @Phone, @Mobile, @Acitve)" SelectCommand="SELECT * FROM [Clinics]" UpdateCommand="UPDATE [Clinics] SET [Name] = @Name, [Address] = @Address, [Phone] = @Phone, [Mobile] = @Mobile, [Acitve] = @Acitve WHERE [ClinicID] = @ClinicID">
                    <DeleteParameters>
                        <asp:Parameter Name="ClinicID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Acitve" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="Acitve" Type="Boolean" />
                        <asp:Parameter Name="ClinicID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>

             </td>
            </tr>
          </table>
</asp:Content>
