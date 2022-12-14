using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        T Update(T entity);
        bool Delete(int id);
        Task<IEnumerable<T>> GetAllAsync();
        T? GetByID(int id);
        T? Find(Func<T,bool> predicate);
        Task SaveChangesAsync();
    }
}
