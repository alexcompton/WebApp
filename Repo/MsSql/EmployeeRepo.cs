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
    public class EmployeeRepo : BaseRepo, IEmployeeRepo
    {
        public async Task Add(EmployeeDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[Employee] 
                            (
                                EmployeeTypeId, 
                                JobTitle, 
                                FirstName, 
                                LastName, 
                                Email, 
                                DomainName 
                            ) 
                            VALUES 
                            (
                                @EmployeeTypeId, 
                                @JobTitle, 
                                @FirstName, 
                                @LastName, 
                                @Email, 
                                @DomainName 
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        EmployeeTypeId = t.EmployeeTypeId,
                        JobTitle = t.JobTitle,
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        Email = t.Email,
                        DomainName = t.DomainName
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[Employee]
                            WHERE EmployeeID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[Employee]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<EmployeeDto>(query);
            }
        }

        public async Task<EmployeeDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[Employee]
                            WHERE EmployeeID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<EmployeeDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(EmployeeDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[Employee]
                            SET
                                EmployeeTypeId = @EmployeeTypeId,
                                JobTitle = @JobTitle,
                                FirstName = @FirstName,
                                LastName = @LastName,
                                Email = @Email,
                                DomainName = @DomainName
                            WHERE EmployeeId = @EmployeeId;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                        EmployeeId = t.EmployeeId,
                        EmployeeTypeId = t.EmployeeTypeId,
                        JobTitle = t.JobTitle,
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        Email = t.Email,
                        DomainName = t.DomainName
                });
            }
        }
    }
}