using System.Linq.Expressions;

namespace Academia.Proyecto.API.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IQueryable<T> AsQueryable();
        List<T> Where(Expression<Func<T, bool>> query);
        T? FirstOrDefault(Expression<Func<T, bool>> query);
    }
}
