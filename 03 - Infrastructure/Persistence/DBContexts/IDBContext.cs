using _01___Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _03___Infrastructure.DBContexts
{
    public interface IDBContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Entry(Object entity);
    }
}