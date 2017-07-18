using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private ICustomerAddressRepo repo;
        public CustomerAddressService(ICustomerAddressRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(CustomerAddressDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<CustomerAddressDto>> GetAll() => await repo.GetAll();
        public async Task<CustomerAddressDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(CustomerAddressDto t) => await repo.Update(t);
    }
}