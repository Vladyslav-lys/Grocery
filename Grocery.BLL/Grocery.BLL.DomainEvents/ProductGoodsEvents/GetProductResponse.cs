using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetProductResponse
    {
        public List<Product> Products { get; set; }

        public GetProductResponse(List<Product> products)
        {
            this.Products = products;
        }
    }
}
