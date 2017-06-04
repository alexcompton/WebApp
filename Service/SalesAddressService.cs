using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class SalesAddressService: ISalesAddressService<SalesAddressDto>
    {
        private readonly ISalesAddressRepo<SalesAddressDto> repo;

        public SalesAddressService(ISalesAddressRepo<SalesAddressDto> repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<SalesAddressDto>> GetByID(int id) => await repo.GetByID(id);
    }
}
