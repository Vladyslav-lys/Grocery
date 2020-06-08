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
    public class GetProductTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Product> products = new List<Product>();

        [When("User try to show products by (.*)")]
        public async Task ShowProducts(Department department)
        {
            try
            {
                products = await this.frontServiceClient.ShowProductAsync(department);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
