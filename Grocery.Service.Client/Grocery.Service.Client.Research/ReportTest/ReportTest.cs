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
    public class ReportTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        List<ReportSimple> reportSimples = new List<ReportSimple>();
        List<ReportDetailed> reportDetaileds = new List<ReportDetailed>();

        [When("User try to show report simple by (.*) and (.*)")]
        public async Task ShowReportSimple(DateTime sinceDate, DateTime toDate)
        {
            try
            {
                reportSimples = await this.frontServiceClient.ShowReportSimpleAsync(sinceDate, toDate);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }

        [When("User try to show report detailed by (.*) and (.*) and (.*)")]
        public async Task ShowReportDetailed(Category category, DateTime sinceDate, DateTime toDate)
        {
            try
            {
                reportDetaileds = await this.frontServiceClient.ShowReportDetailedAsync(category, sinceDate, toDate);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
