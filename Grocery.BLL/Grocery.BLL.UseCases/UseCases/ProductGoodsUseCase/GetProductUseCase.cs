using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class GetProductUseCase : IUseCase<GetProductRequest, GetProductResponse>
    {
        private IGetProductActivity getProductActivity;

        public GetProductUseCase(IGetProductActivity getProductActivity)
        {
            this.getProductActivity = getProductActivity;
        }

        public GetProductResponse Execute(GetProductRequest request)
        {
            try
            {
                List<Product> products = getProductActivity.Run(request.Department);
                return new GetProductResponse(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
