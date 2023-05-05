using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_OPERATION.Models
{
    public class Product
    {
        internal string CotegoryId;

        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string CotegoryName { get; set; }
        public string Date_of_Reg { get; set; }
      
    }
}