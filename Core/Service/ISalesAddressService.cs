﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto;

namespace WebApp.Core.Service
{
    public interface ISalesAddressService : ICrudService<SalesAddressDto>
    {
        Task<IEnumerable<SalesAddressDto>> GetByEmployeeID(int id);
    }
}
