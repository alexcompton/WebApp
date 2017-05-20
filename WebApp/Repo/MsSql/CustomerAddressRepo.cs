using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Core.Data.Dao;

namespace WebApp.Repo.MsSql
{
    public class CustomerAddressRepo : BaseRepo<CustomerAddressDao>
    {
        public CustomerAddressRepo() : base("[SalesLT].[CustomerAddress]", "CustomerID") { }

    }
}
