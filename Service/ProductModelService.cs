using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class ProductModelService : IProductModelService
    {
        private IProductModelRepo repo;
        public ProductModelService(IProductModelRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(ProductModelDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<ProductModelDto>> GetAll() => await repo.GetAll();
        public async Task<ProductModelDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(ProductModelDto t) => await repo.Update(t);
    }
}