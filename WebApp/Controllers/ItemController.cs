using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repo.DocumentDB;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAll()
        {
            return await DocumentDBRepository<Item>.GetItemsAsync(d => !d.Completed);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "not implemented yet";
        }
        
        [HttpPost]
        public string Post([FromForm]Item item)
        {
            return "not implemented yet";
        }
        
        [HttpPut]
        public string Put([FromForm]Item item)
        {
            return "not implemented yet";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "not implemented yet";
        }
    }
}