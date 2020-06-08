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

namespace Grocery.BLL.Tests.ClassTests
{
    [TestFixture]
    public class ClassTest
    {
        [TestCase]
        public void ClassUseCaseEqualTest()
        {
            GetClassRequest getClassRequest = new GetClassRequest();

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetClassResponse getClassResponse = useCaseFactory.Create<IUseCase<GetClassRequest, GetClassResponse>>().Execute(getClassRequest);

            Assert.IsTrue(getClassResponse.Classes.Count > 0);
        }
    }
}
