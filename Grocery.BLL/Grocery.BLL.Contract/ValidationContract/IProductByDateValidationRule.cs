using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public interface IProductByDateValidationRule
    {
        ValidResult ValidateDate(string date);
        void RefreshValidResult();
    }
}
