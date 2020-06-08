using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service.Client
{
    class SystemConnectionController
    {
        private SystemSettings systemSettings;

        public SystemConnectionController(SystemSettings systemSettings)
        {
            this.systemSettings = systemSettings;
        }

        public async Task ConnectAsync()
        {
            try
            {
                this.systemSettings.Connection = new HubConnectionBuilder().WithUrl(this.systemSettings.FullPath).Build();

                await this.systemSettings.Connection.StartAsync();
                await this.systemSettings.Connection.InvokeAsync("send", "Connected!");
            }
            catch (Exception ex)
            {
                throw new Exception("Connection is not executed. Reason: There is no requested server", ex);
            }
        }

        public async Task DisconnectAsync()
        {
            try
            {
                if (this.systemSettings.Connection != null)
                {
                    if (this.systemSettings.Connection.State != HubConnectionState.Disconnected)
                    {
                        await this.systemSettings.Connection.StopAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Disconnection is not executed. Reason: There is no connection with the server", ex);
            }
        }
    }
}
