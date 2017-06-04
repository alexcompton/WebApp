using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProductModelProductDescription
    {
        public Int32 ProductModelID { get; set; }
        public Int32 ProductDescriptionID { get; set; }
        public String Culture { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
