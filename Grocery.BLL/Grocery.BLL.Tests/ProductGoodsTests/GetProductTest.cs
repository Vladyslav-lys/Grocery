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

namespace Grocery.BLL.Tests.ProductGoodsTests
{
    [TestFixture]
    public class GetProductTest
    {
        [TestCase]
        public void GetProductUseCaseEqualTest()
        {
            GetProductRequest getProductRequest = new GetProductRequest(new Department { Id=1});

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetProductResponse getProductResponse = useCaseFactory.Create<IUseCase<GetProductRequest, GetProductResponse>>().Execute(getProductRequest);

            Assert.IsTrue(getProductResponse.Products.Count > 0);
        }
    }
}
