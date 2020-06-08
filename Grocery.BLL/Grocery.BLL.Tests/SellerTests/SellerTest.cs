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
namespace Grocery.BLL.Tests.SellerTests
{
    [TestFixture]
    public class SellerTest
    {
        [TestCase]
        public void SellerUseCaseEqualTest()
        {
            User user = new User { Id = 2 };
            GetSellerRequest getSellerRequest = new GetSellerRequest(user);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetSellerResponse getSellerResponse = useCaseFactory.Create<IUseCase<GetSellerRequest, GetSellerResponse>>().Execute(getSellerRequest);

            Assert.AreEqual(getSellerResponse.Seller.Surname, "Wolf");
        }
    }
}
