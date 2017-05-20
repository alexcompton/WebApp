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
    public abstract class BaseRepo<T> : IRepo<T>
    {
        private string crudTableName;
        private string primaryKey;

        public BaseRepo(string crudTableName, string primaryKey)
        {
            this.crudTableName = crudTableName;
            this.primaryKey = primaryKey;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(@"Server=acompton11.database.windows.net;Database=AdventureWorks;User Id=user;Password=P@ssword;");
            }            
        }

        public virtual async Task Add(T t)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM " + crudTableName;
                dbConnection.Open();
                return await dbConnection.QueryAsync<T>(query);
            }
        }

        public virtual async Task<T> GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM " + crudTableName + 
                    " Where " + primaryKey + " = @Id";
                dbConnection.Open();
                var list = await dbConnection.QueryAsync<T>(query, new { Id = id });
                return list.FirstOrDefault();
            }
        }

        public virtual async Task Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = "DELETE FROM " + crudTableName +
                    " Where " + primaryKey + " = @Id";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(query, new { Id = id });
            }
        }

        public virtual async Task Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
