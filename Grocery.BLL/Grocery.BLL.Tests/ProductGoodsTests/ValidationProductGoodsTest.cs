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
    public class ValidationProductGoodsTest
    {
        IProductValidationRule productValidationRule = new ProductValidationRule();
        IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();

        [TestCase]
        public void CountCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = productValidationRule.ValidateCount("22");
            ValidResult v2 = arrivedGoodsValidationRule.ValidateCount("22");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void UnitCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            ValidResult v1 = productValidationRule.ValidateUnit("sad");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void DatetimeCorrected()
        {
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = arrivedGoodsValidationRule.ValidateDateTime("01.12.2019");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void ExpCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            ValidResult v1 = productValidationRule.ValidateExpirationDate("01.12.2019");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void SalesPriceCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = productValidationRule.ValidateSalesPrice("2,0");
            ValidResult v2 = arrivedGoodsValidationRule.ValidateAllSalesPrice("2,0");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void PurchaseCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = productValidationRule.ValidatePurchasePrice("2,0");
            ValidResult v2 = arrivedGoodsValidationRule.ValidateAllPurchasePrice("2,0");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void RetunedDateCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            ValidResult v1 = productValidationRule.ValidateReturnedDate("01.12.2019",true);
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void RetunedDateNotCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            ValidResult v1 = productValidationRule.ValidateReturnedDate("", true);
            Assert.IsTrue(v1.GetError().Length > 0);
        }

        [TestCase]
        public void PurchaseNotCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = productValidationRule.ValidatePurchasePrice("0");
            ValidResult v2 = arrivedGoodsValidationRule.ValidateAllPurchasePrice("as");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }

        [TestCase]
        public void SalesPriceNotCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = productValidationRule.ValidateSalesPrice("0");
            ValidResult v2 = arrivedGoodsValidationRule.ValidateAllSalesPrice("as");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }

        [TestCase]
        public void ExpNotCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            ValidResult v1 = productValidationRule.ValidateExpirationDate("");
            Assert.IsTrue(v1.GetError().Length > 0);
        }

        [TestCase]
        public void DatetmeNotCorrected()
        {
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = arrivedGoodsValidationRule.ValidateDateTime("sd");
            Assert.IsTrue(v1.GetError().Length > 0);
        }

        [TestCase]
        public void UnitNotCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            ValidResult v1 = productValidationRule.ValidateUnit("");
            Assert.IsTrue(v1.GetError().Length > 0);
        }

        [TestCase]
        public void CountNotCorrected()
        {
            IProductValidationRule productValidationRule = new ProductValidationRule();
            IArrivedGoodsValidationRule arrivedGoodsValidationRule = new ArrivedGoodsValidationRule();
            ValidResult v1 = productValidationRule.ValidateCount("sd");
            ValidResult v2 = arrivedGoodsValidationRule.ValidateCount("0");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }
    }
}
