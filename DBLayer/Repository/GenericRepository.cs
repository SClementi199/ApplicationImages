using DBLayer.Context;
using DBLayer.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ImageContext _context;
        private protected DbSet<T> _table;
        public GenericRepository(ImageContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }


        public async Task<T> AddAsync(T entity)
        {
            EntityEntry result = await _table.AddAsync(entity);
            return (result.State == EntityState.Added) ? entity : null;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(params object[] id)
        {
            return await _table.FindAsync(id);
        }

        public bool Remove(T entity)
        {
            EntityEntry result = _table.Remove(entity);
            return (result.State == EntityState.Deleted) ? true : false;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            EntityEntry result = _table.Update(entity);
            return (result.State == EntityState.Modified) ? entity : null;
        }


        public async Task<bool> Exist(string property, string value)
        {
            var result = await _table.AnyAsync(x => EF.Property<object>(x, property).ToString() == value);
            return result;

        }
    }
}
