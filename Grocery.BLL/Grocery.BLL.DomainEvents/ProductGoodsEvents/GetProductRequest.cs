using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetProductRequest
    {
        public Department Department { get; set; }

        public GetProductRequest(Department department)
        {
            this.Department = department;
        }
    }
}
