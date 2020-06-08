using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetProviderUseCase : IUseCase<GetProviderRequest, GetProviderResponse>
    {
        private IGetProviderActivity getProviderActivity;

        public GetProviderUseCase(IGetProviderActivity getProviderActivity)
        {
            this.getProviderActivity = getProviderActivity;
        }

        public GetProviderResponse Execute(GetProviderRequest request)
        {
            try
            {
                List<Provider> providers = getProviderActivity.Run();
                return new GetProviderResponse(providers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
