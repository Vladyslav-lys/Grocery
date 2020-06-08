using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;

namespace Grocery.BLL.Activities
{
    public class GetSalesByClassValidationActivity : IValidationActivity<GetSaleByClassRequest>
    {
        private ISaleByDateValidationRule saleByDateValidationRule;

        public GetSalesByClassValidationActivity(ISaleByDateValidationRule saleByDateValidationRule)
        {
            this.saleByDateValidationRule = saleByDateValidationRule;
        }

        public void Validate(GetSaleByClassRequest request)
        {
            ValidResult validResultSinceDate = saleByDateValidationRule.ValidateSinceDate(request.SinceDate);
            ValidResult validResultToDate = saleByDateValidationRule.ValidateToDate(request.ToDate);

            if (validResultSinceDate.GetError().Length > 0)
            {
                throw new Exception(validResultSinceDate.GetError());
            }
            else if (validResultToDate.GetError().Length > 0)
            {
                throw new Exception(validResultToDate.GetError());
            }
        }
    }
}
