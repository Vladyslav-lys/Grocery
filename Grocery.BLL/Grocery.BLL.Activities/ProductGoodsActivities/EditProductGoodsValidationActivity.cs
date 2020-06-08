using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;

namespace Grocery.BLL.Activities
{
    public class EditProductGoodsValidationActivity : IValidationActivity<EditProductGoodsRequest>
    {
        private IArrivedGoodsValidationRule arrivedGoodsValidationRule;
        private IProductValidationRule productValidationRule;

        public EditProductGoodsValidationActivity(IArrivedGoodsValidationRule arrivedGoodsValidationRule, IProductValidationRule productValidationRule)
        {
            this.arrivedGoodsValidationRule = arrivedGoodsValidationRule;
            this.productValidationRule = productValidationRule;
        }

        public void Validate(EditProductGoodsRequest request)
        {
            ValidResult validResultUnit = productValidationRule.ValidateUnit(request.Unit);
            ValidResult validResultCount = arrivedGoodsValidationRule.ValidateCount(request.Count);
            ValidResult validResultDatetime = arrivedGoodsValidationRule.ValidateDateTime(request.DateTime);
            ValidResult validResultAllPurchasePrice = arrivedGoodsValidationRule.ValidateAllPurchasePrice(request.AllPurchasePrice);
            ValidResult validResultAllSalesPrice = arrivedGoodsValidationRule.ValidateAllSalesPrice(request.AllSalesPrice);
            ValidResult validResultExpirationDate = productValidationRule.ValidateExpirationDate(request.ExpirationDate);
            ValidResult validResultReturnedDate = productValidationRule.ValidateReturnedDate(request.ReturnedDate, request.Returned);

            if (validResultUnit.GetError().Length > 0)
            {
                throw new Exception(validResultUnit.GetError());
            }
            else if (validResultCount.GetError().Length > 0)
            {
                throw new Exception(validResultCount.GetError());
            }
            else if (validResultDatetime.GetError().Length > 0)
            {
                throw new Exception(validResultDatetime.GetError());
            }
            else if (validResultExpirationDate.GetError().Length > 0)
            {
                throw new Exception(validResultExpirationDate.GetError());
            }
            else if (validResultAllPurchasePrice.GetError().Length > 0)
            {
                throw new Exception(validResultAllPurchasePrice.GetError());
            }
            else if (validResultAllSalesPrice.GetError().Length > 0)
            {
                throw new Exception(validResultAllSalesPrice.GetError());
            }
            else if (validResultReturnedDate.GetError().Length > 0)
            {
                throw new Exception(validResultReturnedDate.GetError());
            }
        }
    }
}
