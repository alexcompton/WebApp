using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Dto;

namespace WebApp.Service
{
    public class CustomerService : BaseCrudService<CustomerDto>
    {
        public CustomerService(ICrudRepo<CustomerDto> repo) : base(repo) { }

    }
}
