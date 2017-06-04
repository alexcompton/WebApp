using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Data
{
    public interface ISalesAddressRepo<T>
    {
        Task<IEnumerable<T>> GetByID(int id);
    }
}
