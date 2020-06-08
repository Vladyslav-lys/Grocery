using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetProductActivity : IGetProductActivity
    {
        private IProductRepository productRepository;

        public GetProductActivity(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> Run(Department department)
        {
            List<Product> products = new List<Product>();

            productRepository.GetNewAll();
            foreach (Product curProduct in productRepository.GetAll())
            {
                if (department.Id.Equals(curProduct.ArrivedGoods.Department.Id))
                {
                    Product product = new Product()
                    {
                        Id = curProduct.Id,
                        Unit = curProduct.Unit,
                        Category = curProduct.Category,
                        Class = curProduct.Class,
                        TareChange = curProduct.TareChange,
                        Count = curProduct.Count,
                        ExpirationDate = curProduct.ExpirationDate,
                        ArrivedGoods = curProduct.ArrivedGoods,
                        PurchasePrice = curProduct.PurchasePrice,
                        SalesPrice = curProduct.SalesPrice,
                        Returned = curProduct.Returned,
                        ReturnedDate = curProduct.ReturnedDate,
                        WritenOff = curProduct.WritenOff
                    };

                    products.Add(product);
                }
            }
            
            return products;
        }
    }
}
