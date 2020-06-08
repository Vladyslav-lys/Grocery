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

namespace Grocery.BLL.Tests.SaleTests
{
    [TestFixture]
    public class AddSaleTest
    {
        private Product product = new Product()
        {
            Id = 1,
            Unit ="Apple",
            ArrivedGoods =new ArrivedGoods
            {
                Id =1,
                Provider =new Provider { Id=2},
                Department =new Department { Id=1},
                Seller =new Seller { Id=2}
            },
            SalesPrice=0.83f,
            PurchasePrice = 0.83f,
            Category= new Category {Id=3 },
            Class=new Class { Id=4},
            TareChange=new TareChange { Id=2},
            Count=58,
            ExpirationDate=new DateTime(2019,12,20),
            Returned=false,
            ReturnedDate=null,
            WritenOff=false
        };
        private int count = 3;
        private DateTime date = new DateTime(2019, 12, 17);
        private float price;
        private Seller seller = new Seller() { Id=2};

        [TestCase]
        public void AddSaleUseCaseEqualTest()
        {
            price = count * product.SalesPrice;
            AddSaleRequest addSaleRequest = new AddSaleRequest(product, count.ToString(), date.ToString(), price.ToString(), seller);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            AddSaleResponse addSaleResponse = useCaseFactory.Create<IUseCase<AddSaleRequest, AddSaleResponse>>().Execute(addSaleRequest);

            Assert.AreEqual(addSaleResponse.Sales[1].Product.Id,product.Id);
            Assert.AreEqual(addSaleResponse.Sales[1].Count, count);
            Assert.AreEqual(addSaleResponse.Sales[1].Datetime.Ticks, date.Ticks);
            Assert.AreEqual(addSaleResponse.Sales[1].Price, price);
            Assert.AreEqual(addSaleResponse.Sales[1].Seller.Id,seller.Id);
        }

        [TestCase]
        public void AddSaleUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
                IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                AddSaleRequest addSaleRequest = new AddSaleRequest(product, "asd", date.ToString(), price.ToString(), seller);
                AddSaleResponse addSaleResponse = useCaseFactory.Create<IUseCase<AddSaleRequest, AddSaleResponse>>().Execute(addSaleRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "Count must have digits only");
        }
    }
}
