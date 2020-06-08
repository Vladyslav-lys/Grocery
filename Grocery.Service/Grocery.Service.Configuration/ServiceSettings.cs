using System;

namespace Grocery.Service.Configuration
{
    public static class ServiceSettings
    {
        public static string HubName
        {
            get
            {
                return "hubs";
            }
        }

        public static string ServiceUrl
        {
            get
            {
                return "http://localhost:61234/";
            }
        }
    }
}
