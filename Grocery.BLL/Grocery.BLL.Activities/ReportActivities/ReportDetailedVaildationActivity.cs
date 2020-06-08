using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;

namespace Grocery.BLL.Activities
{
    public class ReportDetailedVaildationActivity : IValidationActivity<GetReportDetailedRequest>
    {
        private IReportValidationRule reportValidationRule;

        public ReportDetailedVaildationActivity(IReportValidationRule reportValidationRule)
        {
            this.reportValidationRule = reportValidationRule;
        }

        public void Validate(GetReportDetailedRequest request)
        {
            ValidResult validResultSinceDate = reportValidationRule.ValidateSinceDate(request.SinceDate);
            ValidResult validResultToDate = reportValidationRule.ValidateSinceDate(request.ToDate);

            if (validResultSinceDate.GetError().Length > 0)
            {
                throw new Exception(validResultSinceDate.GetError());
            }
            else if (validResultToDate.GetError().Length > 0)
            {
                throw new Exception(validResultToDate.GetError());
            }
        }
    }
}
