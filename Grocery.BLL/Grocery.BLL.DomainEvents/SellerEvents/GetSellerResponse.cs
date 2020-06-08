using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetSellerResponse
    {
        public Seller Seller { get; set; }

        public GetSellerResponse(Seller seller)
        {
            this.Seller = seller;
        }
    }
}
