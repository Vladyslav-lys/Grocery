using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Contract
{
    public interface ISaleValidationRule
    {
        ValidResult ValidateCount(string count);
        ValidResult ValidateDatetime(string dateTime);
        ValidResult ValidateProduct(Product product);

        void RefreshValidResult();
    }
}
