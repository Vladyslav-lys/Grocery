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
        public async Task<OperationStatusInfo> ShowCategories()
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetCategoryRequest getCategoryRequest = new GetCategoryRequest();

                try
                {
                    GetCategoryResponse getCategoryResponse = hubEnvironment.UseCaseFactory.Create<IUseCase<GetCategoryRequest, GetCategoryResponse>>().Execute(getCategoryRequest);
                    operationStatusInfo.AttachedObject = getCategoryResponse.Categories;
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
