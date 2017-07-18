using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepo repo;
        public ProductCategoryService(IProductCategoryRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(ProductCategoryDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<ProductCategoryDto>> GetAll() => await repo.GetAll();
        public async Task<ProductCategoryDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(ProductCategoryDto t) => await repo.Update(t);
    }
}