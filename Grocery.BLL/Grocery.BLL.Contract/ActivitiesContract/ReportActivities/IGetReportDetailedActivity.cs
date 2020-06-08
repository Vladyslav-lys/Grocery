using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Contract
{
    public interface IGetReportDetailedActivity
    {
        List<ReportDetailed> Run(Category category, DateTime sinceDate, DateTime toDate);
    }
}
