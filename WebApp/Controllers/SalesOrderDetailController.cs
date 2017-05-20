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
    public class SalesOrderDetailController : Controller
    {
        private readonly IRepo<SalesOrderDetailDao> repo;

        public SalesOrderDetailController(IRepo<SalesOrderDetailDao> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<SalesOrderDetailDao>> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<SalesOrderDetailDao> Get(int id)
        {
            return await repo.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromForm]SalesOrderDetailDao product)
        {
            await repo.Add(product);
        }

        [HttpPut]
        public async Task Update([FromForm]SalesOrderDetailDao product)
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
