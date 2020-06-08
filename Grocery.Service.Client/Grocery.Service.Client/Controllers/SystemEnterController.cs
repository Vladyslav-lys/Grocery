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
    class SystemEnterController
    {
        private SystemSettings systemSettings;
        private IFrontServiceClient frontServiceClient;

        public SystemEnterController(SystemSettings systemSettings, IFrontServiceClient frontServiceClient)
        {
            this.systemSettings = systemSettings;
            this.frontServiceClient = frontServiceClient;
        }

        public async Task<User> EnterAsync(string login, string password)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("enter", login, password);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    User userDTO = JsonConvert.DeserializeObject<User>(attachedObjectText);

                    return userDTO;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                frontServiceClient.IsConnected = false;
                throw new Exception("Enter is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Enter is not executed. Reason: " + ex.Message, ex);
            }
        }
    }
}
