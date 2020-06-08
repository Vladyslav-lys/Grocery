using NUnit.Framework;
using System;
using Grocery.Service.Client.Contract;
using Grocery.Service.Client;

namespace Grocery.Service.Client.UAT
{
    public class TestBase
    {
        public IFrontServiceClient frontServiceClient = new FrontServiceClient();
        public Exception ex = null;
    }
}