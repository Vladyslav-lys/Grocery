using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetUserUseCase : IUseCase<GetUserRequest, GetUserResponse>
    {
        private IValidationActivity<GetUserRequest> enterValidationActivity;
        private IGetUserActivity getUserActivity;

        public GetUserUseCase(IValidationActivity<GetUserRequest> enterValidationActivity, IGetUserActivity getUserActivity)
        {
            this.enterValidationActivity = enterValidationActivity;
            this.getUserActivity = getUserActivity;
        }

        public GetUserResponse Execute(GetUserRequest request)
        {
            try
            {
                enterValidationActivity.Validate(request);
                User user = getUserActivity.Run(request.Login, request.Password);
                return new GetUserResponse(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
