using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Data.Dao
{
    public class CustomerDao
    {
        public Int32 CustomerID { get; set; }
        public Boolean NameStyle { get; set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Suffix { get; set; }
        public String CompanyName { get; set; }
        public String SalesPerson { get; set; }
        public String EmailAddress { get; set; }
        public String Phone { get; set; }
        public String PasswordHash { get; set; }
        public String PasswordSalt { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
