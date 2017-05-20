using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dao
{
    public class ProductModelDao
    {
        public Int32 ProductModelID { get; set; }
        public String Name { get; set; }
        public String CatalogDescription { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
