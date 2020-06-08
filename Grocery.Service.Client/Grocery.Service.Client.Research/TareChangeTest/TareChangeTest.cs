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
    public class TareChangeTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<TareChange> tareChanges = new List<TareChange>();

        [When("User try to show tare changes")]
        public async Task ShowTareChange()
        {
            try
            {
                tareChanges = await this.frontServiceClient.ShowTareChangeAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
