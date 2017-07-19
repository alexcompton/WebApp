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
    public class ProductCategoryRepo : BaseRepo, IProductCategoryRepo
    {
        public async Task Add(ProductCategoryDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[ProductCategory] 
                            (
                                ProductCategoryID, 
                                ParentProductCategoryID, 
                                Name, 
                                rowguid, 
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @ProductCategoryID, 
                                @ParentProductCategoryID, 
                                @Name, 
                                @rowguid, 
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        ProductCategoryID = t.ProductCategoryID,
                        ParentProductCategoryID = t.ParentProductCategoryID,
                        Name = t.Name,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[ProductCategory]
                            WHERE ProductCategoryID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[ProductCategory]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<ProductCategoryDto>(query);
            }
        }

        public async Task<ProductCategoryDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[ProductCategory]
                            WHERE ProductCategoryID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<ProductCategoryDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(ProductCategoryDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[ProductCategory]
                            SET                                 
                                ParentProductCategoryID = @ParentProductCategoryID,
                                Name = @Name,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE ProductCategoryID = @ProductCategoryID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        ProductCategoryID = t.ProductCategoryID,
                        ParentProductCategoryID = t.ParentProductCategoryID,
                        Name = t.Name,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}
