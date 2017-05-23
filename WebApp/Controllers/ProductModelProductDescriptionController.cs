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
    public class ProductModelProductDescriptionController : Controller
    {
        private readonly ICrudService<ProductModelProductDescriptionDto> service;

        public ProductModelProductDescriptionController(ICrudService<ProductModelProductDescriptionDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductModelProductDescriptionDto>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ProductModelProductDescriptionDto> Get(int id)
        {
            return await service.GetByID(id);
        }

        [HttpPost]
        public async Task Add([FromForm]ProductModelProductDescriptionDto product)
        {
            await service.Add(product);
        }

        [HttpPut]
        public async Task Update([FromForm]ProductModelProductDescriptionDto product)
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
