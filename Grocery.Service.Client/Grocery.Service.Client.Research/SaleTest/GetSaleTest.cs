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
    public class GetSaleTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Sale> sales = new List<Sale>();

        [When("User try to show sales by (.*)")]
        public async Task ShowSale(Department department)
        {
            try
            {
                sales = await this.frontServiceClient.ShowSaleAsync(department);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
