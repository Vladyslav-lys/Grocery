using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class EditProductGoodsResponse
    {
        public List<ArrivedGoods> ArrivedGoods { get; set; }
        public List<Product> Products { get; set; }

        public EditProductGoodsResponse(List<ArrivedGoods> arrivedGoods, List<Product> products)
        {
            this.ArrivedGoods = arrivedGoods;
            this.Products = products;
        }
    }
}
