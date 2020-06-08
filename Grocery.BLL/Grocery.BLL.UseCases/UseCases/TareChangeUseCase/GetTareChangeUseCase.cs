using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetTareChangeUseCase : IUseCase<GetTareChangeRequest, GetTareChangeResponse>
    {
        private IGetTareChangeActivity getTareChangeActivity;

        public GetTareChangeUseCase(IGetTareChangeActivity getTareChangeActivity)
        {
            this.getTareChangeActivity = getTareChangeActivity;
        }

        public GetTareChangeResponse Execute(GetTareChangeRequest request)
        {
            try
            {
                List<TareChange> tareChanges = getTareChangeActivity.Run();
                return new GetTareChangeResponse(tareChanges);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
