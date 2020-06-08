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

namespace Grocery.BLL.Tests.CategoryTests
{
    [TestFixture]
    public class CategoryTest
    {
        [TestCase]
        public void CategoryUseCaseEqualTest()
        {
            GetCategoryRequest getCategoryRequest = new GetCategoryRequest();

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetCategoryResponse getCategoryResponse = useCaseFactory.Create<IUseCase<GetCategoryRequest, GetCategoryResponse>>().Execute(getCategoryRequest);

            Assert.IsTrue(getCategoryResponse.Categories.Count > 0);
        }
    }
}
