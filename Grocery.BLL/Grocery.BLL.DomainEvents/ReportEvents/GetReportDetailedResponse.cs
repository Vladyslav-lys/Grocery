using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetReportDetailedResponse
    {
        public List<ReportDetailed> ReportDetaileds { get; set; }

        public GetReportDetailedResponse(List<ReportDetailed> reportDetaileds)
        {
            this.ReportDetaileds = reportDetaileds;
        }
    }
}
