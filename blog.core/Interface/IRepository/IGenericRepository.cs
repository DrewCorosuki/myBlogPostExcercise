using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Interface.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> FindById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task<T> Add(T item);
        Task<T> Edit(T item);
        Task<bool> HardDelete(T entity);
        Task<bool> SoftDelete(T entity);
        Task<int> CountAll();
        Task<int> Count(Expression<Func<T, bool>> predicate);
    }
}
