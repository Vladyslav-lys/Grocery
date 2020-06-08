using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class ReportValidationRule : ValidationBase, IReportValidationRule
    {
        public ReportValidationRule() : base()
        {

        }

        public ValidResult ValidateSinceDate(string sinceDate)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(sinceDate.ToString()) || !DateTime.TryParse(sinceDate, out dateResult))
            {
                validResult = new ValidResult(false, "Date must be filled!");
            }
            return validResult;
        }

        public ValidResult ValidateToDate(string toDate)
        {
            DateTime dateResult;

            if (string.IsNullOrEmpty(toDate.ToString()) || !DateTime.TryParse(toDate, out dateResult))
            {
                validResult = new ValidResult(false, "Date must be filled!");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}
