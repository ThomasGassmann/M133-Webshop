namespace TaobaoExpress.Model.Core
{
    using System;

    public class Picture : IIdentifiable, ICreated
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public byte[] Data { get; set; }

        public DateTime Created { get; set; }
    }
}
