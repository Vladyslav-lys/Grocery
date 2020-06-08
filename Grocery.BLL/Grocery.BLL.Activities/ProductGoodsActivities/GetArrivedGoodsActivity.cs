using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetArrivedGoodsActivity : IGetArrivedGoodsActivity
    {
        private IArrivedGoodsRepository arrivedGoodsRepository;

        public GetArrivedGoodsActivity(IArrivedGoodsRepository arrivedGoodsRepository)
        {
            this.arrivedGoodsRepository = arrivedGoodsRepository;
        }

        public List<ArrivedGoods> Run(Department department)
        {
            List<ArrivedGoods> arrivedGoodses = new List<ArrivedGoods>();

            arrivedGoodsRepository.GetNewAll();
            foreach (ArrivedGoods curArrivedGoods in arrivedGoodsRepository.GetAll())
            {
                if (department.Id.Equals(curArrivedGoods.Department.Id))
                {
                    ArrivedGoods arrivedGoods = new ArrivedGoods()
                    {
                        Id = curArrivedGoods.Id,
                        Provider = curArrivedGoods.Provider,
                        Count = curArrivedGoods.Count,
                        DateTime = curArrivedGoods.DateTime,
                        AllPurchasePrice = curArrivedGoods.AllPurchasePrice,
                        AllSalesPrice = curArrivedGoods.AllSalesPrice,
                        Department = curArrivedGoods.Department,
                        Seller = curArrivedGoods.Seller
                    };

                    arrivedGoodses.Add(arrivedGoods);
                }
            }

            return arrivedGoodses;
        }
    }
}
