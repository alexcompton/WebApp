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
    public class SalesOrderDetailRepo : BaseRepo, ISalesOrderDetailRepo
    {
        public async Task Add(SalesOrderDetailDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[SalesOrderDetail]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<SalesOrderDetailDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[SalesOrderDetail]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<SalesOrderDetailDto>(query);
            }
        }

        public async Task<SalesOrderDetailDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[SalesOrderDetail]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesOrderDetailDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(SalesOrderDetailDto t)
        {
            throw new NotImplementedException();
        }
    }
}
