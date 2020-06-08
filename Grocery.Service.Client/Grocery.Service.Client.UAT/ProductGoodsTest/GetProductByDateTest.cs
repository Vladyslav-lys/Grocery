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
    public class GetProductByDateTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Product> products = new List<Product>();
        
        [When("User try to show products date by (.*)")]
        public async Task ShowProductsByDate(DateTime date)
        {
            try
            {
                products = await this.frontServiceClient.ShowProductByDateAsync(date);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
