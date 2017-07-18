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
    public class CustomerRepo : BaseRepo, ICustomerRepo
    {
        public async Task Add(CustomerDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[Customer]
                            WHERE CustomerID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[Customer]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<CustomerDto>(query);
            }
        }

        public async Task<CustomerDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[Customer]
                            WHERE CustomerID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<CustomerDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(CustomerDto t)
        {
            throw new NotImplementedException();
        }
    }
}