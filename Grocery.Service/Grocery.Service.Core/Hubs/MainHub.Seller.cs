using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using Grocery.Service.Domain;
using Grocery.BLL.Entities;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> FindSeller(User user)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetSellerRequest getSellerRequest = new GetSellerRequest(user);

                try
                {
                    GetSellerResponse getSellerResponse = hubEnvironment.UseCaseFactory.Create<IUseCase<GetSellerRequest, GetSellerResponse>>().Execute(getSellerRequest);
                    operationStatusInfo.AttachedObject = getSellerResponse.Seller;
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
