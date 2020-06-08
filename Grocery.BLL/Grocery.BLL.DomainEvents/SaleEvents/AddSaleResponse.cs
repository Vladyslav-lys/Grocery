using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class AddSaleResponse
    {
        public List<Sale> Sales { get; set; }
        public List<Product> Products { get; set; }

        public AddSaleResponse(List<Sale> sales, List<Product> products)
        {
            this.Sales = sales;
            this.Products = products;
        }
    }
}
