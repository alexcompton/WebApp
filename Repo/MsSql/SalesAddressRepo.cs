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
    public class SalesAddressRepo : BaseRepo, ISalesAddressRepo
    {
        public async Task Add(SalesAddressDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[SalesAddress] 
                            (
                                CustomerName,
                                CompanyName,
                                Phone,
                                EmailAddress,
                                AddressType,
                                Address
                            ) 
                            VALUES 
                            (
                                @CustomerName,
                                @CompanyName,
                                @Phone,
                                @EmailAddress,
                                @AddressType,
                                @Address
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        CustomerName = t.CustomerName,
                        CompanyName = t.CompanyName,
                        Phone = t.Phone,
                        EmailAddress = t.EmailAddress,
                        AddressType = t.AddressType,
                        Address = t.Address
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[SalesAddress]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<SalesAddressDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[SalesAddress]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<SalesAddressDto>(query);
            }
        }

        public async Task<IEnumerable<SalesAddressDto>> GetByEmployeeID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesAddressDto>("[dbo].[usp_GetCustAddress_ByEmployee]", new { EmployeeId = id },
                    commandType: CommandType.StoredProcedure);
                return list.AsList();
            }
        }

        public async Task<SalesAddressDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[SalesAddress]
                            WHERE SalesOrderID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesAddressDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(SalesAddressDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[SalesAddress]
                            SET 
                                CompanyName = @CompanyName,
                                Phone = @Phone,
                                EmailAddress = @EmailAddress,
                                AddressType = @AddressType,
                                Address = @Address
                            WHERE CustomerName = @CustomerName;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        CustomerName = t.CustomerName,
                        CompanyName = t.CompanyName,
                        Phone = t.Phone,
                        EmailAddress = t.EmailAddress,
                        AddressType = t.AddressType,
                        Address = t.Address
                });
            }
        }
    }
}
