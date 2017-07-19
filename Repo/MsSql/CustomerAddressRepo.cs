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
    public class CustomerAddressRepo : BaseRepo, ICustomerAddressRepo
    {
        public async Task Add(CustomerAddressDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[CustomerAddress] 
                            (
                                CustomerID, 
                                AddressID, 
                                AddressType, 
                                rowguid, 
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @CustomerID, 
                                @AddressID, 
                                @AddressType, 
                                @rowguid, 
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        CustomerID = t.CustomerID,
                        AddressID = t.AddressID,
                        AddressType = t.AddressType,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[CustomerAddress]
                            WHERE CustomerID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<CustomerAddressDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[CustomerAddress]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<CustomerAddressDto>(query);
            }
        }

        public async Task<CustomerAddressDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[CustomerAddress]
                            WHERE CustomerID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<CustomerAddressDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(CustomerAddressDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[CustomerAddress]
                            SET 
                                AddressID = @AddressID,
                                AddressType = @AddressType,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE CustomerID = @CustomerID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                    CustomerID = t.CustomerID,
                    AddressID = t.AddressID,
                    AddressType = t.AddressType,
                    rowguid = t.rowguid,
                    ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}