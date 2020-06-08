using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetClassResponse
    {
        public List<Class> Classes { get; set; }

        public GetClassResponse(List<Class> classes)
        {
            this.Classes = classes;
        }
    }
}
