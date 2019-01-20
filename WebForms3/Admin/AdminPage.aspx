<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebForms3.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administration</h1>
    <hr />
    <%--<h3>Add Product:</h3>--%>
    <%--<table>
        <tr>
            <td><asp:Label ID="LabelAddCategory" runat="server">Category:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownAddCategory" runat="server" 
                    ItemType="WebForms3.Models.Category" 
                    SelectMethod="GetCategories" DataTextField="CategoryName" 
                    DataValueField="CategoryID" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddName" runat="server">Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Product name required." ControlToValidate="AddProductName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddDescription" runat="server">Description:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Description required." ControlToValidate="AddProductDescription" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddPrice" runat="server">Price:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Price required." ControlToValidate="AddProductPrice" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Must be a valid price without $." ControlToValidate="AddProductPrice" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddImageFile" runat="server">Image File:</asp:Label></td>
            <td>
                <asp:FileUpload ID="ProductImage" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Image path required." ControlToValidate="ProductImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="AddProductButton" runat="server" Text="Add Product" OnClick="AddProductButton_Click"  CausesValidation="true"/>--%>
    <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
    <p></p>
    <h3>Update Or Remove Product:</h3>
    <table>
        <tr>
            <td><asp:Label ID="LabelRemoveProduct" runat="server">Product:</asp:Label></td>
            <td><asp:DropDownList ID="DropDownRemoveProduct" runat="server" ItemType="WebForms3.Models.Product" 
                    SelectMethod="GetProducts" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownRemoveProduct_SelectedIndexChanged"
                    DataTextField="ProductName" DataValueField="ProductID" >
                <Items>
                    <asp:ListItem Text="Select" Value="" Enabled />
                </Items>
                </asp:DropDownList>
            </td>
        </tr>
    
        <tr>
            <td><asp:Label ID="UpdateCategoryLabel" runat="server">Category:</asp:Label></td>
            <td>
                <asp:DropDownList ID="UpdateCategoryDropDownList" runat="server" 
                    ItemType="WebForms3.Models.Category" 
                    SelectMethod="GetCategories" DataTextField="CategoryName" 
                    DataValueField="CategoryID" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="UpdateNameLabel" runat="server">Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdateNameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UpdateNameRequiredFieldValidator" runat="server" Text="* Product name required." ControlToValidate="UpdateNameTextBox" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="UpdateDescriptionLabel" runat="server">Description:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdateDescriptionTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UpdateDescriptionRequiredFieldValidator" runat="server" Text="* Description required." ControlToValidate="UpdateDescriptionTextBox" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="UpdatePriceLabel" runat="server">Price:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdatePriceTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UpdatePriceRequiredFieldValidator" runat="server" Text="* Price required." ControlToValidate="UpdatePriceTextBox" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="UpdatePriceRegularExpressionValidator" runat="server" Text="* Must be a valid price without $." ControlToValidate="UpdatePriceTextBox" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="UpdateFileLabel" runat="server">Image File:</asp:Label></td>
            <td>
                <asp:FileUpload ID="UpdateFileUpload" runat="server" />
                <!--<asp:RequiredFieldValidator ID="UpdateFileRequiredFieldValidator" runat="server" Text="* Image path required." ControlToValidate="UpdateFileUpload" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            --></td>
        </tr>
    </table>
    <p></p>
    <asp:Button ID="UpdateProductButton" runat="server" Text ="Update Product" OnClick="UpdateProductButton_Click" CausesValidation="true" />
    <asp:Button ID="RemoveProductButton" runat="server" Text="Remove Product" OnClick="RemoveProductButton_Click" CausesValidation="false"/>
    <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>
</asp:Content>
