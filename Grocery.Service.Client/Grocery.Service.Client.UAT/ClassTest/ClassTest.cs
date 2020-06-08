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
    public class ClassTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Class> classes = new List<Class>();

        [When("User try to show class")]
        public async Task ShowClass()
        {
            try
            {
                classes = await this.frontServiceClient.ShowClassAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
