<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="SportsStoreFall2019.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <asp:Label ID="titleLabel" runat="server" Text="title Label"></asp:Label>
    </p>

    <p>
        <asp:Label ID="statusLabel" runat="server"></asp:Label>
    </p>

    <p>
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="Product Name" ReadOnly="True" />
            <asp:BoundField DataField="Attributes" HeaderText="Attributes" ReadOnly="True" />
            <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="editQuantity" MaxLength="2" Text='<%# Eval("Quantity") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" />
        </Columns>

    </asp:GridView>
    </p>

    <p>
    <asp:Label ID="cartTotal" runat="server" Text="Label"></asp:Label>
    </p>

    <p>
    <asp:Button ID="UpdateButton" runat="server" Text="Update Quantities" OnClick="UpdateButton_Click" />
    </p>
</asp:Content>
