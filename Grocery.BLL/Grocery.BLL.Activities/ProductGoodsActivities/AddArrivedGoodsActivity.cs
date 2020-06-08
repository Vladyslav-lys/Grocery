using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contract;

namespace Grocery.BLL.Activities
{
    public class AddArrivedGoodsActivity : IAddArrivedGoodsActivity
    {
        private IArrivedGoodsRepository arrivedGoodsRepository;

        public AddArrivedGoodsActivity(IArrivedGoodsRepository arrivedGoodsRepository)
        {
            this.arrivedGoodsRepository = arrivedGoodsRepository;
        }

        public void Run(Provider provider, int count, DateTime dateTime, float allPurchasePrice, float allSalesPrice, Department department, Seller seller)
        {
            ArrivedGoods newArrivedGoods = new ArrivedGoods()
            {
                Provider = provider,
                Count = count,
                DateTime = dateTime,
                AllPurchasePrice = allPurchasePrice,
                AllSalesPrice = allPurchasePrice,
                Department = department,
                Seller = seller
            };
            arrivedGoodsRepository.Create(newArrivedGoods);
        }
    }
}
