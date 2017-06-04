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
            var items = await DocumentDBRepository<Item>.GetItemsAsync(i => true);
            return items;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "not implemented yet";
        }
        
        [HttpPost]
        public async Task Post([FromBody]Item item)
        {
            await DocumentDBRepository<Item>.CreateItemAsync(item);
        }
        
        [HttpPut]
        public async Task Put([FromBody]Item item)
        {
            await DocumentDBRepository<Item>.UpdateItemAsync(item.Id, item);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "not implemented yet";
        }
    }
}