using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Service.Dto
{
    public class SalesOrderDetail
    {
        public Int32 SalesOrderID { get; set; }
        public Int32 SalesOrderDetailID { get; set; }
        public Int16 OrderQty { get; set; }
        public Int32 ProductID { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal UnitPriceDiscount { get; set; }
        public Decimal LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
