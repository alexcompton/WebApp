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
    public class SalesOrderDetailRepo : BaseRepo, ISalesOrderDetailRepo
    {
        public async Task Add(SalesOrderDetailDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[SalesOrderDetail] 
                            (
                                SalesOrderID,
                                SalesOrderDetailID,
                                OrderQty,
                                ProductID,
                                UnitPrice,
                                UnitPriceDiscount,
                                LineTotal,
                                rowguid,
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @SalesOrderID,
                                @SalesOrderDetailID,
                                @OrderQty,
                                @ProductID,
                                @UnitPrice,
                                @UnitPriceDiscount,
                                @LineTotal,
                                @rowguid,
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        SalesOrderID = t.SalesOrderID,
                        SalesOrderDetailID = t.SalesOrderDetailID,
                        OrderQty = t.OrderQty,
                        ProductID = t.ProductID,
                        UnitPrice = t.UnitPrice,
                        UnitPriceDiscount = t.UnitPriceDiscount,
                        LineTotal = t.LineTotal,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[SalesOrderDetail]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<SalesOrderDetailDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[SalesOrderDetail]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<SalesOrderDetailDto>(query);
            }
        }

        public async Task<SalesOrderDetailDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[SalesOrderDetail]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesOrderDetailDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(SalesOrderDetailDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[SalesOrderDetail]
                            SET 
                                SalesOrderDetailID = @SalesOrderDetailID,
                                OrderQty = @OrderQty,
                                ProductID = @ProductID,
                                UnitPrice = @UnitPrice,
                                UnitPriceDiscount = @UnitPriceDiscount,
                                LineTotal = @LineTotal,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE SalesOrderID = @SalesOrderID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        SalesOrderID = t.SalesOrderID,
                        SalesOrderDetailID = t.SalesOrderDetailID,
                        OrderQty = t.OrderQty,
                        ProductID = t.ProductID,
                        UnitPrice = t.UnitPrice,
                        UnitPriceDiscount = t.UnitPriceDiscount,
                        LineTotal = t.LineTotal,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}
