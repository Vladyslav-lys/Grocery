using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetClassUseCase : IUseCase<GetClassRequest, GetClassResponse>
    {
        private IGetClassActivity getClassActivity;

        public GetClassUseCase(IGetClassActivity getClassActivity)
        {
            this.getClassActivity = getClassActivity;
        }

        public GetClassResponse Execute(GetClassRequest request)
        {
            try
            {
                List<Class> classes = getClassActivity.Run();
                return new GetClassResponse(classes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
