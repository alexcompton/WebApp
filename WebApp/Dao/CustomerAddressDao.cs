﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Dao
{
    public class CustomerAddressDao
    {
        public Int32 CustomerID { get; set; }
        public Int32 AddressID { get; set; }
        public String AddressType { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
