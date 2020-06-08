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

namespace Grocery.BLL.Tests.ProviderTests
{
    [TestFixture]
    public class ProviderTest
    {
        [TestCase]
        public void ProviderUseCaseEqualTest()
        {
            GetProviderRequest getProviderRequest = new GetProviderRequest();

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetProviderResponse getProviderResponse = useCaseFactory.Create<IUseCase<GetProviderRequest, GetProviderResponse>>().Execute(getProviderRequest);

            Assert.IsTrue(getProviderResponse.Providers.Count > 0);
        }
    }
}
