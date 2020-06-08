using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;

namespace Grocery.BLL.Activities
{
    public class GetProductsByDateValidationActivity : IValidationActivity<GetProductByDateRequest>
    {
        private IProductByDateValidationRule productByDateValidationRule;

        public GetProductsByDateValidationActivity(IProductByDateValidationRule productByDateValidationRule)
        {
            this.productByDateValidationRule = productByDateValidationRule;
        }

        public void Validate(GetProductByDateRequest request)
        {
            ValidResult validResultDate = productByDateValidationRule.ValidateDate(request.Date);

            if (validResultDate.GetError().Length > 0)
            {
                throw new Exception(validResultDate.GetError());
            }
        }
    }
}
