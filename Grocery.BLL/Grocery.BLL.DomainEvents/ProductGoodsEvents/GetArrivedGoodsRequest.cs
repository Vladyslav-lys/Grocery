using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetArrivedGoodsRequest
    {
        public Department Department { get; set; }

        public GetArrivedGoodsRequest(Department department)
        {
            this.Department = department;
        }
    }
}
