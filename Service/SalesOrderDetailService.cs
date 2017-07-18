using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class SalesOrderDetailService : ISalesOrderDetailService
    {
        private ISalesOrderDetailRepo repo;
        public SalesOrderDetailService(ISalesOrderDetailRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(SalesOrderDetailDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<SalesOrderDetailDto>> GetAll() => await repo.GetAll();
        public async Task<SalesOrderDetailDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(SalesOrderDetailDto t) => await repo.Update(t);
    }
}