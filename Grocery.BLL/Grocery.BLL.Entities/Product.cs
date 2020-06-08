using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public Category Category { get; set; }
        public Class Class { get; set; }
        public TareChange TareChange { get; set; }
        public int Count { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ArrivedGoods ArrivedGoods { get; set; }
        public float PurchasePrice { get; set; }
        public float SalesPrice { get; set; }
        public bool Returned { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool WritenOff { get; set; }
    }
}
