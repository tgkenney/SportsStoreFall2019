<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPlaced.aspx.cs" Inherits="SportsStoreFall2019.OrderFolder.OrderPlaced" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p> Your was successfully placed.  Your order ID is: </p>
    <p>
        <asp:Label ID="OrderID" runat="server" Text="Label"></asp:Label>
    </p>
    <p> Thank you for your business, please visit again! </p>
</asp:Content>
