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
    public class ReportDetailedTest
    {
        private string sinceDate = "01.12.2019 0:00:00";
        private string toDate = "06.12.2019 0:00:00";
        Category category = new Category { Id =3};

        [TestCase]
        public void ReportDetailedUseCaseEqualTest()
        {
            GetReportDetailedRequest getReportDetailedRequest = new GetReportDetailedRequest(category,sinceDate, toDate);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetReportDetailedResponse getReportDetailedResponse = useCaseFactory.Create<IUseCase<GetReportDetailedRequest, GetReportDetailedResponse>>().Execute(getReportDetailedRequest);

            Assert.IsTrue(getReportDetailedResponse.ReportDetaileds.Count == 2);
        }

        [TestCase]
        public void ReportDetailedUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
                IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                GetReportDetailedRequest getReportDetailedRequest = new GetReportDetailedRequest(category,"", "asd");
                GetReportDetailedResponse getReportDetailedResponse = useCaseFactory.Create<IUseCase<GetReportDetailedRequest, GetReportDetailedResponse>>().Execute(getReportDetailedRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "Date must be filled!");
        }
    }
}
