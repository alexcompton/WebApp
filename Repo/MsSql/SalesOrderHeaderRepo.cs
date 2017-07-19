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
    public class SalesOrderHeaderRepo : BaseRepo, ISalesOrderHeaderRepo
    {
        public async Task Add(SalesOrderHeaderDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[SalesOrderHeader] 
                            (
                                SalesOrderID,
                                RevisionNumber,
                                OrderDate,
                                DueDate,
                                ShipDate,
                                Status,
                                OnlineOrderFlag,
                                SalesOrderNumber,
                                PurchaseOrderNumber,
                                AccountNumber,
                                CustomerID,
                                ShipToAddressID,
                                BillToAddressID,
                                ShipMethod,
                                CreditCardApprovalCode,
                                SubTotal,
                                TaxAmt,
                                Freight,
                                TotalDue,
                                Comment,
                                rowguid,
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @SalesOrderID,
                                @RevisionNumber,
                                @OrderDate,
                                @DueDate,
                                @ShipDate,
                                @Status,
                                @OnlineOrderFlag,
                                @SalesOrderNumber,
                                @PurchaseOrderNumber,
                                @AccountNumber,
                                @CustomerID,
                                @ShipToAddressID,
                                @BillToAddressID,
                                @ShipMethod,
                                @CreditCardApprovalCode,
                                @SubTotal,
                                @TaxAmt,
                                @Freight,
                                @TotalDue,
                                @Comment,
                                @rowguid,
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        SalesOrderID = t.SalesOrderID,
                        RevisionNumber = t.RevisionNumber,
                        OrderDate = t.OrderDate,
                        DueDate = t.DueDate,
                        ShipDate = t.ShipDate,
                        Status = t.Status,
                        OnlineOrderFlag = t.OnlineOrderFlag,
                        SalesOrderNumber = t.SalesOrderNumber,
                        PurchaseOrderNumber = t.PurchaseOrderNumber,
                        AccountNumber = t.AccountNumber,
                        CustomerID = t.CustomerID,
                        ShipToAddressID = t.ShipToAddressID,
                        BillToAddressID = t.BillToAddressID,
                        ShipMethod = t.ShipMethod,
                        CreditCardApprovalCode = t.CreditCardApprovalCode,
                        SubTotal = t.SubTotal,
                        TaxAmt = t.TaxAmt,
                        Freight = t.Freight,
                        TotalDue = t.TotalDue,
                        Comment = t.Comment,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[SalesOrderHeader]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<SalesOrderHeaderDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[SalesOrderHeader]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<SalesOrderHeaderDto>(query);
            }
        }

        public async Task<SalesOrderHeaderDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[SalesOrderHeader]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesOrderHeaderDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(SalesOrderHeaderDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[SalesOrderHeader]
                            SET 
                                RevisionNumber = @RevisionNumber,
                                OrderDate = @OrderDate,
                                DueDate = @DueDate,
                                ShipDate = @ShipDate,
                                Status = @Status,
                                OnlineOrderFlag = @OnlineOrderFlag,
                                SalesOrderNumber = @SalesOrderNumber,
                                PurchaseOrderNumber = @PurchaseOrderNumber,
                                AccountNumber = @AccountNumber,
                                CustomerID = @CustomerID,
                                ShipToAddressID = @ShipToAddressID,
                                BillToAddressID = @BillToAddressID,
                                ShipMethod = @ShipMethod,
                                CreditCardApprovalCode = @CreditCardApprovalCode,
                                SubTotal = @SubTotal,
                                TaxAmt = @TaxAmt,
                                Freight = @Freight,
                                TotalDue = @TotalDue,
                                Comment = @Comment,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE SalesOrderID = @SalesOrderID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        SalesOrderID = t.SalesOrderID,
                        RevisionNumber = t.RevisionNumber,
                        OrderDate = t.OrderDate,
                        DueDate = t.DueDate,
                        ShipDate = t.ShipDate,
                        Status = t.Status,
                        OnlineOrderFlag = t.OnlineOrderFlag,
                        SalesOrderNumber = t.SalesOrderNumber,
                        PurchaseOrderNumber = t.PurchaseOrderNumber,
                        AccountNumber = t.AccountNumber,
                        CustomerID = t.CustomerID,
                        ShipToAddressID = t.ShipToAddressID,
                        BillToAddressID = t.BillToAddressID,
                        ShipMethod = t.ShipMethod,
                        CreditCardApprovalCode = t.CreditCardApprovalCode,
                        SubTotal = t.SubTotal,
                        TaxAmt = t.TaxAmt,
                        Freight = t.Freight,
                        TotalDue = t.TotalDue,
                        Comment = t.Comment,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}
