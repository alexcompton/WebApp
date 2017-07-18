using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class SalesAddressService: ISalesAddressService
    {
        private readonly ISalesAddressRepo repo;

        public SalesAddressService(ISalesAddressRepo repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<SalesAddressDto>> GetByEmployeeID(int id) => await repo.GetByEmployeeID(id);
        public async Task Add(SalesAddressDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<SalesAddressDto>> GetAll() => await repo.GetAll();
        public async Task<SalesAddressDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(SalesAddressDto t) => await repo.Update(t);
    }
}
