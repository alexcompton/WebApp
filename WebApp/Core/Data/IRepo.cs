using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Data
{
    public interface IRepo<T>
    {
        Task Add(T t);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int id);
        Task Delete(int id);
        Task Update(T t);
    }
}
