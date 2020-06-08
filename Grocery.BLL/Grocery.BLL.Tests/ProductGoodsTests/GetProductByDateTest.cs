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
    public class GetProductByDateTest
    {
        private string date = "20.12.2019 0:00:00";

        [TestCase]
        public void GetProductByDateUseCaseEqualTest()
        {
            GetProductByDateRequest getProductByDateRequest = new GetProductByDateRequest(date);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetProductByDateResponse getProductByDateResponse = useCaseFactory.Create<IUseCase<GetProductByDateRequest, 
                GetProductByDateResponse>>().Execute(getProductByDateRequest);

            Assert.IsTrue(getProductByDateResponse.Products.Count > 0);
        }

        [TestCase]
        public void GetSaleByClassUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
                IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                GetProductByDateRequest getProductByDateRequest = new GetProductByDateRequest("");
                GetProductByDateResponse getProductByDateResponse = useCaseFactory.Create<IUseCase<GetProductByDateRequest, 
                    GetProductByDateResponse>>().Execute(getProductByDateRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "Date must be defined");
        }
    }
}
