using NUnit.Framework;
using Grocery.BLL.Contract;
using Grocery.BLL.Rules;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;
using Grocery.DAL.Contract;
using Grocery.DAL.Contexts;
using Grocery.DAL.Repositories;
using Grocery.BLL.Activities;
using Grocery.BLL.UseCases;
using System.Threading.Tasks;
using System;

namespace Grocery.BLL.Tests.ReportTests
{
    [TestFixture]
    public class ReportSimpleTest
    {
        private string sinceDate = "01.12.2019 0:00:00";
        private string toDate = "06.12.2019 0:00:00";

        [TestCase]
        public void ReportSimpleUseCaseEqualTest()
        {
            GetReportSimpleRequest getReportSimpleRequest = new GetReportSimpleRequest(sinceDate, toDate);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetReportSimpleResponse getReportSimpleResponse = useCaseFactory.Create<IUseCase<GetReportSimpleRequest, GetReportSimpleResponse>>().Execute(getReportSimpleRequest);

            Assert.IsTrue(getReportSimpleResponse.ReportSimples.Count == 2);
        }

        [TestCase]
        public void ReportSimpleUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
                IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                GetReportSimpleRequest getReportSimpleRequest = new GetReportSimpleRequest("", "asd");
                GetReportSimpleResponse getReportSimpleResponse = useCaseFactory.Create<IUseCase<GetReportSimpleRequest, GetReportSimpleResponse>>().Execute(getReportSimpleRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "Date must be filled!");
        }
    }
}
