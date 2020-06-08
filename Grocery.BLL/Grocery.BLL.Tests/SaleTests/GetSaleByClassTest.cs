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

namespace Grocery.BLL.Tests.SaleTests
{
    [TestFixture]
    public class GetSaleByClassTest
    {
        private string sinceDate = "01.12.2019 00:00:00";
        private string toDate = "06.12.2019 00:00:00";
        Class class_ = new Class() { Id = 4 };

        [TestCase]
        public void GetSaleByClassUseCaseEqualTest()
        {
            GetSaleByClassRequest getSaleByClassRequest = new GetSaleByClassRequest(class_,sinceDate,toDate);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetSaleByClassResponse getSaleByClassResponse = useCaseFactory.Create<IUseCase<GetSaleByClassRequest, GetSaleByClassResponse>>().Execute(getSaleByClassRequest);

            Assert.IsTrue(getSaleByClassResponse.Sales.Count > 0);
        }

        [TestCase]
        public void GetSaleByClassUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
                IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                GetSaleByClassRequest getSaleByClassRequest = new GetSaleByClassRequest(class_, "", "asd");
                GetSaleByClassResponse getSaleByClassResponse = useCaseFactory.Create<IUseCase<GetSaleByClassRequest, GetSaleByClassResponse>>().Execute(getSaleByClassRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "Date must be defined");
        }
    }
}
