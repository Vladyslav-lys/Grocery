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

namespace Grocery.BLL.Tests.ReportTests
{
    [TestFixture]
    public class ValidationReportSimpleTest
    {
        [TestCase]
        public void DateCorrected()
        {
            IReportValidationRule reportValidationRule = new ReportValidationRule();
            ValidResult v1 = reportValidationRule.ValidateSinceDate("01.12.2019");
            ValidResult v2 = reportValidationRule.ValidateToDate("01.12.2019");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void DateNotCorrected()
        {
            IReportValidationRule reportValidationRule = new ReportValidationRule();
            ValidResult v1 = reportValidationRule.ValidateSinceDate("");
            ValidResult v2 = reportValidationRule.ValidateToDate("sad");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }
    }
}
