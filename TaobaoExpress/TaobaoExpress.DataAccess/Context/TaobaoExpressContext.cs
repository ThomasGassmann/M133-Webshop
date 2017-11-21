namespace TaobaoExpress.DataAccess.Context
{
    using System.Data.Entity;
    using TaobaoExpress.Model.Core;

    public class TaobaoExpressContext : DbContext
    {
        public TaobaoExpressContext()
        {
        }

        public Picture Pictures { get; set; }

        public Product Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
