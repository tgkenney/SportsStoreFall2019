<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="SportsStoreFall2019.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p>
            <asp:Label ID="nameLabel" runat="server" Text="Label"></asp:Label>
        </p>

        <p>
            <asp:Image ID="productImage" width="300" runat="server"></asp:Image>
        </p>

        <p>
            <asp:Label ID="descLabel" runat="server" Text="Label"></asp:Label>
        </p>
        
        <p>
            <asp:Label ID="priceLabel" runat="server" Text="Label"></asp:Label>
        </p>

        <asp:Button ID="Button1" runat="server" Text="Add to cart" OnClick="Button1_Click" />
    </div>
</asp:Content>
