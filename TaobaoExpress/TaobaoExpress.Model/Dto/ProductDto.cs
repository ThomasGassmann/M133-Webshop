namespace TaobaoExpress.Model.Dto
{
    using MarkdownSharp;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Web;

    public class ProductDto
    {
        public long Id { get; set; }

        public string MarkdownDescription { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public DateTime Created { get; set; }

        public byte[] ImageData { get; set; }

        public string GetImagePath()
        {
            using (var memoryStream = new MemoryStream(this.ImageData))
            {
                var serverPath = $"/Content/{this.Id}.jpg";
                var path = HttpContext.Current.Server.MapPath("~" + serverPath);
                if (File.Exists(path))
                {
                    return serverPath;
                }

                var image = Image.FromStream(memoryStream);
                image.Save(path);
                return serverPath;
            }
        }

        public string GetMarkdownHtml()
        {
            var markdown = new Markdown();
            return markdown.Transform(this.MarkdownDescription);
        }
    }
}
