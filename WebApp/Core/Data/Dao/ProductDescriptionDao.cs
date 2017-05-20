using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Data.Dao
{
    public class ProductDescriptionDao
    {
        public Int32 ProductDescriptionID { get; set; }
        public String Description { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
