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
    public class GetSaleTest
    {
        [TestCase]
        public void GetSaleUseCaseEqualTest()
        {
            Department department = new Department() { Id = 1 };
            GetSaleRequest getSaleRequest = new GetSaleRequest(department);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetSaleResponse getClassResponse = useCaseFactory.Create<IUseCase<GetSaleRequest, GetSaleResponse>>().Execute(getSaleRequest);

            Assert.IsTrue(getClassResponse.Sales.Count > 0);
        }
    }
}
