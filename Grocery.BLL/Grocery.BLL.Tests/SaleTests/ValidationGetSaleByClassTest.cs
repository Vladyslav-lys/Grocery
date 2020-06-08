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
    public class ValidationGetSaleByClassTest
    {
        [TestCase]
        public void DateCorrected()
        {
            ISaleByDateValidationRule saleByDateValidationRule = new SaleByDateValidationRule();
            ValidResult v1 = saleByDateValidationRule.ValidateSinceDate("01.12.2019");
            ValidResult v2 = saleByDateValidationRule.ValidateToDate("01.12.2019");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void DateNotCorrected()
        {
            ISaleByDateValidationRule saleByDateValidationRule = new SaleByDateValidationRule();
            ValidResult v1 = saleByDateValidationRule.ValidateSinceDate("");
            ValidResult v2 = saleByDateValidationRule.ValidateToDate("sad");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }
    }
}
