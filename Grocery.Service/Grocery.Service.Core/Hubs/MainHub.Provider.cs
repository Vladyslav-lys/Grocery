using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.Service.Domain;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> ShowProviders()
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetProviderRequest getProviderRequest = new GetProviderRequest();

                try
                {
                    GetProviderResponse getProviderResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetProviderRequest, GetProviderResponse>>()
                        .Execute(getProviderRequest);
                    operationStatusInfo.AttachedObject = getProviderResponse.Providers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }
    }
}
