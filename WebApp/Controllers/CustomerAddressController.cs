using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Dto;
using WebApp.Core.Data;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CustomerAddressController : Controller
    {
        private readonly IRepo<CustomerAddressDto> repo;

        public CustomerAddressController(IRepo<CustomerAddressDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerAddressDto>> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<CustomerAddressDto> Get(int id)
        {
            return await repo.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromForm]CustomerAddressDto product)
        {
            await repo.Add(product);
        }

        [HttpPut]
        public async Task Update([FromForm]CustomerAddressDto product)
        {
            await repo.Update(product);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repo.Delete(id);
        }
    }
}
