using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Data.Dao
{
    public class ProductDao
    {
        public Int32 ProductID { get; set; }
        public String Name { get; set; }
        public String ProductNumber { get; set; }
        public String Color { get; set; }
        public Decimal StandardCost { get; set; }
        public Decimal ListPrice { get; set; }
        public String Size { get; set; }
        public Decimal? Weight { get; set; }
        public Int32? ProductCategoryID { get; set; }
        public Int32? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Byte[] ThumbNailPhoto { get; set; }
        public String ThumbnailPhotoFileName { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
