using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contract;

namespace Grocery.BLL.Activities
{
    public class AddProductActivity : IAddProductActivity
    {
        private IProductRepository productRepository;

        public AddProductActivity(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Run(string unit, Category category, Class class_, TareChange tareChange, int count, DateTime expirationDate, ArrivedGoods arrivedGoods, 
            float purchasePrice, float salesPrice, bool returned, DateTime? returnedDate, bool writenOff)
        {
            Product newProduct = new Product()
            {
                Unit = unit,
                Category = category,
                Class = class_,
                TareChange=tareChange,
                Count=count,
                ExpirationDate=expirationDate,
                ArrivedGoods=arrivedGoods,
                PurchasePrice=purchasePrice,
                SalesPrice=salesPrice,
                Returned=returned,
                ReturnedDate=returnedDate,
                WritenOff=writenOff
            };
            productRepository.Create(newProduct);
        }
    }
}
