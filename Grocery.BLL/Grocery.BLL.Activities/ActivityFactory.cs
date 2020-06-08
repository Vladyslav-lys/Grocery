using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class ActivityFactory : IActivityFactory
    {
        readonly Dictionary<Type, object> ruleCollection = new Dictionary<Type, object>();

        public ActivityFactory(IRepositoryFactory repositoryFactory, IValidationRuleFactory validationRuleFactory)
        {
            this.ruleCollection.Add(typeof(IValidationActivity<AddProductGoodsRequest>), new AddProductGoodsValidationActivity(validationRuleFactory.Create<IArrivedGoodsValidationRule>(), validationRuleFactory.Create<IProductValidationRule>()));
            this.ruleCollection.Add(typeof(IValidationActivity<EditProductGoodsRequest>), new EditProductGoodsValidationActivity(validationRuleFactory.Create<IArrivedGoodsValidationRule>(), validationRuleFactory.Create<IProductValidationRule>()));
            this.ruleCollection.Add(typeof(IValidationActivity<GetProductByDateRequest>), new GetProductsByDateValidationActivity(validationRuleFactory.Create<IProductByDateValidationRule>()));
            this.ruleCollection.Add(typeof(IGetArrivedGoodsActivity), new GetArrivedGoodsActivity(repositoryFactory.Create<IArrivedGoodsRepository>()));
            this.ruleCollection.Add(typeof(IAddArrivedGoodsActivity), new AddArrivedGoodsActivity(repositoryFactory.Create<IArrivedGoodsRepository>()));
            this.ruleCollection.Add(typeof(IEditArrivedGoodsActivity), new EditArrivedGoodsActivity(repositoryFactory.Create<IArrivedGoodsRepository>()));
            this.ruleCollection.Add(typeof(IAddProductActivity), new AddProductActivity(repositoryFactory.Create<IProductRepository>()));
            this.ruleCollection.Add(typeof(IEditProductActivity), new EditProductActivity(repositoryFactory.Create<IProductRepository>()));
            this.ruleCollection.Add(typeof(IGetProductsByDateActivity), new GetProductsByDateActivity(repositoryFactory.Create<IProductRepository>()));
            this.ruleCollection.Add(typeof(IGetProductActivity), new GetProductActivity(repositoryFactory.Create<IProductRepository>()));

            this.ruleCollection.Add(typeof(IGetCategoryActivity), new GetCategoryActivity(repositoryFactory.Create<ICategoryRepository>()));

            this.ruleCollection.Add(typeof(IGetClassActivity), new GetClassActivity(repositoryFactory.Create<IClassRepository>()));

            this.ruleCollection.Add(typeof(IGetDepartmentActivity), new GetDepartmentActivity(repositoryFactory.Create<IDepartmentRepository>()));

            this.ruleCollection.Add(typeof(IGetProviderActivity), new GetProviderActivity(repositoryFactory.Create<IProviderRepository>()));

            this.ruleCollection.Add(typeof(IValidationActivity<GetReportDetailedRequest>), new ReportDetailedVaildationActivity(validationRuleFactory.Create<IReportValidationRule>()));
            this.ruleCollection.Add(typeof(IGetReportDetailedActivity), new GetReportDetailedActivity(repositoryFactory.Create<IClassRepository>(),
                repositoryFactory.Create<ISaleRepository>(), repositoryFactory.Create<IProductRepository>()));

            this.ruleCollection.Add(typeof(IValidationActivity<GetReportSimpleRequest>), new ReportSimpleVaildationActivity(validationRuleFactory.Create<IReportValidationRule>()));
            this.ruleCollection.Add(typeof(IGetReportSimpleActivity), new GetReportSimpleActivity(repositoryFactory.Create<IClassRepository>(),
                repositoryFactory.Create<ISaleRepository>(), repositoryFactory.Create<IProductRepository>()));

            this.ruleCollection.Add(typeof(IValidationActivity<AddSaleRequest>), new AddSaleValidationActivity(validationRuleFactory.Create<ISaleValidationRule>()));
            this.ruleCollection.Add(typeof(IValidationActivity<GetSaleByClassRequest>), new GetSalesByClassValidationActivity(validationRuleFactory.Create<ISaleByDateValidationRule>()));
            this.ruleCollection.Add(typeof(IAddSaleActivity), new AddSaleActivity(repositoryFactory.Create<ISaleRepository>()));
            this.ruleCollection.Add(typeof(IGetSalesByClassActivity), new GetSalesByClassActivity(repositoryFactory.Create<ISaleRepository>()));
            this.ruleCollection.Add(typeof(IGetSaleActivity), new GetSaleActivity(repositoryFactory.Create<ISaleRepository>()));

            this.ruleCollection.Add(typeof(IGetSellerActivity), new GetSellerActivity(repositoryFactory.Create<ISellerRepository>()));

            this.ruleCollection.Add(typeof(IGetTareChangeActivity), new GetTareChangeActivity(repositoryFactory.Create<ITareChangeRepository>()));

            this.ruleCollection.Add(typeof(IValidationActivity<GetUserRequest>), new EnterValidationActivity(validationRuleFactory.Create<IEnterValidationRule>()));
            this.ruleCollection.Add(typeof(IGetUserActivity), new GetUserActivity(repositoryFactory.Create<IUserRepository>()));
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.ruleCollection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the rule collection");
            }

            return (T)this.ruleCollection[type];
        }
    }
}
