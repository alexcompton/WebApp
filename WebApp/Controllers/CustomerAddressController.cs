using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Data.Dao;
using WebApp.Core.Data;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CustomerAddressController : Controller
    {
        private readonly IRepo<CustomerAddressDao> repo;

        public CustomerAddressController(IRepo<CustomerAddressDao> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerAddressDao>> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<CustomerAddressDao> Get(int id)
        {
            return await repo.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromForm]CustomerAddressDao product)
        {
            await repo.Add(product);
        }

        [HttpPut]
        public async Task Update([FromForm]CustomerAddressDao product)
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
