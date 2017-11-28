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
            modelBuilder.HasDefaultSchema("TaobaoExpress");
            modelBuilder.Entity<Picture>().ToTable("Picture");
            modelBuilder.Entity<Product>().ToTable("Product");
            base.OnModelCreating(modelBuilder);
        }
    }
}
