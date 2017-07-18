using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class ProductService : IProductService
    {
        private IProductRepo repo;
        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(ProductDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<ProductDto>> GetAll() => await repo.GetAll();
        public async Task<ProductDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(ProductDto t) => await repo.Update(t);
    }
}