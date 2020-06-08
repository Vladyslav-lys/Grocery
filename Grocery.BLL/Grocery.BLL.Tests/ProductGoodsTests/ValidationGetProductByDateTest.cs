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
    public class ValidationGetProductByDateTest
    {
        [TestCase]
        public void DateCorrected()
        {
            IProductByDateValidationRule productByDateValidationRule = new ProductByDateValidationRule();
            ValidResult v1 = productByDateValidationRule.ValidateDate("01.12.2019");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void DateNotCorrected()
        {
            IProductByDateValidationRule productByDateValidationRule = new ProductByDateValidationRule();
            ValidResult v1 = productByDateValidationRule.ValidateDate("");
            Assert.IsTrue(v1.GetError().Length > 0);
        }
    }
}
