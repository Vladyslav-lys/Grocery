using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace Grocery.Service.Client
{
    public class SystemSettings
    {
        private string hubName;
        private string serviceUrl;
        private string fullPath;
        private HubConnection hubConnection;

        public SystemSettings(string hubName, string serviceUrl, HubConnection hubConnection)
        {
            this.hubName = hubName;
            this.serviceUrl = serviceUrl;
            this.hubConnection = hubConnection;
        }

        public string HubName
        {
            get { return this.hubName; }
            set { this.hubName = value; }
        }

        public HubConnection Connection
        {
            get { return this.hubConnection; }
            set { this.hubConnection = value; }
        }

        public string ServiceUrl
        {
            get { return this.serviceUrl; }
            set { this.serviceUrl = value; }
        }

        public string FullPath
        {
            get { return this.serviceUrl + this.hubName; }
        }
    }
}
