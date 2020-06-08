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
    public class ArrivedGoodsTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<ArrivedGoods> arrivedGoods = new List<ArrivedGoods>();
        
        [When("User try to show arrived goods by (.*)")]
        public async Task ShowArrivedGoods(Department department)
        {
            try
            {
                arrivedGoods = await this.frontServiceClient.ShowArrivedGoodsAsync(department);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
