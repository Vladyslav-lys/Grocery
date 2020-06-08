using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.SignalR.Client;

namespace Grocery.Service.Client.Research
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                try
                {
                    string serviceurl = ConfigurationManager.AppSettings["ServiceUrl"];
                    string hubname = ConfigurationManager.AppSettings["Hub"];

                    SystemSettings systemSettings = new SystemSettings(hubname, serviceurl, null);

                    systemSettings.Connection = new HubConnectionBuilder().WithUrl(systemSettings.FullPath).Build();

                    systemSettings.Connection.On<string>("Notify", (message) =>
                    {
                        System.Console.WriteLine("Notification: " + message);
                    });

                    await systemSettings.Connection.StartAsync();
                    await systemSettings.Connection.InvokeAsync("send", "Connected!");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Cannot connect to the server! Check out the server");
                }
            });

            System.Console.ReadLine();
        }
    }
}
