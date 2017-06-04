using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Service
{
    public interface ISalesAddressService<T>
    {
        Task<IEnumerable<T>> GetByID(int id);
    }
}
