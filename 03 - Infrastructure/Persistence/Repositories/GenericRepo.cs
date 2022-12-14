using _02___Application.Contracts;
using _03___Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___Infrastructure.Persistence.Repositories
{
    public class GenericRepo<T> : IGenericRepository<T> where T : class
    {
        IDBContext db;
        DbSet<T> table;
        public GenericRepo(IDBContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
           var newEntity = await table.AddAsync(entity);
           return newEntity.Entity;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T? Find(Func<T, bool> predicate)
        {
            return table.Where(predicate).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public T? GetByID(int id)
        {
            return table.Find(id);
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
