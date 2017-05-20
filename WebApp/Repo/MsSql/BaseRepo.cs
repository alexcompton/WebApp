using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Repo.MsSql
{
    public abstract class BaseRepo<T>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(@"Server=acompton11.database.windows.net;Database=AdventureWorks;User Id=user;Password=P@ssword;");
            }            
        }

        public abstract void Add(T t);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByID(int id);
        public abstract void Delete(int id);
        public abstract void Update(T t);
    }
}
