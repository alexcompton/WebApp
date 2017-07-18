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
    public class ProductModelRepo : BaseRepo, IProductModelRepo
    {
        public async Task Add(ProductModelDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[ProductModel]
                            WHERE ProductModelID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<ProductModelDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[ProductModel]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<ProductModelDto>(query);
            }
        }

        public async Task<ProductModelDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[ProductModel]
                            WHERE ProductModelID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<ProductModelDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(ProductModelDto t)
        {
            throw new NotImplementedException();
        }
    }
}
