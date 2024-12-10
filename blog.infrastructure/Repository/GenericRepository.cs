using blog.infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blog.infrastructure.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly BlogContext _db = new BlogContext();
        public async Task<T> FindById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<T> Add(T entity)
        {
            var item = _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return item;
        }
        public async Task<T> Edit(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> HardDelete(T entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SoftDelete(T entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<int> CountAll()
        {
            return await _db.Set<T>().CountAsync();
        }
        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().Where(predicate).CountAsync();
        }
    }
}
