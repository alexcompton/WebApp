﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;

namespace WebApp.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepo repo;
        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public async Task Add(CustomerDto t) => await repo.Add(t);
        public async Task Delete(int id) => await repo.Delete(id);
        public async Task<IEnumerable<CustomerDto>> GetAll() => await repo.GetAll();
        public async Task<CustomerDto> GetByID(int id) => await repo.GetByID(id);
        public async Task Update(CustomerDto t) => await repo.Update(t);
    }
}