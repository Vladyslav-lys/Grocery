using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using System.Threading.Tasks;
using Grocery.Service.Domain;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> ShowClass()
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetClassRequest getClassRequest = new GetClassRequest();

                try
                {
                    GetClassResponse getClassResponse = hubEnvironment.UseCaseFactory.Create<IUseCase<GetClassRequest, GetClassResponse>>().Execute(getClassRequest);
                    operationStatusInfo.AttachedObject = getClassResponse.Classes;
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
