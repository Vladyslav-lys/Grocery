using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contract;

namespace Grocery.BLL.Activities
{
    public class EditProductActivity : IEditProductActivity
    {
        private IProductRepository productRepository;

        public EditProductActivity(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Run(int id, string unit, Category category, Class class_, TareChange tareChange, int count, DateTime expirationDate, 
            ArrivedGoods arrivedGoods, float purchasePrice, float salesPrice, bool returned, DateTime? returnedDate, bool writenOff)
        {
            Product product = null;

            productRepository.GetNewAll();
            foreach (Product curProduct in productRepository.GetAll())
            {
                if (id.Equals(curProduct.Id))
                {
                    product = new Product()
                    {
                        Id = id,
                        Unit = unit,
                        Category = category,
                        Class = class_,
                        TareChange = tareChange,
                        Count = count,
                        ExpirationDate = expirationDate,
                        ArrivedGoods = arrivedGoods,
                        PurchasePrice = purchasePrice,
                        SalesPrice = salesPrice,
                        Returned = returned,
                        ReturnedDate = returnedDate,
                        WritenOff = writenOff
                    };
                    productRepository.Update(product);
                    break;
                }
            }

            if (product == null)
                throw new Exception("The product is not updated and not found!");
        }
    }
}
