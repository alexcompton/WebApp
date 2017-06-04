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
    public class SalesOrderDetailRepo : BaseCrudRepo<SalesOrderDetailDto>
    {
        public SalesOrderDetailRepo() : base("[SalesLT].[SalesOrderDetail]", "SalesOrderID") { }

    }
}
