using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Dao;
using WebApp.Repo.MsSql;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ProductRepo repo;

        public ProductController()
        {
            this.repo = new ProductRepo();
        }

        [HttpGet]
        public IEnumerable<ProductDao> GetAll()
        {
            return repo.GetAll();
        }
    }
}
