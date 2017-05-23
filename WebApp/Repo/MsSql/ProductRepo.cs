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
    public class ProductRepo : BaseCrudRepo<ProductDto>
    {
        public ProductRepo() : base("[SalesLT].[Product]", "ProductID") { }

    }
}
