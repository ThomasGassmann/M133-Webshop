<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaobaoExpress._Default" %>
<%@ Import Namespace="TaobaoExpress" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="repeater">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="title">
                    <%#  this.Eval("Title") %>
                </td>
                <td>
                    <%# this.Eval("FormattedPrice") %>
                </td>
                <td>
                    <img class="picture" src="<%# this.Eval("ImagePath") %>" />
                </td>
                <td>
                    <div class="text">
                        <%# this.Eval("MarkdownHtml") %>
                    </div>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
