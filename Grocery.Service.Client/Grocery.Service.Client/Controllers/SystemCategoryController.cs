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
    class SystemCategoryController
    {
        private SystemSettings systemSettings;
        private IFrontServiceClient frontServiceClient;

        public SystemCategoryController(SystemSettings systemSettings, IFrontServiceClient frontServiceClient)
        {
            this.systemSettings = systemSettings;
            this.frontServiceClient = frontServiceClient;
        }

        public async Task<List<Category>> ShowCategoryAsync()
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowCategories");

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(attachedObjectText);

                    return categories;
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
