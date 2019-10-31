<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="SportsStoreFall2019.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:DataList ID="DataList1" runat="server">
        
        <ItemTemplate>
           <h3> <%--defines the size of the text. H1 is the most important (aka biggest)--%>
           <a href="ProductDetails.aspx?ProductID=<%#Eval("ProductID").ToString() %>" > <%--?ProductID is called the query string--%>

               <%#HttpUtility.HtmlEncode(Eval("Name").ToString()) %> <%--encode changes regular text into HTML--%>

           </a>
           </h3>

           <a href="ProductDetails.aspx?ProductID=<%#Eval("ProductID").ToString() %>" >
           <img width="100" src="Images/<%#Eval("Thumbnail").ToString() %>"
               alt="<%#Eval("Name").ToString() %>" >" <%--Alternate text that shows if image does not--%>
            
           </a>
           <p>
               Description: 
               <%#HttpUtility.HtmlEncode(Eval("ProdDesc").ToString()) %>
           </p>
           <p>
               Price: 
               <%#HttpUtility.HtmlEncode(Eval("Price").ToString()) %>
           </p>

        </ItemTemplate>

    </asp:DataList> <%--a datalist is an asp tool which will render like an HTML table--%>

</asp:Content>
