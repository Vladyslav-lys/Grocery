using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetSaleRequest
    {
        public Department Department { get; set; }

        public GetSaleRequest(Department department)
        {
            this.Department = department;
        }
    }
}
