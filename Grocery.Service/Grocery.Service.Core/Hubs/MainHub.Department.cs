using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using Grocery.Service.Domain;
using System.Threading.Tasks;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> ShowDepartment()
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetDepartmentRequest getDepartmentRequest = new GetDepartmentRequest();

                try
                {
                    GetDepartmentResponse getDepartmentResponse = hubEnvironment.UseCaseFactory.Create<IUseCase<GetDepartmentRequest, GetDepartmentResponse>>().Execute(getDepartmentRequest);
                    operationStatusInfo.AttachedObject = getDepartmentResponse.Departments;
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
