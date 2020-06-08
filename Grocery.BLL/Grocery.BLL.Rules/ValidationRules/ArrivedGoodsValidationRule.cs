using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class ArrivedGoodsValidationRule : ValidationBase, IArrivedGoodsValidationRule
    {
        public ArrivedGoodsValidationRule() : base()
        {

        }

        public ValidResult ValidateAllPurchasePrice(string allPurchasePrice)
        {
            if (string.IsNullOrEmpty(allPurchasePrice) || !allPurchasePrice.IsFractNumbers())
            {
                validResult = new ValidResult(false, "Purchase price must have fraction numbers!");
            }
            else if (float.Parse(allPurchasePrice) <= 0.0f)
            {
                validResult = new ValidResult(false, "All purchase price must be more then 0");
            }
            return validResult;
        }

        public ValidResult ValidateAllSalesPrice(string allSalesPrice)
        {
            if (string.IsNullOrEmpty(allSalesPrice) || !allSalesPrice.IsFractNumbers())
            {
                validResult = new ValidResult(false, "Sales price must have fraction numbers!");
            }
            else if (float.Parse(allSalesPrice) <= 0.0f)
            {
                validResult = new ValidResult(false, "All sales price must be more then 0");
            }
            return validResult;
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

        public ValidResult ValidateDateTime(string dateTime)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(dateTime.ToString()) || !DateTime.TryParse(dateTime, out dateResult))
            {
                validResult = new ValidResult(false, "Date and time must be defined!");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}
