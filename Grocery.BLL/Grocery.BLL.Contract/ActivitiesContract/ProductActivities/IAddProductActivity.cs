using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Contract
{
    public interface IAddProductActivity
    {
        void Run(string unit, Category category, Class class_, TareChange tareChange, int count, DateTime expirationDate, ArrivedGoods arrivedGoods, 
            float purchasePrice, float salesPrice, bool returned, DateTime? returnedDate, bool writenOff);
    }
}
