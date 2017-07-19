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
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[Product] 
                            (
                                ProductID,
                                Name,
                                ProductNumber,
                                Color,
                                StandardCost,
                                ListPrice,
                                Size,
                                Weight,
                                ProductCategoryID,
                                ProductModelID,
                                SellStartDate,
                                SellEndDate,
                                DiscontinuedDate,
                                ThumbNailPhoto,
                                ThumbnailPhotoFileName,
                                rowguid,
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @ProductID,
                                @Name,
                                @ProductNumber,
                                @Color,
                                @StandardCost,
                                @ListPrice,
                                @Size,
                                @Weight,
                                @ProductCategoryID,
                                @ProductModelID,
                                @SellStartDate,
                                @SellEndDate,
                                @DiscontinuedDate,
                                @ThumbNailPhoto,
                                @ThumbnailPhotoFileName,
                                @rowguid,
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        ProductID = t.ProductID,
                        Name = t.Name,
                        ProductNumber = t.ProductNumber,
                        Color = t.Color,
                        StandardCost = t.StandardCost,
                        ListPrice = t.ListPrice,
                        Size = t.Size,
                        Weight = t.Weight,
                        ProductCategoryID = t.ProductCategoryID,
                        ProductModelID = t.ProductModelID,
                        SellStartDate = t.SellStartDate,
                        SellEndDate = t.SellEndDate,
                        DiscontinuedDate = t.DiscontinuedDate,
                        ThumbNailPhoto = t.ThumbNailPhoto,
                        ThumbnailPhotoFileName = t.ThumbnailPhotoFileName,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
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
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[Product]
                            SET 
                                Name = @Name,
                                ProductNumber = @ProductNumber,
                                Color = @Color,
                                StandardCost = @StandardCost,
                                ListPrice = @ListPrice,
                                Size = @Size,
                                Weight = @Weight,
                                ProductCategoryID = @ProductCategoryID,
                                ProductModelID = @ProductModelID,
                                SellStartDate = @SellStartDate,
                                SellEndDate = @SellEndDate,
                                DiscontinuedDate = @DiscontinuedDate,
                                ThumbNailPhoto = @ThumbNailPhoto,
                                ThumbnailPhotoFileName = @ThumbnailPhotoFileName,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE ProductID = @ProductID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        ProductID = t.ProductID,
                        Name = t.Name,
                        ProductNumber = t.ProductNumber,
                        Color = t.Color,
                        StandardCost = t.StandardCost,
                        ListPrice = t.ListPrice,
                        Size = t.Size,
                        Weight = t.Weight,
                        ProductCategoryID = t.ProductCategoryID,
                        ProductModelID = t.ProductModelID,
                        SellStartDate = t.SellStartDate,
                        SellEndDate = t.SellEndDate,
                        DiscontinuedDate = t.DiscontinuedDate,
                        ThumbNailPhoto = t.ThumbNailPhoto,
                        ThumbnailPhotoFileName = t.ThumbnailPhotoFileName,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}