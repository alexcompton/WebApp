﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Dto;
using WebApp.Core.Data;
using WebApp.Core.Service;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class SalesOrderHeaderController : Controller
    {
        private readonly ISalesOrderHeaderService service;

        public SalesOrderHeaderController(ISalesOrderHeaderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SalesOrderHeaderDto>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<SalesOrderHeaderDto> Get(int id)
        {
            return await service.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromBody]SalesOrderHeaderDto product)
        {
            await service.Add(product);
        }

        [HttpPut]
        public async Task Update([FromBody]SalesOrderHeaderDto product)
        {
            await service.Update(product);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}
