using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Grocery.BLL.Entities;
using System.Configuration;
using System.Threading.Tasks;

namespace Grocery.Service.Client.UAT
{
    [Binding]
    public class EnterTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        User user = null;

        [When("User try to enter by (.*) and (.*) through Client")]
        public async Task EnterUser(string login, string password)
        {
            try
            {
                user = await this.frontServiceClient.EnterAsync(login, password);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
