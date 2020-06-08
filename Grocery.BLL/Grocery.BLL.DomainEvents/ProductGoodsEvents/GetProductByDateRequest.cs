using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetProductByDateRequest
    {
        public string Date { get; set; }

        public GetProductByDateRequest(string date)
        {
            this.Date = date;
        }
    }
}
