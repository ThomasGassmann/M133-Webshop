namespace TaobaoExpress.Model.Core
{
    using System;

    public class Product : IIdentifiable, ICreated
    {
        public long Id { get; set; }

        public string MarkdownDescription { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public long PictureId { get; set; }

        public Picture Picture { get; set; }

        public DateTime Created { get; set; }
    }
}
