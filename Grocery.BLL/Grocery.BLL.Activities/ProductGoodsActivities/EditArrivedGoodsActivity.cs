using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contract;

namespace Grocery.BLL.Activities
{
    public class EditArrivedGoodsActivity : IEditArrivedGoodsActivity
    {
        private IArrivedGoodsRepository arrivedGoodsRepository;

        public EditArrivedGoodsActivity(IArrivedGoodsRepository arrivedGoodsRepository)
        {
            this.arrivedGoodsRepository = arrivedGoodsRepository;
        }

        public void Run(int id, Provider provider, int count, DateTime dateTime, float allPurchasePrice, float allSalesPrice, Department department, Seller seller)
        {
            ArrivedGoods arrivedGoods = null;

            arrivedGoodsRepository.GetNewAll();
            foreach (ArrivedGoods curArrivedGoods in arrivedGoodsRepository.GetAll())
            {
                if (id.Equals(curArrivedGoods.Id))
                {
                    arrivedGoods = new ArrivedGoods()
                    {
                        Id = id,
                        Provider = provider,
                        Count = count,
                        DateTime = dateTime,
                        AllPurchasePrice = allPurchasePrice,
                        AllSalesPrice = allPurchasePrice,
                        Department = department,
                        Seller = seller
                    };
                    arrivedGoodsRepository.Update(arrivedGoods);
                    break;
                }
            }

            if (arrivedGoods == null)
                throw new Exception("The product is not updated and not found!"); ;
        }
    }
}
