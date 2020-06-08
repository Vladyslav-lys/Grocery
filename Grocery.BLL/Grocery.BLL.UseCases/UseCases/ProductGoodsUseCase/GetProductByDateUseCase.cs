using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetProductByDateUseCase : IUseCase<GetProductByDateRequest, GetProductByDateResponse>
    {
        private IValidationActivity<GetProductByDateRequest> getProductByDateValidationActivity;
        private IGetProductsByDateActivity getProductsByDateActivity;

        public GetProductByDateUseCase(IValidationActivity<GetProductByDateRequest> getProductByDateValidationActivity, IGetProductsByDateActivity getProductsByDateActivity)
        {
            this.getProductByDateValidationActivity = getProductByDateValidationActivity;
            this.getProductsByDateActivity = getProductsByDateActivity;
        }

        public GetProductByDateResponse Execute(GetProductByDateRequest request)
        {
            getProductByDateValidationActivity.Validate(request);
            List<Product> products = getProductsByDateActivity.Run(DateTime.Parse(request.Date));
            return new GetProductByDateResponse(products);
        }
    }
}
