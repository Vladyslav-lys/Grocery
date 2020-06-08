using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public DateTime Datetime { get; set; }
        public Seller Seller { get; set; }
    }
}
