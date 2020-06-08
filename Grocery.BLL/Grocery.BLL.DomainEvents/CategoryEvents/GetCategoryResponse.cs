using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetCategoryResponse
    {
        public List<Category> Categories { get; set; }

        public GetCategoryResponse(List<Category> categories)
        {
            this.Categories = categories;
        }
    }
}
