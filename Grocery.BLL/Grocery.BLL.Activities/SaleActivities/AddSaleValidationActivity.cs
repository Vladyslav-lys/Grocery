using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;

namespace Grocery.BLL.Activities
{
    public class AddSaleValidationActivity : IValidationActivity<AddSaleRequest>
    {
        private ISaleValidationRule saleValidationRule;

        public AddSaleValidationActivity(ISaleValidationRule saleValidationRule)
        {
            this.saleValidationRule = saleValidationRule;
        }

        public void Validate(AddSaleRequest request)
        {
            ValidResult validResultCount = saleValidationRule.ValidateCount(request.Count);
            ValidResult validResultDatetime = saleValidationRule.ValidateDatetime(request.DateTime);
            ValidResult validResultProduct = saleValidationRule.ValidateProduct(request.Product);

            if (validResultCount.GetError().Length > 0)
            {
                throw new Exception(validResultCount.GetError());
            }
            else if (validResultDatetime.GetError().Length > 0)
            {
                throw new Exception(validResultDatetime.GetError());
            }
            else if (validResultProduct.GetError().Length > 0)
            {
                throw new Exception(validResultDatetime.GetError());
            }
        }
    }
}
