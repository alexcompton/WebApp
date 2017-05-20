using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Dao;

namespace WebApp.Repo.MsSql
{
    public class ProductRepo : BaseRepo<ProductDao>
    {
        public ProductRepo():base() { }
        public override void Add(ProductDao t)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ProductDao> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<ProductDao>("SELECT * FROM [SalesLT].[Product]");
            }
        }

        public override ProductDao GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(ProductDao t)
        {
            throw new NotImplementedException();
        }
    }
}
