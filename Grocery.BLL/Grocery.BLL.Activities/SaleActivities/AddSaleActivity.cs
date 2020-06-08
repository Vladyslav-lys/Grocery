using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class AddSaleActivity : IAddSaleActivity
    {
        private ISaleRepository saleRepository;

        public AddSaleActivity(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public void Run(Product product, int count, DateTime dateTime, float price, Seller seller)
        {
            Sale newSale = new Sale()
            {
                Product = product,
                Count = count,
                Price = price,
                Datetime = dateTime,
                Seller = seller
            };
            saleRepository.Create(newSale);
            return;
        }
    }
}
