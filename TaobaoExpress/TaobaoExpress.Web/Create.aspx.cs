namespace TaobaoExpress
{
    using MarkdownSharp;
    using Microsoft.Practices.Unity;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Web.UI;
    using TaobaoExpress.Services.Product;

    public partial class Create : Page
    {
        [Dependency]
        public IProductCreationService ProductCreationService { get; set; }

        [WebMethod]
        [ScriptMethod]
        public static string MarkdownPreview(string text)
        {
            var markdown = new Markdown();
            return markdown.Transform(text);
        }

        public void CreateProduct(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.markdownText.Text))
            {
                this.errorMessage.Text = "Please provide some markdown";
                return;
            }

            if (string.IsNullOrWhiteSpace(this.title.Text))
            {
                this.errorMessage.Text = "Please provide a title";
                return;
            }

            if (string.IsNullOrWhiteSpace(this.price.Text) || !double.TryParse(this.price.Text, out _))
            {
                this.errorMessage.Text = "Please provide a price";
                return;
            }

            if (!this.fileUpload.HasFile || !this.IsValidImage(this.fileUpload.PostedFile.InputStream, out Image image))
            {
                this.errorMessage.Text = "Please provide an image";
                return;
            }

            this.ProductCreationService.CreateProduct(
                this.title.Text,
                this.markdownText.Text,
                double.Parse(this.price.Text),
                image);
            this.Response.Redirect("/");
        }

        private bool IsValidImage(Stream stream, out Image image)
        {
            try
            {
                var loaded = Image.FromStream(stream);
                image = loaded;
                return true;
            }
            catch
            {
                image = null;
                return false;
            }
        }
    }
}