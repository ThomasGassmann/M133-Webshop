<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaobaoExpress._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <ul class="list">
        <% foreach (var product in this.Products)
            { %>
        <li class="list-item">
            <div class="container">
                <h1 class="title"><%= product.Title %></h1>
                <div class="price"><%= product.Price %></div>
                <img class="picture" src="<%= product.GetImagePath() %>" />
                <div class="text">
                    <%= product.GetMarkdownHtml() %>
                </div>
            </div>
        </li>
        <% } %>
    </ul>
</asp:Content>
