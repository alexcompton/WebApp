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
    public class CustomerController : Controller
    {
        private readonly IRepo<CustomerDao> repo;

        public CustomerController(IRepo<CustomerDao> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDao>> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<CustomerDao> Get(int id)
        {
            return await repo.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromForm]CustomerDao product)
        {
            await repo.Add(product);
        }

        [HttpPut]
        public async Task Update([FromForm]CustomerDao product)
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
