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
    public class ProductRepo : BaseRepo, IProductRepo
    {
        public async Task Add(ProductDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[Product]
                            WHERE ProductID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[Product]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<ProductDto>(query);
            }
        }

        public async Task<ProductDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[Product]
                            WHERE ProductID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<ProductDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(ProductDto t)
        {
            throw new NotImplementedException();
        }
    }
}