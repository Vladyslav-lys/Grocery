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
    public class ValidationAddSaleTest
    {
        [TestCase]
        public void AddSaleCorrected()
        {
            Product product = new Product()
            {
                Id = 1,
                Unit = "Apple",
                ArrivedGoods = new ArrivedGoods
                {
                    Id = 1,
                    Provider = new Provider { Id = 2 },
                    Department = new Department { Id = 1 },
                    Seller = new Seller { Id = 2 }
                },
                SalesPrice = 0.83f,
                PurchasePrice = 0.83f,
                Category = new Category { Id = 3 },
                Class = new Class { Id = 4 },
                TareChange = new TareChange { Id = 2 },
                Count = 58,
                ExpirationDate = new DateTime(2019, 12, 20),
                Returned = false,
                ReturnedDate = null,
                WritenOff = false
            };

            ISaleValidationRule saleValidationRule = new SaleValidationRule();
            ValidResult v1 = saleValidationRule.ValidateCount("2");
            ValidResult v2 = saleValidationRule.ValidateDatetime("01.12.2019");
            ValidResult v3 = saleValidationRule.ValidateProduct(product);
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void AddSaleNotCorrected()
        {
            Product product1 = new Product()
            {
                Id = 1,
                Unit = "Apple",
                ArrivedGoods = new ArrivedGoods
                {
                    Id = 1,
                    Provider = new Provider { Id = 2 },
                    Department = new Department { Id = 1 },
                    Seller = new Seller { Id = 2 }
                },
                SalesPrice = 0.83f,
                PurchasePrice = 0.83f,
                Category = new Category { Id = 3 },
                Class = new Class { Id = 4 },
                TareChange = new TareChange { Id = 2 },
                Count = 58,
                ExpirationDate = new DateTime(2019, 12, 20),
                Returned = true,
                ReturnedDate = null,
                WritenOff = false
            };

            Product product2 = new Product()
            {
                Id = 1,
                Unit = "Apple",
                ArrivedGoods = new ArrivedGoods
                {
                    Id = 1,
                    Provider = new Provider { Id = 2 },
                    Department = new Department { Id = 1 },
                    Seller = new Seller { Id = 2 }
                },
                SalesPrice = 0.83f,
                PurchasePrice = 0.83f,
                Category = new Category { Id = 3 },
                Class = new Class { Id = 4 },
                TareChange = new TareChange { Id = 2 },
                Count = 58,
                ExpirationDate = new DateTime(2019, 12, 20),
                Returned = false,
                ReturnedDate = null,
                WritenOff = true
            };

            ISaleValidationRule saleValidationRule = new SaleValidationRule();
            ValidResult v1 = saleValidationRule.ValidateCount("w");
            ValidResult v2 = saleValidationRule.ValidateDatetime("sd");
            ValidResult v3 = saleValidationRule.ValidateProduct(product1);
            ValidResult v4 = saleValidationRule.ValidateProduct(product2);
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
            Assert.IsTrue(v3.GetError().Length > 0);
            Assert.IsTrue(v4.GetError().Length > 0);
        }
    }
}
