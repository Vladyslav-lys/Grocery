using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetSaleResponse
    {
        public List<Sale> Sales { get; set; }

        public GetSaleResponse(List<Sale> sales)
        {
            this.Sales = sales;
        }
    }
}
