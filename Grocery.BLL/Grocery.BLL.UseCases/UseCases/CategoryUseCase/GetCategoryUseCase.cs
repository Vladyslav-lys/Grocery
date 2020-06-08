using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetCategoryUseCase : IUseCase<GetCategoryRequest, GetCategoryResponse>
    {
        private IGetCategoryActivity getCategoryActivity;

        public GetCategoryUseCase(IGetCategoryActivity getCategoryActivity)
        {
            this.getCategoryActivity = getCategoryActivity;
        }

        public GetCategoryResponse Execute(GetCategoryRequest request)
        {
            try
            {
                List<Category> categories = getCategoryActivity.Run();
                return new GetCategoryResponse(categories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
