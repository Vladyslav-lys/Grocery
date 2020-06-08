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

namespace Grocery.BLL.Tests.TareChangeTests
{
    [TestFixture]
    public class GetTareChangeTest
    {
        [TestCase]
        public void TareChangeUseCaseEqualTest()
        {
           GetTareChangeRequest getTareChangeRequest = new GetTareChangeRequest();

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetTareChangeResponse getTareChangeResponse = useCaseFactory.Create<IUseCase< GetTareChangeRequest, GetTareChangeResponse>>().Execute(getTareChangeRequest);

            Assert.IsTrue(getTareChangeResponse.TareChanges.Count > 0);
        }
    }
}
