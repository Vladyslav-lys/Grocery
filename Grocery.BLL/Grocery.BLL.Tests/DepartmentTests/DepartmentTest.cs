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

namespace Grocery.BLL.Tests.DepartmentTests
{
    [TestFixture]
    public class DepartmentTest
    {
        [TestCase]
        public void DepartmentUseCaseEqualTest()
        {
            GetDepartmentRequest getDepartmentRequest = new GetDepartmentRequest();

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetDepartmentResponse getDepartmentResponse = useCaseFactory.Create<IUseCase<GetDepartmentRequest, GetDepartmentResponse>>().Execute(getDepartmentRequest);

            Assert.IsTrue(getDepartmentResponse.Departments.Count > 0);
        }
    }
}
