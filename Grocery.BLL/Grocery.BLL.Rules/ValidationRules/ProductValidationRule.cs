using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class ProductValidationRule : ValidationBase, IProductValidationRule
    {
        public ProductValidationRule() : base()
        {

        }

        public ValidResult ValidateCount(string count)
        {
            if (string.IsNullOrEmpty(count) || !count.IsNumbers())
            {
                validResult = new ValidResult(false, "Count must have digits only");
            }
            else if (int.Parse(count) <= 0)
            {
                validResult = new ValidResult(false, "Count must be more then 0");
            }
            return validResult;
        }

        public ValidResult ValidateExpirationDate(string expirationDate)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(expirationDate.ToString()) || !DateTime.TryParse(expirationDate, out dateResult))
            {
                validResult = new ValidResult(false, "Date must be defined!");
            }
            return validResult;
        }

        public ValidResult ValidatePurchasePrice(string purchasePrice)
        {
            if (string.IsNullOrEmpty(purchasePrice) || !purchasePrice.IsFractNumbers())
            {
                validResult = new ValidResult(false, "Purchase price must have fraction numbers!");
            }
            else if (float.Parse(purchasePrice) <= 0.0f)
            {
                validResult = new ValidResult(false, "Purchase price must be more then 0");
            }
            return validResult;
        }

        public ValidResult ValidateSalesPrice(string salesPrice)
        {
            if (string.IsNullOrEmpty(salesPrice) || !salesPrice.IsFractNumbers())
            {
                validResult = new ValidResult(false, "Sales price must have fraction numbers!");
            }
            else if (float.Parse(salesPrice) <= 0.0f)
            {
                validResult = new ValidResult(false, "Sales price must be more then 0");
            }
            return validResult;
        }

        public ValidResult ValidateUnit(string unit)
        {
            if (string.IsNullOrEmpty(unit) || !unit.IsStringWithNumbers())
            {
                validResult = new ValidResult(false, "Unit must have: letters or digits!");
            }
            return validResult;
        }

        public ValidResult ValidateReturnedDate(string returnedDate, bool returned)
        {
            DateTime dateResult;

            if ((string.IsNullOrEmpty(returnedDate) || !DateTime.TryParse(returnedDate, out dateResult)) && returned)
            {
                validResult = new ValidResult(false, "Returned date must have be defined!");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}
