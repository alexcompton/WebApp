﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProductCategory
    {
        public Int32 ProductCategoryID { get; set; }
        public Int32 ParentProductCategoryID { get; set; }
        public String Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
