using NUnit.Framework;
using Grocery.BLL.Contract;
using Grocery.BLL.Rules;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;
using Grocery.DAL.Contract;
using Grocery.DAL.Repositories;
using Grocery.BLL.Activities;
using Grocery.BLL.UseCases;
using System.Threading.Tasks;
using System;

namespace Grocery.BLL.Tests.UserTests
{
    [TestFixture]
    public class ValidationLoginTest
    {
        [TestCase]
        public void LoginCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidateLogin("somthing");
            ValidResult v2 = enterValidationRule.ValidateLogin("somthing23");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void LoginNotCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidateLogin("ыфв_");
            ValidResult v2 = enterValidationRule.ValidateLogin("");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }

        [TestCase]
        public void PasswordCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidatePassword("somthing");
            ValidResult v2 = enterValidationRule.ValidatePassword("somthing23");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void PasswordNotCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidatePassword("ыфв_");
            ValidResult v2 = enterValidationRule.ValidatePassword("");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }
    }
}
