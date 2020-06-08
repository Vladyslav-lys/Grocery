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
    public class FindSellerTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        Seller seller = null;

        [When("User try to find seller by (.*)")]
        public async Task FindSeller(User user)
        {
            try
            {
                seller = await this.frontServiceClient.FindSellerAsync(user);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
