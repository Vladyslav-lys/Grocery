using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetDepartmentResponse
    {
        public List<Department> Departments { get; set; }

        public GetDepartmentResponse(List<Department> departments)
        {
            this.Departments = departments;
        }
    }
}
