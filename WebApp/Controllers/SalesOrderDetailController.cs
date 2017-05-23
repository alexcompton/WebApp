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
    public class SalesOrderDetailController : Controller
    {
        private readonly IRepo<SalesOrderDetailDto> repo;

        public SalesOrderDetailController(IRepo<SalesOrderDetailDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<SalesOrderDetailDto>> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<SalesOrderDetailDto> Get(int id)
        {
            return await repo.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromForm]SalesOrderDetailDto product)
        {
            await repo.Add(product);
        }

        [HttpPut]
        public async Task Update([FromForm]SalesOrderDetailDto product)
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
