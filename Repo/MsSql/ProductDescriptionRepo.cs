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
    public class ProductDescriptionRepo : BaseRepo, IProductDescriptionRepo
    {
        public async Task Add(ProductDescriptionDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[ProductDescription] 
                            (
                                ProductDescriptionID, 
                                Description, 
                                rowguid, 
                                ModifiedDate 
                            ) 
                            VALUES 
                            (
                                @ProductDescriptionID, 
                                @Description, 
                                @rowguid, 
                                @ModifiedDate 
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        ProductDescriptionID = t.ProductDescriptionID,
                        Description = t.Description,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[ProductDescription]
                            WHERE ProductDescriptionID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<ProductDescriptionDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[ProductDescription]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<ProductDescriptionDto>(query);
            }
        }

        public async Task<ProductDescriptionDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[ProductDescription]
                            WHERE ProductDescriptionID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<ProductDescriptionDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(ProductDescriptionDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[ProductDescription]
                            SET 
                                Description = @Description,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE ProductDescriptionID = @ProductDescriptionID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        ProductDescriptionID = t.ProductDescriptionID,
                        Description = t.Description,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}