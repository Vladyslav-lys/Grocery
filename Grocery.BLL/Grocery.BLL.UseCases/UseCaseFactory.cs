using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;

namespace Grocery.BLL.UseCases
{
    public class UseCaseFactory : IUseCaseFactory
    {
        readonly Dictionary<Type, object> collection = new Dictionary<Type, object>();

        public UseCaseFactory(IActivityFactory activityFactory)
        {
            this.collection.Add(typeof(IUseCase<AddProductGoodsRequest, AddProductGoodsResponse>),
                new AddProductGoodsUseCase(activityFactory.Create<IValidationActivity<AddProductGoodsRequest>>(),
                activityFactory.Create<IAddProductActivity>(),
                activityFactory.Create<IGetProductActivity>(),
                activityFactory.Create<IAddArrivedGoodsActivity>(),
                activityFactory.Create<IGetArrivedGoodsActivity>()));
            this.collection.Add(typeof(IUseCase<EditProductGoodsRequest, EditProductGoodsResponse>),
                new EditProductGoodsUseCase(activityFactory.Create<IValidationActivity<EditProductGoodsRequest>>(),
                activityFactory.Create<IEditProductActivity>(),
                activityFactory.Create<IGetProductActivity>(),
                activityFactory.Create<IEditArrivedGoodsActivity>(),
                activityFactory.Create<IGetArrivedGoodsActivity>()));
            this.collection.Add(typeof(IUseCase<GetArrivedGoodsRequest, GetArrivedGoodsResponse>), 
                new GetArrivedGoodsUseCase(activityFactory.Create<IGetArrivedGoodsActivity>()));
            this.collection.Add(typeof(IUseCase<GetProductRequest, GetProductResponse>),
                new GetProductUseCase(activityFactory.Create<IGetProductActivity>()));
            this.collection.Add(typeof(IUseCase<GetProductByDateRequest, GetProductByDateResponse>),
                new GetProductByDateUseCase(activityFactory.Create<IValidationActivity<GetProductByDateRequest>>(), activityFactory.Create<IGetProductsByDateActivity>()));

            this.collection.Add(typeof(IUseCase<GetCategoryRequest, GetCategoryResponse>),
                new GetCategoryUseCase(activityFactory.Create<IGetCategoryActivity>()));

            this.collection.Add(typeof(IUseCase<GetClassRequest, GetClassResponse>),
                new GetClassUseCase(activityFactory.Create<IGetClassActivity>()));
            
            this.collection.Add(typeof(IUseCase<GetDepartmentRequest, GetDepartmentResponse>),
                new GetDepartmentUseCase(activityFactory.Create<IGetDepartmentActivity>()));

            this.collection.Add(typeof(IUseCase<GetProviderRequest, GetProviderResponse>),
                new GetProviderUseCase(activityFactory.Create<IGetProviderActivity>()));

            this.collection.Add(typeof(IUseCase<GetReportDetailedRequest, GetReportDetailedResponse>),
                new GetReportDetailedUseCase(activityFactory.Create<IValidationActivity<GetReportDetailedRequest>>(), activityFactory.Create<IGetReportDetailedActivity>()));
            this.collection.Add(typeof(IUseCase<GetReportSimpleRequest, GetReportSimpleResponse>),
                new GetReportSimpleUseCase(activityFactory.Create<IValidationActivity<GetReportSimpleRequest>>(), activityFactory.Create<IGetReportSimpleActivity>()));

            this.collection.Add(typeof(IUseCase<AddSaleRequest, AddSaleResponse>),
                new AddSaleUseCase(activityFactory.Create<IValidationActivity<AddSaleRequest>>(),
                activityFactory.Create<IAddSaleActivity>(),
                activityFactory.Create<IGetSaleActivity>(),
                activityFactory.Create<IEditProductActivity>(),
                activityFactory.Create<IGetProductActivity>()));
            this.collection.Add(typeof(IUseCase<GetSaleRequest, GetSaleResponse>),
                new GetSaleUseCase(activityFactory.Create<IGetSaleActivity>()));
            this.collection.Add(typeof(IUseCase<GetSaleByClassRequest, GetSaleByClassResponse>),
                new GetSaleByClassUseCase(activityFactory.Create<IValidationActivity<GetSaleByClassRequest>>(), activityFactory.Create<IGetSalesByClassActivity>()));

            this.collection.Add(typeof(IUseCase<GetTareChangeRequest, GetTareChangeResponse>),
                new GetTareChangeUseCase(activityFactory.Create<IGetTareChangeActivity>()));

            this.collection.Add(typeof(IUseCase<GetUserRequest, GetUserResponse>),
                new GetUserUseCase(activityFactory.Create<IValidationActivity<GetUserRequest>>(), activityFactory.Create<IGetUserActivity>()));

            this.collection.Add(typeof(IUseCase<GetSellerRequest, GetSellerResponse>),
                new GetSellerUseCase(activityFactory.Create<IGetSellerActivity>()));
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.collection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + " is missing in the collection");
            }

            return (T)this.collection[type];
        }
    }
}
