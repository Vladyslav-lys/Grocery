using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetSellerUseCase : IUseCase<GetSellerRequest, GetSellerResponse>
    {
        private IGetSellerActivity getSellerActivity;

        public GetSellerUseCase(IGetSellerActivity getSellerActivity)
        {
            this.getSellerActivity = getSellerActivity;
        }

        public GetSellerResponse Execute(GetSellerRequest request)
        {
            try
            {
                Seller seller = getSellerActivity.Run(request.User);
                return new GetSellerResponse(seller);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
