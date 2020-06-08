using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetArrivedGoodsResponse
    {
        public List<ArrivedGoods> ArrivedGoods { get; set; }

        public GetArrivedGoodsResponse(List<ArrivedGoods> arrivedGoods)
        {
            this.ArrivedGoods = arrivedGoods;
        }
    }
}
