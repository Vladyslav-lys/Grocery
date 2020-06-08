using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetSalesByClassActivity : IGetSalesByClassActivity
    {
        private ISaleRepository saleRepository;

        public GetSalesByClassActivity(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public List<Sale> Run(Class class_, DateTime sinceDate, DateTime toDate)
        {
            List<Sale> sales = new List<Sale>();

            saleRepository.GetNewAll();
            foreach (Sale curSale in saleRepository.GetAll())
            {
                if (class_.Id.Equals(curSale.Product.Class.Id) && sinceDate.Ticks <= curSale.Datetime.Ticks && toDate.Ticks >= curSale.Datetime.Ticks)
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
