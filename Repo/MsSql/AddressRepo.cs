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
    public class AddressRepo : BaseRepo, IAddressRepo
    {
        public async Task Add(AddressDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"INSERT INTO [SalesLT].[Address] 
                            (
                                AddressID, 
                                AddressLine1, 
                                AddressLine2, 
                                City, 
                                StateProvince, 
                                CountryRegion, 
                                PostalCode, 
                                rowguid, 
                                ModifiedDate
                            ) 
                            VALUES 
                            (
                                @AddressID, 
                                @AddressLine1, 
                                @AddressLine2, 
                                @City, 
                                @StateProvince, 
                                @CountryRegion, 
                                @PostalCode, 
                                @rowguid, 
                                @ModifiedDate
                            );";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query,
                    new
                    {
                        AddressID = t.AddressID,
                        AddressLine1 = t.AddressLine1,
                        AddressLine2 = t.AddressLine2,
                        City = t.City,
                        StateProvince = t.StateProvince,
                        CountryRegion = t.CountryRegion,
                        PostalCode = t.PostalCode,
                        rowguid = t.rowguid,
                        ModifiedDate = t.ModifiedDate
                    });
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"DELETE FROM [SalesLT].[Address]
                            WHERE AddressID = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM [SalesLT].[Address]";
                dbConnection.Open();
                return await dbConnection.QueryAsync<AddressDto>(query);
            }
        }

        public async Task<AddressDto> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"SELECT * FROM [SalesLT].[Address]
                            WHERE AddressID = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<AddressDto>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public async Task Update(AddressDto t)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"UPDATE [SalesLT].[Address]
                            SET 
                                AddressLine1 = @AddressLine1, 
                                AddressLine2 = @AddressLine2, 
                                City = @City, 
                                StateProvince = @StateProvince, 
                                CountryRegion = @CountryRegion, 
                                PostalCode = @PostalCode, 
                                rowguid = @rowguid, 
                                ModifiedDate = @ModifiedDate
                            WHERE AddressID = @AddressID;";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new
                {
                    AddressID = t.AddressID,
                    AddressLine1 = t.AddressLine1,
                    AddressLine2 = t.AddressLine2,
                    City = t.City,
                    StateProvince = t.StateProvince,
                    CountryRegion = t.CountryRegion,
                    PostalCode = t.PostalCode,
                    rowguid = t.rowguid,
                    ModifiedDate = t.ModifiedDate
                });
            }
        }
    }
}