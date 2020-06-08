using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.BLL.Entities;
using Grocery.Service.Client.Contract;
using Grocery.Service.Domain;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace Grocery.Service.Client
{
    class SystemReportController
    {
        private SystemSettings systemSettings;
        private IFrontServiceClient frontServiceClient;

        public SystemReportController(SystemSettings systemSettings, IFrontServiceClient frontServiceClient)
        {
            this.systemSettings = systemSettings;
            this.frontServiceClient = frontServiceClient;
        }

        public async Task<List<ReportSimple>> ShowReportSimpleAsync(DateTime sinceDate, DateTime toDate)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowReportSimple", sinceDate, toDate);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<ReportSimple> reportSimples = JsonConvert.DeserializeObject<List<ReportSimple>>(attachedObjectText);

                    return reportSimples;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                frontServiceClient.IsConnected = false;
                throw new Exception("Showing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Showing is not executed. Reason: " + ex.Message, ex);
            }
        }

        public async Task<List<ReportDetailed>> ShowReportDetailedAsync(Category category, DateTime sinceDate, DateTime toDate)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowReportDetailed", category, sinceDate, toDate);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<ReportDetailed> reportDetaileds = JsonConvert.DeserializeObject<List<ReportDetailed>>(attachedObjectText);

                    return reportDetaileds;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                frontServiceClient.IsConnected = false;
                throw new Exception("Showing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Showing is not executed. Reason: " + ex.Message, ex);
            }
        }
    }
}
