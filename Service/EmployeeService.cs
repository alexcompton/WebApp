using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepo repo;
        public EmployeeService(IEmployeeRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(EmployeeDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<EmployeeDto>> GetAll() => await repo.GetAll();
        public async Task<EmployeeDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(EmployeeDto t) => await repo.Update(t);
    }
}