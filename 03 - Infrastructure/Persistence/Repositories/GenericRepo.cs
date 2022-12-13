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

        public T Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
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
