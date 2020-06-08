using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.Service.Domain;
using System.Threading.Tasks;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> ShowTareChanges()
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetTareChangeRequest getTareChangeRequest = new GetTareChangeRequest();

                try
                {
                    GetTareChangeResponse getTareChangeResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetTareChangeRequest, GetTareChangeResponse>>()
                        .Execute(getTareChangeRequest);
                    operationStatusInfo.AttachedObject = getTareChangeResponse.TareChanges;
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
