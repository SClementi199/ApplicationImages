using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(params object[] id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        bool Remove(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> Exist(string property, string value);
    }
}
