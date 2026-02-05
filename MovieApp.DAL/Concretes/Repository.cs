using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.DAL.Data;
using MovieApp.DAL.Interfaces;
using MovieApp.DAL.Models;

namespace MovieApp.DAL.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MovieAppDbContext _context;
        private readonly DbSet<T> table;

        public Repository(MovieAppDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            var query=table.AsQueryable();
            return filter != null ? query.Where(filter): query ;
        }

        public IQueryable<T> GetAll(bool isTracking = false, int page = 1, int take = 2, params string[] includes)
        {
            var query=table.AsQueryable();
            if(!isTracking)
            {
                query= query.AsNoTracking();
            }
            if(includes!=null)
            {
                foreach(var includeProperty in includes)
                {
                    query= query.Include(includeProperty);
                }
            }
            query= query.Skip((page-1)*take).Take(take);
            return query;
        }

        public IQueryable<T> GetAll(bool isTracking = false, Expression<Func<T, bool>> filter = null, params string[] includes)
        {
            var query = table.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            return filter!=null? query.Where(filter): query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> GetByIdAsync(int id,bool isTracking = false, params string[] includes)
        {
            var query= table.AsQueryable();
            if(!isTracking)
            {
                query= query.AsNoTracking();
            }
            if(includes!=null)
            {
                foreach(var includeProperty in includes)
                {
                    query= query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> filter)
        {
            return await table.AnyAsync(filter);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }
    }

}
