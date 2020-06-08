using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetReportSimpleUseCase : IUseCase<GetReportSimpleRequest, GetReportSimpleResponse>
    {
        private IValidationActivity<GetReportSimpleRequest> reportSimpleValidationActivity;
        private IGetReportSimpleActivity getReportSimpleActivity;

        public GetReportSimpleUseCase(IValidationActivity<GetReportSimpleRequest> reportSimpleValidationActivity, IGetReportSimpleActivity getReportSimpleActivity)
        {
            this.reportSimpleValidationActivity = reportSimpleValidationActivity;
            this.getReportSimpleActivity = getReportSimpleActivity;
        }

        public GetReportSimpleResponse Execute(GetReportSimpleRequest request)
        {
            try
            {
                reportSimpleValidationActivity.Validate(request);
                List<ReportSimple> reportSimples = getReportSimpleActivity.Run(DateTime.Parse(request.SinceDate), DateTime.Parse(request.ToDate));
                return new GetReportSimpleResponse(reportSimples);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
