using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using Grocery.Service.Domain;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> Enter(string login, string password)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetUserRequest getUserRequest = new GetUserRequest(login, password);

                try
                {
                    GetUserResponse getUserResponse = hubEnvironment.UseCaseFactory.Create<IUseCase<GetUserRequest, GetUserResponse>>().Execute(getUserRequest);
                    operationStatusInfo.AttachedObject = getUserResponse.User;
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
