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
    public class EditProductGoodsTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        OperationStatusInfo operationStatusInfo = null;

        [When("User try to edit product goods by (.*) and (.*)")]
        public async Task EditProductGoods(Product product, ArrivedGoods arrivedGoods)
        {
            try
            {
                operationStatusInfo = await this.frontServiceClient.EditProductGoodsAsync(product, arrivedGoods);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
