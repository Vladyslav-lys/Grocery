using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class EditProductGoodsUseCase : IUseCase<EditProductGoodsRequest, EditProductGoodsResponse>
    {
        private IValidationActivity<EditProductGoodsRequest> editProductGoodsValidationActivity;
        private IEditProductActivity editProductActivity;
        private IGetProductActivity getProductActivity;
        private IEditArrivedGoodsActivity editArrivedGoodsActivity;
        private IGetArrivedGoodsActivity getArrivedGoodsActivity;

        public EditProductGoodsUseCase(IValidationActivity<EditProductGoodsRequest> editProductGoodsValidationActivity, IEditProductActivity editProductActivity, IGetProductActivity getProductActivity, IEditArrivedGoodsActivity editArrivedGoodsActivity, IGetArrivedGoodsActivity getArrivedGoodsActivity)
        {
            this.editProductGoodsValidationActivity = editProductGoodsValidationActivity;
            this.editProductActivity = editProductActivity;
            this.getProductActivity = getProductActivity;
            this.editArrivedGoodsActivity = editArrivedGoodsActivity;
            this.getArrivedGoodsActivity = getArrivedGoodsActivity;
        }

        public EditProductGoodsResponse Execute(EditProductGoodsRequest request)
        {
            try
            {
                editProductGoodsValidationActivity.Validate(request);

                editArrivedGoodsActivity.Run(request.ArrivedGoods.Id, request.Provider, int.Parse(request.Count), DateTime.Parse(request.DateTime), float.Parse(request.AllPurchasePrice), float.Parse(request.AllSalesPrice), request.Department, request.Seller);
                List<ArrivedGoods> arrivedGoods = getArrivedGoodsActivity.Run(request.Department);

                var returnedDate = string.IsNullOrEmpty(request.ReturnedDate) ? (DateTime?)null : DateTime.Parse(request.ReturnedDate);

                editProductActivity.Run(request.Id, request.Unit, request.Category, request.Class, request.TareChange, int.Parse(request.Count),
                    DateTime.Parse(request.ExpirationDate), request.ArrivedGoods, float.Parse(request.AllPurchasePrice)/float.Parse(request.Count),
                    float.Parse(request.AllSalesPrice) / float.Parse(request.Count), request.Returned, returnedDate, request.WritenOff);
                List<Product> products = getProductActivity.Run(request.Department);

                return new EditProductGoodsResponse(arrivedGoods, products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
