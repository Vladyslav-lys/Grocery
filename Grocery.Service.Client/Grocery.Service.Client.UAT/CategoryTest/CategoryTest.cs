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
    public class CategoryTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Category> categories = new List<Category>();

        [When("User try to show category")]
        public async Task ShowCategory()
        {
            try
            {
                categories = await this.frontServiceClient.ShowCategoryAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
