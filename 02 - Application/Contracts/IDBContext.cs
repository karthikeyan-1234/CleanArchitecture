using _01___Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _02___Application.Contracts
{
    public interface IDBContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Entry(Object entity);
    }
}