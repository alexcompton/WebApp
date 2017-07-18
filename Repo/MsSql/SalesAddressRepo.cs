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
    public class SalesAddressRepo : BaseRepo, ISalesAddressRepo
    {
        public async Task Add(SalesAddressDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[SalesAddress]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<SalesAddressDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[SalesAddress]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<SalesAddressDto>(query);
            }
        }

        public async Task<IEnumerable<SalesAddressDto>> GetByEmployeeID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesAddressDto>("[dbo].[usp_GetCustAddress_ByEmployee]", new { EmployeeId = id },
                    commandType: CommandType.StoredProcedure);
                return list.AsList();
            }
        }

        public async Task<SalesAddressDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[SalesAddress]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesAddressDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(SalesAddressDto t)
        {
            throw new NotImplementedException();
        }
    }
}
