using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Employee
    {
        public Int32 EmployeeId { get; set; }
        public Int32 EmployeeTypeId { get; set; }
        public String JobTitle { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String DomainName { get; set; }
    }
}
