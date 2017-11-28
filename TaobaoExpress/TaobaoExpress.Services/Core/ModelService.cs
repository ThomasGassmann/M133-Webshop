namespace TaobaoExpress.Services.Core
{
    using System.Data.Entity;
    using System.Linq;
    using TaobaoExpress.DataAccess.Context;
    using TaobaoExpress.Model.Core;

    public class ModelService<T> : IModelService<T> where T : class, IIdentifiable
    {
        private readonly TaobaoExpressContext context;
        
        public ModelService(TaobaoExpressContext context)
        {
            this.context = context;
        }

        public long Create(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
            return entity.Id;
        }

        public void Delete(long id)
        {
            var obj = this.GetById(id);
            this.context.Set<T>().Remove(obj);
            this.context.SaveChanges();
        }

        public T GetById(long id)
        {
            return this.Query().SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<T> Query()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IQueryable<T>)this.context.Set<Product>().Include(x => x.Picture);
            }

            return context.Set<T>();
        }
    }
}
