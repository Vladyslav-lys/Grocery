using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class ProductByDateValidationRule : ValidationBase, IProductByDateValidationRule
    {
        public ProductByDateValidationRule() : base()
        {

        }

        public ValidResult ValidateDate(string date)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(date.ToString()) || !DateTime.TryParse(date, out dateResult))
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
