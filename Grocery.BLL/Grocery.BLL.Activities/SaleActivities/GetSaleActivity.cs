using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetSaleActivity : IGetSaleActivity
    {
        private ISaleRepository saleRepository;

        public GetSaleActivity(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public List<Sale> Run(Department department)
        {
            List<Sale> sales = new List<Sale>();

            saleRepository.GetNewAll();
            foreach (Sale curSale in saleRepository.GetAll())
            {
                if (department.Id.Equals(curSale.Product.ArrivedGoods.Department.Id))
                {
                    Sale sale = new Sale()
                    {
                        Id = curSale.Id,
                        Product = curSale.Product,
                        Count = curSale.Count,
                        Price = curSale.Price,
                        Datetime = curSale.Datetime,
                        Seller = curSale.Seller
                    };

                    sales.Add(sale);
                }
            }
            
            return sales;
        }
    }
}
