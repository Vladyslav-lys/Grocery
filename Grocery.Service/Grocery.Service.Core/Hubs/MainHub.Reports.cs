using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.Service.Domain;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> ShowReportSimple(DateTime sinceDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetReportSimpleRequest getReportSimpleRequest = new GetReportSimpleRequest(sinceDate.ToString(), toDate.ToString());

                try
                {
                    GetReportSimpleResponse getReportSimpleResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetReportSimpleRequest, GetReportSimpleResponse>>()
                        .Execute(getReportSimpleRequest);
                    operationStatusInfo.AttachedObject = getReportSimpleResponse.ReportSimples;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> ShowReportDetailed(Category category, DateTime sinceDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetReportDetailedRequest getReportDetailedRequest = new GetReportDetailedRequest(category, sinceDate.ToString(), toDate.ToString());

                try
                {
                    GetReportDetailedResponse getReportDetailedResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetReportDetailedRequest, GetReportDetailedResponse>>()
                        .Execute(getReportDetailedRequest);
                    operationStatusInfo.AttachedObject = getReportDetailedResponse.ReportDetaileds;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }
    }
}
