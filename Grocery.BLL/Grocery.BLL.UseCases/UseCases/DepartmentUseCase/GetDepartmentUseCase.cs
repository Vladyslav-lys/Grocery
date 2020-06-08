using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetDepartmentUseCase : IUseCase<GetDepartmentRequest, GetDepartmentResponse>
    {
        private IGetDepartmentActivity getDepartmentActivity;

        public GetDepartmentUseCase(IGetDepartmentActivity getDepartmentActivity)
        {
            this.getDepartmentActivity = getDepartmentActivity;
        }

        public GetDepartmentResponse Execute(GetDepartmentRequest request)
        {
            try
            {
                List<Department> departments = getDepartmentActivity.Run();
                return new GetDepartmentResponse(departments);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
