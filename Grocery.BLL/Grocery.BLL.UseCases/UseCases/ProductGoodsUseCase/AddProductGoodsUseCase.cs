using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class AddProductGoodsUseCase : IUseCase<AddProductGoodsRequest, AddProductGoodsResponse>
    {
        private IValidationActivity<AddProductGoodsRequest> addProductGoodsValidationActivity;
        private IAddProductActivity addProductActivity;
        private IGetProductActivity getProductActivity;
        private IAddArrivedGoodsActivity addArrivedGoodsActivity;
        private IGetArrivedGoodsActivity getArrivedGoodsActivity;

        public AddProductGoodsUseCase(IValidationActivity<AddProductGoodsRequest> addProductGoodsValidationActivity, IAddProductActivity addProductActivity, IGetProductActivity getProductActivity, IAddArrivedGoodsActivity addArrivedGoodsActivity, IGetArrivedGoodsActivity getArrivedGoodsActivity)
        {
            this.addProductGoodsValidationActivity = addProductGoodsValidationActivity;
            this.addProductActivity = addProductActivity;
            this.getProductActivity = getProductActivity;
            this.addArrivedGoodsActivity = addArrivedGoodsActivity;
            this.getArrivedGoodsActivity = getArrivedGoodsActivity;
        }

        public AddProductGoodsResponse Execute(AddProductGoodsRequest request)
        {
            try
            {
                addProductGoodsValidationActivity.Validate(request);

                addArrivedGoodsActivity.Run(request.Provider, int.Parse(request.Count), DateTime.Parse(request.DateTime), float.Parse(request.AllPurchasePrice), float.Parse(request.AllSalesPrice), request.Department, request.Seller);
                List<ArrivedGoods> arrivedGoods = getArrivedGoodsActivity.Run(request.Department);

                var returnedDate = string.IsNullOrEmpty(request.ReturnedDate) ? (DateTime?)null : DateTime.Parse(request.ReturnedDate);

                addProductActivity.Run(request.Unit, request.Category, request.Class, request.TareChange, int.Parse(request.Count),
                    DateTime.Parse(request.ExpirationDate), arrivedGoods[arrivedGoods.Count-1], float.Parse(request.AllPurchasePrice) / float.Parse(request.Count),
                    float.Parse(request.AllSalesPrice) / float.Parse(request.Count), request.Returned, returnedDate, request.WritenOff);
                List<Product> products = getProductActivity.Run(request.Department);

                return new AddProductGoodsResponse(arrivedGoods, products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
