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
    public class ProductModelProductDescriptionRepo : BaseRepo, IProductModelProductDescriptionRepo
    {
        public async Task Add(ProductModelProductDescriptionDto t)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[ProductModelProductDescription]
                            WHERE ProductModelID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<ProductModelProductDescriptionDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[ProductModelProductDescription]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<ProductModelProductDescriptionDto>(query);
            }
        }

        public async Task<ProductModelProductDescriptionDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[ProductModelProductDescription]
                            WHERE ProductModelID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<ProductModelProductDescriptionDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(ProductModelProductDescriptionDto t)
        {
            throw new NotImplementedException();
        }
    }
}