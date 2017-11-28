namespace TaobaoExpress.Services.Product
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using TaobaoExpress.Model.Core;
    using TaobaoExpress.Services.Core;

    public class ProductCreationService : IProductCreationService
    {
        private readonly IModelService<Picture> pictureService;

        private readonly IModelService<Product> productService;

        public ProductCreationService(IModelService<Picture> pictureService, IModelService<Product> productService)
        {
            this.pictureService = pictureService;
            this.productService = productService;
        }

        public long CreateProduct(string title, string markdown, double price, Image picture)
        {
            var dataStream = new MemoryStream();
            picture.Save(dataStream, ImageFormat.Jpeg);
            var pictureId = this.pictureService.Create(new Picture
            {
                Created = DateTime.Now,
                Data = dataStream.ToArray(),
                Format = ImageFormat.Jpeg.ToString(),
                Title = title
            });
            var product = this.productService.Create(new Product
            {
                Created = DateTime.Now,
                MarkdownDescription = markdown,
                PictureId = pictureId,
                Title = title,
                Price = price
            });
            return product;
        }
    }
}
