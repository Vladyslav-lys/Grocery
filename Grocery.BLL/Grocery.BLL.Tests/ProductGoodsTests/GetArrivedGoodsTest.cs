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
    public class GetArrivedGoodsTest
    {
        [TestCase]
        public void GetArrivedGoodsUseCaseEqualTest()
        {
            GetArrivedGoodsRequest getArrivedGoodsRequest = new GetArrivedGoodsRequest(new Department { Id=1});

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetArrivedGoodsResponse getArrivedGoodsResponse = useCaseFactory.Create<IUseCase<GetArrivedGoodsRequest, GetArrivedGoodsResponse>>().Execute(getArrivedGoodsRequest);

            Assert.IsTrue(getArrivedGoodsResponse.ArrivedGoods.Count > 0);
        }
    }
}
