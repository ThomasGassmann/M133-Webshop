<%@ Page Title="Create Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TaobaoExpress.Create" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="errorMessage" runat="server" />
    <asp:TextBox TextMode="SingleLine" ID="title" runat="server" CssClass="formElement" />
    <asp:TextBox TextMode="SingleLine" ID="price" type="number" step=".01" runat="server" CssClass="formElement"></asp:TextBox>
    <asp:TextBox TextMode="MultiLine" CssClass="markdown formElement" ID="markdownText" runat="server" />
    <div id="preview">
    </div>
    <asp:FileUpload ID="fileUpload" runat="server" />
    <asp:Button OnClick="CreateProduct" ID="createButton" runat="server" Text="Create" />
    <script>
        function loadPreview(text) {
            $.ajax({
                type: 'POST',
                url: '/Create.aspx/MarkdownPreview',
                data: JSON.stringify({
                    text: text
                }),
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $('#preview').html(data.d);
                }
            });
        }

        $('.markdown').on('input', function () {
            var text = $('.markdown').val();
            loadPreview(text);
        });
    </script>
</asp:Content>
