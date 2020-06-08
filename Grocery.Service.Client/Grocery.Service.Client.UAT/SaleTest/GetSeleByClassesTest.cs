using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Configuration;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Grocery.Service.Client.UAT.SaleTest
{
    [Binding]
    public class GetSeleByClassesTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Sale> sales = new List<Sale>();

        [When("User try to show sales clases by (.*) and (.*) and (.*)")]
        public async Task ShowSalesByClasses(Class class_, DateTime sinceDate, DateTime toDate)
        {
            try
            {
                sales = await this.frontServiceClient.ShowSaleByClassAsync(class_, sinceDate, toDate);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
