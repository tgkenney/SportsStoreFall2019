<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SportsStoreFall2019.AdminFolder.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administration</h1>
    <h3>Add a new product</h3>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="CategoryLabel" runat="server" Text="Category: " CssClass="col-md-2"></asp:Label>
            <asp:DropDownList ID="ddlCategory" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CategoryID" runat="server" CssClass="form-group" style="width: 300px"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [CategoryID], [Name] FROM [Category]"></asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="ProductCategoryValidator" runat="server" Text="* Product Category required" ControlToValidate="productName" Display="Dynamic" SetFocusOnError="True" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="NameLabel" runat="server" Text="Product Name: " CssClass="col-md-2"></asp:Label>
            <asp:TextBox ID="productName" runat="server" CssClass="form-group"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ProductNameValidator" runat="server" Text="* Product Name required" ControlToValidate="productName" Display="Dynamic" SetFocusOnError="True" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="DescriptionLabel" runat="server" Text="Product Description: " CssClass="col-md-2"></asp:Label>
            <asp:TextBox ID="productDescription" runat="server" CssClass="form-group"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ProductDescriptionValidator" runat="server" Text="* Product Description required" ControlToValidate="productDescription" Display="Dynamic" SetFocusOnError="True" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="PriceLabel" runat="server" Text="Product Price: " CssClass="col-md-2"></asp:Label>
            <asp:TextBox ID="productPrice" runat="server" CssClass="form-group"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ProductPriceValidator" runat="server" Text="* Product Price required" ControlToValidate="productDescription" Display="Dynamic" SetFocusOnError="True" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="ImageLabel" runat="server" Text="Image file: " CssClass="col-md-2" style="width: 300px"></asp:Label>
            <asp:FileUpload ID="imageUpload" runat="server" CssClass="form-group"/>
            <asp:RequiredFieldValidator ID="ProductImageValidator" runat="server" Text="* Product Image required" ControlToValidate="imageUpload" Display="Dynamic" SetFocusOnError="True" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
    </div>
    
    <asp:Button ID="AddProductButton" runat="server" OnClick="AddProductButton_OnClick" Text="Add Product" CssClass="btn btn-default" CausesValidation="True"/>

</asp:Content>
