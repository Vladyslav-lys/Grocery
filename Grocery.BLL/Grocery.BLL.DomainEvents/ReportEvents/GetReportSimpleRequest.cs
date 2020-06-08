using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetReportSimpleRequest
    {
        public string SinceDate { get; set; }
        public string ToDate { get; set; }

        public GetReportSimpleRequest(string sinceDate, string toDate)
        {
            this.SinceDate = sinceDate;
            this.ToDate = toDate;
        }
    }
}
