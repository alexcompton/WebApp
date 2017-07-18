using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class AddressService: IAddressService
    {
        private IAddressRepo repo;
        public AddressService(IAddressRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(AddressDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<AddressDto>> GetAll() => await repo.GetAll();
        public async Task<AddressDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(AddressDto t) => await repo.Update(t);
    }
}
