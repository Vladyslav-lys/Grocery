using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetReportSimpleResponse
    {
        public List<ReportSimple> ReportSimples { get; set; }

        public GetReportSimpleResponse(List<ReportSimple> reportSimples)
        {
            this.ReportSimples = reportSimples;
        }
    }
}
