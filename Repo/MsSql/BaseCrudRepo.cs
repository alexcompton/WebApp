using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Data;

namespace WebApp.Repo.MsSql
{
    public abstract class BaseRepo
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(@"Server=acompton11.database.windows.net;Database=AdventureWorks;User Id=user;Password=P@ssword;");
            }            
        }
    }
}
