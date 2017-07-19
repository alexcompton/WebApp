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
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[ProductModel] 
                            (
                                ProductModelID,
                                Name,
                                CatalogDescription,
                                rowguid,
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @ProductModelID,
                                @Name,
                                @CatalogDescription,
                                @rowguid,
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        ProductModelID = t.ProductModelID,
                        Name = t.Name,
                        CatalogDescription = t.CatalogDescription,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
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
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[ProductModel]
                            SET 
                                Name = @Name,
                                CatalogDescription = @CatalogDescription,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE ProductModelID = @ProductModelID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        ProductModelID = t.ProductModelID,
                        Name = t.Name,
                        CatalogDescription = t.CatalogDescription,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}
