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
    public class AddressRepo : BaseRepo, IAddressRepo
    {
        public async Task Add(AddressDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[Address]
                            WHERE AddressID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[Address]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<AddressDto>(query);
            }
        }

        public async Task<AddressDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[Address]
                            WHERE AddressID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<AddressDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(AddressDto t)
        {
            throw new NotImplementedException();
        }
    }
}