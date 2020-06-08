using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class AddProductGoodsResponse
    {
        public List<ArrivedGoods> ArrivedGoods { get; set; }
        public List<Product> Products { get; set; }

        public AddProductGoodsResponse(List<ArrivedGoods> arrivedGoods, List<Product> products)
        {
            this.ArrivedGoods = arrivedGoods;
            this.Products = products;
        }
    }
}
