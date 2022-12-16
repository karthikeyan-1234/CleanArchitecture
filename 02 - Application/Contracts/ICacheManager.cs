using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Application.Contracts
{
    public interface ICacheManager
    {
        Task<T?> TryGetAsync<T>(string key);
        Task<bool> TrySetAsync<T>(string key, T entry);
    }
}
