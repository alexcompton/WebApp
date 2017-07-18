using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class SalesOrderHeaderService : ISalesOrderHeaderService
    {
        private ISalesOrderHeaderRepo repo;
        public SalesOrderHeaderService(ISalesOrderHeaderRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(SalesOrderHeaderDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<SalesOrderHeaderDto>> GetAll() => await repo.GetAll();
        public async Task<SalesOrderHeaderDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(SalesOrderHeaderDto t) => await repo.Update(t);
    }
}