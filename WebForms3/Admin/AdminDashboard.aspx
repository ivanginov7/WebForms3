<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="WebForms3.Admin.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="productsGrid"
        ItemType="WebForms3.Models.ViewModels.ProductsWithCategoriesViewModel" DataKeyName="ProductID"
        SelectMethod="productsGrid_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:DynamicField DataField="ProductID" />
            <asp:DynamicField DataField="ProductName" />
            <asp:DynamicField DataField="Description" />
            <asp:ImageField DataImageUrlField="ImagePath" />
            <asp:DynamicField DataField="UnitPrice" />
            <asp:HyperLinkField 
                HeaderText="Edit"
                DataTextField="ProductID"
                DataNavigateUrlFields="ProductID"
                DataNavigateUrlFormatString="~/Admin/EditProduct.aspx?ProductID={0}" />
        </Columns>
    </asp:GridView>
    
    <asp:Label Text="<%#ImagePath%>" runat="server" />
    
</asp:Content>
