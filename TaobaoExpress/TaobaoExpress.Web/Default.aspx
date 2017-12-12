<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaobaoExpress._Default" %>
<%@ Import Namespace="TaobaoExpress" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <% foreach (var product in this.Products)
            { %>
            <tr>
                <td class="title">
                    <%= product.Title %>
                </td>
                <td>
                    <%= product.Price.ToSwissFranc() %>
                </td>
                <td>
                    <img class="picture" src="<%= product.GetImagePath() %>" />
                </td>
                <td>
                    <div class="text">
                        <%= product.GetMarkdownHtml() %>
                    </div>
                </td>
            </tr>
        <% } %>
    </table>
</asp:Content>
