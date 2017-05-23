using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Dto;

namespace WebApp.Repo.MsSql
{
    public class CustomerRepo : BaseRepo<CustomerDto>
    {
        public CustomerRepo() : base("[SalesLT].[Customer]", "CustomerID") { }

    }
}
