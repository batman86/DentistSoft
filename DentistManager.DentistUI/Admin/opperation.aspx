<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="opperation.aspx.cs" Inherits="DentistManager.DentistUI.Admin.opperation" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:800px ">
        <tr>
            <td style="width:500px ">
                <dx:ASPxGridView ID="gvxOpperation" runat="server" AutoGenerateColumns="False" DataSourceID="dsOpperation"
                     EnableTheming="True" KeyFieldName="OpperationID" Theme="RedWine"
                     ClientInstanceName="OpperationGrid" OnRowInserted="gvxOpperation_RowInserted" OnCellEditorInitialize="gvxOpperation_CellEditorInitialize" OnRowUpdated="gvxOpperation_RowUpdated" OnStartRowEditing="gvxOpperation_StartRowEditing" 
                   >
                    <Columns>
                        <dx:GridViewCommandColumn VisibleIndex="0">
                          
                           
                            <EditButton Visible="True">
                            </EditButton>
                          
                           
                            <HeaderTemplate>
                                <dx:ASPxButton ID="btnAddNew" runat="server" AutoPostBack="False" Text="Add Opperation" Width="108px">
                                    <ClientSideEvents Click="function(s, e) {OpperationGrid.AddNewRow();}" />
                                </dx:ASPxButton>
                            </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="OpperationID" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataColorEditColumn FieldName="Color" VisibleIndex="3">
                            <Settings AllowAutoFilter="False" />
                        </dx:GridViewDataColorEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="Price" VisibleIndex="4">
                            <PropertiesSpinEdit DisplayFormatString="g">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                    <Templates>
                        <EditForm>
                            <dx:ASPxGridViewTemplateReplacement ID="replaceEditor" runat="server" ReplacementType="EditFormEditors" />
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style2">
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Materials :">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxDropDownEdit ID="ddMaterails" runat="server">
                                            <DropDownWindowTemplate>
                                                <dx:ASPxCheckBoxList ID="chlMaterails" runat="server" DataSourceID="dsMaterails" TextField="ItemName" ValueField="ItemID" Width="100%">
                                                </dx:ASPxCheckBoxList>
                                            </DropDownWindowTemplate>
                                        </dx:ASPxDropDownEdit>
                                    </td>
                                </tr>
                            </table>
                            <dx:ASPxGridViewTemplateReplacement ID="replaceUpdate" runat="server" ReplacementType="EditFormUpdateButton" />
                            <dx:ASPxGridViewTemplateReplacement ID="replaceCancel" runat="server" ReplacementType="EditFormCancelButton" />
                        </EditForm>
                    </Templates>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsMaterails" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT [ItemID], [ItemName] FROM [Material]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsOpperationMaterails" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" SelectCommand="SELECT Material.ItemID, Material.ItemName FROM Material INNER JOIN OpperationMaterials ON Material.ItemID = OpperationMaterials.ItemID WHERE (OpperationMaterials.OpperationID = @OpperationID)" DeleteCommand="DELETE FROM OpperationMaterials WHERE (OpperationID = @OpperationID AND ItemID = @ItemID)" InsertCommand="INSERT INTO OpperationMaterials(OpperationID, ItemID) VALUES (@OpperationID, @ItemID)">
                    <DeleteParameters>
                        <asp:Parameter Name="OpperationID" />
                        <asp:Parameter Name="ItemID" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="OpperationID" />
                        <asp:Parameter Name="ItemID" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter Name="OpperationID" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
               
                <asp:SqlDataSource ID="dsOpperation" runat="server" ConnectionString="<%$ ConnectionStrings:Dentist %>" DeleteCommand="DELETE FROM [opperation] WHERE [OpperationID] = @OpperationID" 
                    InsertCommand="INSERT INTO [opperation] ([Name], [Color], [Price]) VALUES (@Name, @Color, @Price) 
                    SELECT @GetOpperationID = SCOPE_IDENTITY()"
                     SelectCommand="SELECT * FROM [opperation]" 
                    UpdateCommand="UPDATE [opperation] SET [Name] = @Name, [Color] = @Color, [Price] = @Price WHERE [OpperationID] = @OpperationID" 
                    OnInserted="dsOpperation_Inserted">
                    <DeleteParameters>
                        <asp:Parameter Name="OpperationID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Color" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Direction="Output"  Name="GetOpperationID" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Color" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="OpperationID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>