using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetSaleByClassRequest
    {
        public Class Class { get; set; }
        public string SinceDate { get; set; }
        public string ToDate { get; set; }

        public GetSaleByClassRequest(Class class_, string sinceDate, string toDate)
        {
            this.Class = class_;
            this.SinceDate = sinceDate;
            this.ToDate = toDate;
        }
    }
}
