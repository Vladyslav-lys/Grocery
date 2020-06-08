using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Entities
{
    public class ArrivedGoods
    {
        public int Id { get; set; }
        public Provider Provider { get; set; }
        public int Count { get; set; }
        public DateTime DateTime { get; set; }
        public float AllPurchasePrice { get; set; }
        public float AllSalesPrice { get; set; }
        public Department Department { get; set; }
        public Seller Seller { get; set; }
    }
}
