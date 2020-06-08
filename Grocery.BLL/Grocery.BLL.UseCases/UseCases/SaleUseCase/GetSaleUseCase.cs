using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetSaleUseCase : IUseCase<GetSaleRequest, GetSaleResponse>
    {
        private IGetSaleActivity getSaleActivity;

        public GetSaleUseCase(IGetSaleActivity getSaleActivity)
        {
            this.getSaleActivity = getSaleActivity;
        }

        public GetSaleResponse Execute(GetSaleRequest request)
        {
            try
            {
                List<Sale> sales = getSaleActivity.Run(request.Department);
                return new GetSaleResponse(sales);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
