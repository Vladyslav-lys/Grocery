using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using Grocery.Service.Domain;
using System.Configuration;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Grocery.Service.Client.UAT
{
    [Binding]
    public class AddSaleTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        OperationStatusInfo operationStatusInfo = null;

        [When("User try to add sale by (.*)")]
        public async Task AddSale(Sale sale)
        {
            try
            {
                operationStatusInfo = await this.frontServiceClient.AddSaleAsync(sale);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
