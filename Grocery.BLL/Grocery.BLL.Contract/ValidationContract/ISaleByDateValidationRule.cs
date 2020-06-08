using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public interface ISaleByDateValidationRule
    {
        ValidResult ValidateSinceDate(string sinceDate);
        ValidResult ValidateToDate(string toDate);
        void RefreshValidResult();
    }
}
