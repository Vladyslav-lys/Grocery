using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.UseCases
{
    public class AddSaleUseCase : IUseCase<AddSaleRequest, AddSaleResponse>
    {
        private IValidationActivity<AddSaleRequest> addSaleValidationActivity;
        private IAddSaleActivity addSaleActivity;
        private IGetSaleActivity getSaleActivity;
        private IEditProductActivity editProductActivity;
        private IGetProductActivity getProductActivity;

        public AddSaleUseCase(IValidationActivity<AddSaleRequest> addSaleValidationActivity, IAddSaleActivity addSaleActivity, 
            IGetSaleActivity getSaleActivity, IEditProductActivity editProductActivity, IGetProductActivity getProductActivity)
        {
            this.addSaleValidationActivity = addSaleValidationActivity;
            this.addSaleActivity = addSaleActivity;
            this.getSaleActivity = getSaleActivity;
            this.editProductActivity = editProductActivity;
            this.getProductActivity = getProductActivity;
        }

        public AddSaleResponse Execute(AddSaleRequest request)
        {
            try
            {
                addSaleValidationActivity.Validate(request);
                addSaleActivity.Run(request.Product, int.Parse(request.Count), DateTime.Parse(request.DateTime), float.Parse(request.Price), request.Seller);
                List<Sale> sales = getSaleActivity.Run(request.Product.ArrivedGoods.Department);

                editProductActivity.Run(request.Product.Id, request.Product.Unit, request.Product.Category, request.Product.Class,
                    request.Product.TareChange, (request.Product.Count - int.Parse(request.Count)), request.Product.ExpirationDate, 
                    request.Product.ArrivedGoods, request.Product.PurchasePrice, request.Product.SalesPrice, request.Product.Returned, 
                    request.Product.ReturnedDate, request.Product.WritenOff);
                List<Product> products = getProductActivity.Run(request.Product.ArrivedGoods.Department);

                return new AddSaleResponse(sales, products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
