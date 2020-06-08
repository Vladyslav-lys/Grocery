using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetSaleByClassResponse
    {
        public List<Sale> Sales { get; set; }

        public GetSaleByClassResponse(List<Sale> sales)
        {
            this.Sales = sales;
        }
    }
}
