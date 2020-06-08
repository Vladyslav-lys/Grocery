using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Contract
{
    public interface IAddArrivedGoodsActivity
    {
        void Run(Provider provider, int count, DateTime dateTime, float allPurchasePrice, float allSalesPrice, Department department, Seller seller);
    }
}
