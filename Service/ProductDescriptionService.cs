using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class ProductDescriptionService : IProductDescriptionService
    {
        private IProductDescriptionRepo repo;
        public ProductDescriptionService(IProductDescriptionRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(ProductDescriptionDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<ProductDescriptionDto>> GetAll() => await repo.GetAll();
        public async Task<ProductDescriptionDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(ProductDescriptionDto t) => await repo.Update(t);
    }
}