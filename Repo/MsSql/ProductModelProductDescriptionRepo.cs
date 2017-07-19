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
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[ProductModelProductDescription] 
                            (
                                ProductModelID,
                                ProductDescriptionID,
                                Culture,
                                rowguid,
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @ProductModelID,
                                @ProductDescriptionID,
                                @Culture,
                                @rowguid,
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        ProductModelID = t.ProductModelID,
                        ProductDescriptionID = t.ProductDescriptionID,
                        Culture = t.Culture,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
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
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[ProductModelProductDescription]
                            SET 
                                ProductDescriptionID = @ProductDescriptionID,
                                Culture = @Culture,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE ProductModelID = @ProductModelID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        ProductModelID = t.ProductModelID,
                        ProductDescriptionID = t.ProductDescriptionID,
                        Culture = t.Culture,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}