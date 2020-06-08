using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Rules
{
    public class SaleValidationRule : ValidationBase, ISaleValidationRule
    {
        public SaleValidationRule() : base()
        {

        }

        public ValidResult ValidateCount(string count)
        {
            if (string.IsNullOrEmpty(count) || !count.IsNumbers())
            {
                validResult = new ValidResult(false, "Count must have digits only");
            }
            else if(int.Parse(count) <= 0)
            {
                validResult = new ValidResult(false, "Count must be more then 0");
            }
            return validResult;
        }

        public ValidResult ValidateDatetime(string dateTime)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(dateTime.ToString()) || !DateTime.TryParse(dateTime, out dateResult))
            {
                validResult = new ValidResult(false, "Date and time must be defined");
            }
            return validResult;
        }

        public ValidResult ValidateProduct(Product product)
        {
            if (product.Returned)
            {
                validResult = new ValidResult(false, "The product is returned!");
            }
            else if (product.WritenOff)
            {
                validResult = new ValidResult(false, "The product is writen off!");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}
