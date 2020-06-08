using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetSaleByClassUseCase : IUseCase<GetSaleByClassRequest, GetSaleByClassResponse>
    {
        private IValidationActivity<GetSaleByClassRequest> getSaleByClassValidationActivity;
        private IGetSalesByClassActivity getSalesByClassActivity;

        public GetSaleByClassUseCase(IValidationActivity<GetSaleByClassRequest> getSaleByClassValidationActivity, IGetSalesByClassActivity getSalesByClassActivity)
        {
            this.getSaleByClassValidationActivity = getSaleByClassValidationActivity;
            this.getSalesByClassActivity = getSalesByClassActivity;
        }

        public GetSaleByClassResponse Execute(GetSaleByClassRequest request)
        {
            getSaleByClassValidationActivity.Validate(request);
            List<Sale> sales = getSalesByClassActivity.Run(request.Class, DateTime.Parse(request.SinceDate), DateTime.Parse(request.ToDate));
            return new GetSaleByClassResponse(sales);
        }
    }
}
