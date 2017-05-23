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
    public class SalesOrderHeaderController : Controller
    {
        private readonly IRepo<SalesOrderHeaderDto> repo;

        public SalesOrderHeaderController(IRepo<SalesOrderHeaderDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<SalesOrderHeaderDto>> GetAll()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<SalesOrderHeaderDto> Get(int id)
        {
            return await repo.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromForm]SalesOrderHeaderDto product)
        {
            await repo.Add(product);
        }

        [HttpPut]
        public async Task Update([FromForm]SalesOrderHeaderDto product)
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
