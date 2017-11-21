namespace TaobaoExpress.Services.Core
{
    using System.Linq;
    using TaobaoExpress.Model.Core;

    public interface IModelService<T> where T : class, IIdentifiable
    {
        IQueryable<T> Query();

        void Create(T entity);

        void Delete(long id);

        T GetById(long id);
    }
}
