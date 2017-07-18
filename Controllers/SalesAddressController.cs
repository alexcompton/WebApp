using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Dto;
using WebApp.Core.Service;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class SalesAddressController : Controller
    {
        private readonly ISalesAddressService service;

        public SalesAddressController(ISalesAddressService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<SalesAddressDto>> Get(int id)
        {
            return await service.GetByEmployeeID(id);
        }
    }
}
