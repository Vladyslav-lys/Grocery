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
    public class EditProductGoodsTest
    {
        int id = 1;
        string unit = "Apps";
        TareChange tareChange = new TareChange { Id = 4 };
        Category category = new Category { Id = 2 };
        Class class_ = new Class { Id = 4 };
        string count = "70";
        Provider provider = new Provider { Id = 2 };
        string datetime = "18.12.2019";
        string expDate = "30.12.2019";
        string allPurchasePrice = "100";
        string allSalePrice = "200";
        Department department = new Department { Id = 1 };
        Seller seller = new Seller { Id = 2 };
        bool returned = false;
        string returnedDate = null;
        bool writenOff= false;
        ArrivedGoods arrivedGoods = new ArrivedGoods
        {
            Id = 1,
            Provider = new Provider { Id = 2 },
            Department = new Department { Id = 1 },
            Seller = new Seller { Id = 2 }
        };

        [TestCase]
        public void EditProductGoodsUseCaseEqualTest()
        {
            EditProductGoodsRequest editProductGoodsRequest = new EditProductGoodsRequest
                (id, unit, tareChange,count,provider,datetime,category,class_,expDate,arrivedGoods,
                allPurchasePrice,allSalePrice,department,seller,returned,returnedDate,writenOff);

            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            EditProductGoodsResponse editProductGoodsResponse = useCaseFactory.Create<IUseCase<EditProductGoodsRequest, EditProductGoodsResponse>>().Execute(editProductGoodsRequest);

            Assert.AreEqual(editProductGoodsResponse.Products[0].Unit, unit);
            Assert.AreEqual(editProductGoodsResponse.Products[0].Returned, returned);
            Assert.AreEqual(editProductGoodsResponse.Products[0].ArrivedGoods.Id, arrivedGoods.Id);
            Assert.AreEqual(editProductGoodsResponse.Products[0].Count, int.Parse(count));
        }

        [TestCase]
        public void EditProductGoodsUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
                IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                EditProductGoodsRequest editProductGoodsRequest = new EditProductGoodsRequest
                (id, unit, tareChange, "", provider, datetime, category, class_, expDate, arrivedGoods,
                allPurchasePrice, allSalePrice, department, seller, returned, returnedDate, writenOff);
                EditProductGoodsResponse editProductGoodsResponse = useCaseFactory.Create<IUseCase<EditProductGoodsRequest, EditProductGoodsResponse>>().Execute(editProductGoodsRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "Count must have digits only");
        }
    }
}
