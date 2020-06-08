using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class SaleByDateValidationRule : ValidationBase, ISaleByDateValidationRule
    {
        public SaleByDateValidationRule() : base()
        {

        }

        public ValidResult ValidateSinceDate(string sinceDate)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(sinceDate.ToString()) || !DateTime.TryParse(sinceDate, out dateResult))
            {
                validResult = new ValidResult(false, "Date must be defined");
            }
            return validResult;
        }

        public ValidResult ValidateToDate(string toDate)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(toDate.ToString()) || !DateTime.TryParse(toDate, out dateResult))
            {
                validResult = new ValidResult(false, "Date must be defined");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}
