using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dto
{
    public class SalesOrderHeaderDto
    {
        public Int32 SalesOrderID { get; set; }
        public Byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public Byte Status { get; set; }
        public Boolean OnlineOrderFlag { get; set; }
        public String SalesOrderNumber { get; set; }
        public String PurchaseOrderNumber { get; set; }
        public String AccountNumber { get; set; }
        public Int32 CustomerID { get; set; }
        public Int32? ShipToAddressID { get; set; }
        public Int32? BillToAddressID { get; set; }
        public String ShipMethod { get; set; }
        public String CreditCardApprovalCode { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal TaxAmt { get; set; }
        public Decimal Freight { get; set; }
        public Decimal? TotalDue { get; set; }
        public String Comment { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
