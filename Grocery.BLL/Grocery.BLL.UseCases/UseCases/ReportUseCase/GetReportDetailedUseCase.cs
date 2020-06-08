using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetReportDetailedUseCase : IUseCase<GetReportDetailedRequest, GetReportDetailedResponse>
    {
        private IValidationActivity<GetReportDetailedRequest> reportDetailedValidationActivity;
        private IGetReportDetailedActivity getReportDetailedActivity;

        public GetReportDetailedUseCase(IValidationActivity<GetReportDetailedRequest> reportDetailedValidationActivity, IGetReportDetailedActivity getReportDetailedActivity)
        {
            this.reportDetailedValidationActivity = reportDetailedValidationActivity;
            this.getReportDetailedActivity = getReportDetailedActivity;
        }

        public GetReportDetailedResponse Execute(GetReportDetailedRequest request)
        {
            try
            {
                reportDetailedValidationActivity.Validate(request);
                List<ReportDetailed> reportDetaileds = getReportDetailedActivity.Run(request.Category, DateTime.Parse(request.SinceDate), DateTime.Parse(request.ToDate));
                return new GetReportDetailedResponse(reportDetaileds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
