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
    public class DepartmentTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<Department> departments = new List<Department>();
        
        [When("User try to show department")]
        public async Task ShowDepartment()
        {
            try
            {
                departments = await this.frontServiceClient.ShowDepartmentAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
