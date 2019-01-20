<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="WebForms3.Admin.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="productsGrid"
        ItemType="WebForms3.Models.Product" DataKeyName="ProductID"
        SelectMethod="productsGrid_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:DynamicField DataField="ProductID" />
            <asp:DynamicField DataField="ProductName" />
            <asp:DynamicField DataField="Description" />
            <asp:DynamicField DataField="ImagePath" />
            <asp:DynamicField DataField="UnitPrice" />
            
        </Columns>
    </asp:GridView>
</asp:Content>
