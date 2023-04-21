using JaguarPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Services.Interfaces
{
    public interface IServiceRepository<T, I>
    {
        Task<IEnumerable<T>> GetList();
        Task<T> GetById(I id);
        Task Insert(T obj);
        Task Delete(I id);
        Task Update(I id, T obj);
    }
}
