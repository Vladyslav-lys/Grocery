using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Configuration;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Grocery.Service.Client.UAT
{
    [Binding]
    public class ProviderTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Provider> providers = new List<Provider>();

        [When("User try to show provider")]
        public async Task ShowProvider()
        {
            try
            {
                providers = await this.frontServiceClient.ShowProviderAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
