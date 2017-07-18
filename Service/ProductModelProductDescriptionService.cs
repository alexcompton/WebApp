using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class ProductModelProductDescriptionService : IProductModelProductDescriptionService
    {
        private IProductModelProductDescriptionRepo repo;
        public ProductModelProductDescriptionService(IProductModelProductDescriptionRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(ProductModelProductDescriptionDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<ProductModelProductDescriptionDto>> GetAll() => await repo.GetAll();
        public async Task<ProductModelProductDescriptionDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(ProductModelProductDescriptionDto t) => await repo.Update(t);
    }
}