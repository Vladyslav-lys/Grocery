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

namespace Grocery.BLL.Tests.UserTests
{
    [TestFixture]
    public class LoginTest
    {
        private string login = "TopSeller2";
        private string password = "Password9";

        [TestCase]
        public void LoginUseCaseEqualTest()
        {
            GetUserRequest getUserRequest = new GetUserRequest(login, password);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetUserResponse getUserResponse = useCaseFactory.Create<IUseCase<GetUserRequest, GetUserResponse>>().Execute(getUserRequest);

            Assert.AreEqual(getUserResponse.User.Login, login);
            Assert.AreEqual(getUserResponse.User.Password, password);
        }

        [TestCase]
        public void LoginUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
                IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                GetUserRequest getUserRequest = new GetUserRequest("re", "f");
                GetUserResponse getUserResponse = useCaseFactory.Create<IUseCase<GetUserRequest, GetUserResponse>>().Execute(getUserRequest); ;
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "The user is not found! Please, check out login or password");
        }
    }
}
