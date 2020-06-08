using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public interface IArrivedGoodsValidationRule
    {
        ValidResult ValidateCount(string count);
        ValidResult ValidateDateTime(string dateTime);
        ValidResult ValidateAllPurchasePrice(string allPurchasePrice);
        ValidResult ValidateAllSalesPrice(string allSalesPrice);

        void RefreshValidResult();
    }
}
