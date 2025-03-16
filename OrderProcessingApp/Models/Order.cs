using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessingApp.Models
{
    public class Order
    {
        public decimal OrderAmount { get; set; }
        public string CustomerType { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
