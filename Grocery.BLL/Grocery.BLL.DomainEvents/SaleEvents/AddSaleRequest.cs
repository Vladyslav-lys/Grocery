using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class AddSaleRequest
    {
        public Product Product { get; set; }
        public string Count { get; set; }
        public string DateTime { get; set; }
        public string Price { get; set; }
        public Seller Seller { get; set; }

        public AddSaleRequest(Product product, string count, string dateTime, string price, Seller seller)
        {
            this.Product = product;
            this.Count = count;
            this.DateTime = dateTime;
            this.Price = price;
            this.Seller = seller;
        }
    }
}
