using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Contract
{
    public interface IProductValidationRule
    {
        ValidResult ValidateUnit(string unit);
        ValidResult ValidateCount(string count); 
        ValidResult ValidateExpirationDate(string expirationDate);
        ValidResult ValidatePurchasePrice(string purchasePrice);
        ValidResult ValidateSalesPrice(string salesPrice);
        ValidResult ValidateReturnedDate(string returnedDate, bool returned);

        void RefreshValidResult();
    }
}
