<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="SportsStoreFall2019.OrderFolder.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
            <asp:BoundField DataField="Attributes" HeaderText="Attributes" SortExpression="Attributes" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ProductID], [Attributes], [Quantity], [DateAdded] FROM [ShoppingCart] WHERE ([CartID] = @CartID)">
        <SelectParameters>
            <asp:CookieParameter CookieName="SportsStore_cartid" Name="CartID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <p>
        <asp:Button id="placeOrderButton" runat="server" text="Place Order" onclick="placeOrderButton_Click"></asp:Button>
    </p>
</asp:Content>
