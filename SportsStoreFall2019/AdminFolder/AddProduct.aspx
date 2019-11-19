<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SportsStoreFall2019.AdminFolder.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="CategoryLabel" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="ddlCategory" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CategoryID" runat="server"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [CategoryID], [Name] FROM [Category]"></asp:SqlDataSource>
        </div>
        <div class="form-group">
            <asp:Label ID="NameLabel" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="productName" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="DescriptionLabel" runat="server" Text="Product Description"></asp:Label>
            <asp:TextBox ID="productDescription" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="PriceLabel" runat="server" Text="Product Price"></asp:Label>
            <asp:TextBox ID="productPrice" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="ImageLabel" runat="server" Text="Image file: "></asp:Label>
            <asp:FileUpload ID="imageUpload" runat="server" />
        </div>

        <asp:Button ID="AddProductButton" runat="server" OnClick="AddProductButton_OnClick" Text="Add Product" />
    </div>
</asp:Content>
