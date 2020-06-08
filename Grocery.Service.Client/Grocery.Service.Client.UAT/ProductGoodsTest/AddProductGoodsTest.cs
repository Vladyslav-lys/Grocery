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
    public class AddProductGoodsTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        OperationStatusInfo operationStatusInfo = null;

        [When("User try to add product goods by (.*) and (.*)")]
        public async Task AddProductGoods(Product product, ArrivedGoods arrivedGoods)
        {
            try
            {
                operationStatusInfo = await this.frontServiceClient.AddProductGoodsAsync(product, arrivedGoods);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
