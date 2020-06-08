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
    class SystemSaleController
    {
        private SystemSettings systemSettings;
        private IFrontServiceClient frontServiceClient;

        public SystemSaleController(SystemSettings systemSettings, IFrontServiceClient frontServiceClient)
        {
            this.systemSettings = systemSettings;
            this.frontServiceClient = frontServiceClient;
        }

        public async Task<List<Sale>> ShowSaleAsync(Department department)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowSales", department);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(attachedObjectText);

                    return sales;
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

        public async Task<List<Sale>> ShowSaleByClassAsync(Class class_, DateTime sinceDate, DateTime toDate)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowSalesByClass", class_, sinceDate, toDate);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(attachedObjectText);

                    return sales;
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

        public async Task<OperationStatusInfo> AddSaleAsync(Sale sale)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("AddSales", sale);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return operationStatusInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Adding is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Adding is not executed. Reason:" + ex.Message, ex);
            }
        }
    }
}
