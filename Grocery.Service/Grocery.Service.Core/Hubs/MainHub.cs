using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service.Core
{
    public partial class MainHub : Hub
    {
        private static readonly List<string> connectionCollection = new List<string>();
        
        private static readonly object locker = new object();
        private readonly HubEnvironment hubEnvironment;

        public MainHub(HubEnvironment hubEnvironment)
        {
            this.hubEnvironment = hubEnvironment;
        }

        public async Task Send(string message)
        {
            Console.WriteLine(message);
            await this.Clients.All.SendAsync("Notify", message);
        }

        protected virtual bool IsUserEntered
        {
            get
            {
                return connectionCollection.Contains(this.Context.ConnectionId);
            }
        }
        
        private void AddConnection(string connectionId)
        {
            lock (locker)
            {
                if (!connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Add(connectionId);
                }
            }
        }
        
        private void RemoveConnection(string connectionId)
        {
            lock (locker)
            {
                if (connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Remove(connectionId);
                }
            }
        }
        
        private void JoinGroup(string groupName)
        {
            this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        }
        
        private void LeaveGroup(string groupName)
        {
            this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, groupName);
        }

        private string GetIpAddress()
        {
            var ipAddress = Context.GetHttpContext().Connection.RemoteIpAddress.ToString();

            return ipAddress;
        }
    }
}
