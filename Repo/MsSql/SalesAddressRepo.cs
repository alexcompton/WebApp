
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApp.Core.Data;
using WebApp.Dto;

namespace WebApp.Repo.MsSql
{
    public class SalesAddressRepo : ISalesAddressRepo<SalesAddressDto>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(@"Server=acompton11.database.windows.net;Database=AdventureWorks;User Id=user;Password=P@ssword;");
            }
        }

        public SalesAddressRepo() { }

        public async Task<IEnumerable<SalesAddressDto>> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<SalesAddressDto>("[dbo].[usp_GetCustAddress_ByEmployee]", new { EmployeeId = id },
                    commandType: CommandType.StoredProcedure);
                return list.AsList();
            }
        }
    }
}
