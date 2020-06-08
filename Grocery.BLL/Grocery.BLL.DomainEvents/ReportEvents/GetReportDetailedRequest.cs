using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetReportDetailedRequest
    {
        public Category Category { get; set; }
        public string SinceDate { get; set; }
        public string ToDate { get; set; }

        public GetReportDetailedRequest(Category category, string sinceDate, string toDate)
        {
            this.Category = category;
            this.SinceDate = sinceDate;
            this.ToDate = toDate;
        }
    }
}
