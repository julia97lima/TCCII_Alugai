using Alugai.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Alugai.Models.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
            => _context = context;

        public async Task<T> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Entity {typeof(T)} can't be inserted. Exception found: {e}");
            }

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Entity {typeof(T)} can't be updated. Exception found: {e}");
            }


            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Entity {typeof(T)} can't be removed. Exception found: {e}");
            }
        }

        public IQueryable<T> Get()
            => _context.Set<T>().AsNoTracking();

        public IQueryable<T> Get(string include)
            => _context.Set<T>().Include(include);

        public IQueryable<T> Get(Expression<Func<T, bool>> pred)
            => _context.Set<T>().Where(pred).AsNoTracking();

        public bool Exists(Expression<Func<T, bool>> where)
            => _context.Set<T>().Count(where) > 0 ? true : false;

    }
}
