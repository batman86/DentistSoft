<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Materials.aspx.cs" Inherits="DentistManager.DentistUI.Admin.Materials" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table style="width:800px ">
        <tr>
            <td style="width:500px ">
                <dx:ASPxGridView ID="gvxMedicine" runat="server" AutoGenerateColumns="False" DataSourceID="dsMaterials"
                     EnableTheming="True" KeyFieldName="ItemID" Theme="RedWine" ClientInstanceName="MaterialsGrid" 
                   >
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                            <EditButton Visible="True">
                            </EditButton>
                          <HeaderTemplate>
                              <dx:ASPxButton ID="ASPxButton1"  runat="server" AutoPostBack="false" ClientSideEvents-Click="function(s, e) { MaterialsGrid.AddNewRow(); }" Text="Add Materials"></dx:ASPxButton>
                          </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="ItemID" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ItemName" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="CatID" VisibleIndex="4">
                            <PropertiesComboBox>
                                <Items>
                                    <dx:ListEditItem Text="Cat1" Value="Cat1" />
                                </Items>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                            <EditFormSettings Caption="Category" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="ProdCompany" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="ScaleType" VisibleIndex="6">
                            <PropertiesComboBox>
                                <Items>
                                    <dx:ListEditItem Text="Pices" Value="Pices" />
                                    <dx:ListEditItem Text="Package" Value="Package" />
                                </Items>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="ReOrder" VisibleIndex="7">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataTextColumn FieldName="Note" VisibleIndex="8">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="MaterialCost" VisibleIndex="9">
                            <PropertiesSpinEdit DisplayFormatString="g">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsMaterials" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [Material] WHERE [ItemID] = @ItemID" InsertCommand="INSERT INTO [Material] ([ItemName], [PartNumber], [CatID], [ProdCompany], [ScaleType], [ReOrder], [Note], [MaterialCost]) VALUES (@ItemName, @PartNumber, @CatID, @ProdCompany, @ScaleType, @ReOrder, @Note, @MaterialCost)" SelectCommand="SELECT * FROM [Material]" UpdateCommand="UPDATE [Material] SET [ItemName] = @ItemName, [PartNumber] = @PartNumber, [CatID] = @CatID, [ProdCompany] = @ProdCompany, [ScaleType] = @ScaleType, [ReOrder] = @ReOrder, [Note] = @Note, [MaterialCost] = @MaterialCost WHERE [ItemID] = @ItemID">
                    <DeleteParameters>
                        <asp:Parameter Name="ItemID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ItemName" Type="String" />
                        <asp:Parameter Name="PartNumber" Type="String" />
                        <asp:Parameter Name="CatID" Type="Int32" />
                        <asp:Parameter Name="ProdCompany" Type="Int32" />
                        <asp:Parameter Name="ScaleType" Type="String" />
                        <asp:Parameter Name="ReOrder" Type="Int32" />
                        <asp:Parameter Name="Note" Type="String" />
                        <asp:Parameter Name="MaterialCost" Type="Decimal" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ItemName" Type="String" />
                        <asp:Parameter Name="PartNumber" Type="String" />
                        <asp:Parameter Name="CatID" Type="Int32" />
                        <asp:Parameter Name="ProdCompany" Type="Int32" />
                        <asp:Parameter Name="ScaleType" Type="String" />
                        <asp:Parameter Name="ReOrder" Type="Int32" />
                        <asp:Parameter Name="Note" Type="String" />
                        <asp:Parameter Name="MaterialCost" Type="Decimal" />
                        <asp:Parameter Name="ItemID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>