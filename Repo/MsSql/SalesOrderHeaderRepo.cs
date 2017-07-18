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
    public class SalesOrderHeaderRepo : BaseRepo, ISalesOrderHeaderRepo
    {
        public async Task Add(SalesOrderHeaderDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[SalesOrderHeader]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<SalesOrderHeaderDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[SalesOrderHeader]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<SalesOrderHeaderDto>(query);
            }
        }

        public async Task<SalesOrderHeaderDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[SalesOrderHeader]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesOrderHeaderDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(SalesOrderHeaderDto t)
        {
            throw new NotImplementedException();
        }
    }
}
