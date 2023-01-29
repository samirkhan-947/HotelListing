using HotelListing.Data;
using HotelListing.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataBaseContext _Context;
        private readonly DbSet<T> _db;

        public GenericRepository(DataBaseContext Context)
        {
            _Context = Context;
            _db = _Context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public  void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities); 
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes != null)
            {
                foreach (var includeproperty in includes)
                {
                    query = query.Include(includeproperty);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if(expression != null)
            {
                query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includeproperty in includes)
                {
                    query = query.Include(includeproperty);
                }
            }
            if(orderby != null)
            {
                query = orderby(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public async void Update(T entity)
        {
            _db.Attach(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
