using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetArrivedGoodsUseCase : IUseCase<GetArrivedGoodsRequest, GetArrivedGoodsResponse>
    {
        private IGetArrivedGoodsActivity getArrivedGoodsActivity;

        public GetArrivedGoodsUseCase(IGetArrivedGoodsActivity getArrivedGoodsActivity)
        {
            this.getArrivedGoodsActivity = getArrivedGoodsActivity;
        }

        public GetArrivedGoodsResponse Execute(GetArrivedGoodsRequest request)
        {
            try
            {
                List<ArrivedGoods> arrivedGoods = getArrivedGoodsActivity.Run(request.Department);
                return new GetArrivedGoodsResponse(arrivedGoods);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
