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
    public class CustomerRepo : BaseRepo, ICustomerRepo
    {
        public async Task Add(CustomerDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[Customer] 
                            (
                                CustomerID, 
                                NameStyle, 
                                Title, 
                                FirstName, 
                                MiddleName, 
                                LastName, 
                                Suffix, 
                                CompanyName, 
                                SalesPerson, 
                                EmailAddress, 
                                Phone, 
                                PasswordHash, 
                                PasswordSalt, 
                                rowguid, 
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @CustomerID, 
                                @NameStyle, 
                                @Title, 
                                @FirstName, 
                                @MiddleName, 
                                @LastName, 
                                @Suffix, 
                                @CompanyName, 
                                @SalesPerson, 
                                @EmailAddress, 
                                @Phone, 
                                @PasswordHash, 
                                @PasswordSalt, 
                                @rowguid, 
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        CustomerID = t.CustomerID,
                        NameStyle = t.NameStyle,
                        Title = t.Title,
                        FirstName = t.FirstName,
                        MiddleName = t.MiddleName,
                        LastName = t.LastName,
                        Suffix = t.Suffix,
                        CompanyName = t.CompanyName,
                        SalesPerson = t.SalesPerson,
                        EmailAddress = t.EmailAddress,
                        Phone = t.Phone,
                        PasswordHash = t.PasswordHash,
                        PasswordSalt = t.PasswordSalt,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[Customer]
                            WHERE CustomerID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[Customer]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<CustomerDto>(query);
            }
        }

        public async Task<CustomerDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[Customer]
                            WHERE CustomerID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<CustomerDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(CustomerDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[Customer]
                            SET                                 
                                NameStyle = @NameStyle,
                                Title = @Title,
                                FirstName = @FirstName,
                                MiddleName = @MiddleName,
                                LastName = @LastName,
                                Suffix = @Suffix,
                                CompanyName = @CompanyName,
                                SalesPerson = @SalesPerson,
                                EmailAddress = @EmailAddress,
                                Phone = @Phone,
                                PasswordHash = @PasswordHash,
                                PasswordSalt = @PasswordSalt,
                                rowguid = @rowguid,
                                ModifiedDate = @ModifiedDate
                            WHERE CustomerID = @CustomerID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        CustomerID = t.CustomerID,
                        NameStyle = t.NameStyle,
                        Title = t.Title,
                        FirstName = t.FirstName,
                        MiddleName = t.MiddleName,
                        LastName = t.LastName,
                        Suffix = t.Suffix,
                        CompanyName = t.CompanyName,
                        SalesPerson = t.SalesPerson,
                        EmailAddress = t.EmailAddress,
                        Phone = t.Phone,
                        PasswordHash = t.PasswordHash,
                        PasswordSalt = t.PasswordSalt,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}