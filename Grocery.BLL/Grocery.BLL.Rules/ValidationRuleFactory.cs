using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class ValidationRuleFactory : IValidationRuleFactory
    {
        readonly Dictionary<Type, object> ruleCollection = new Dictionary<Type, object>();

        public ValidationRuleFactory()
        {
            // Extension point of the factory
            this.ruleCollection.Add(typeof(IEnterValidationRule), new EnterValidationRule());
            this.ruleCollection.Add(typeof(IReportValidationRule), new ReportValidationRule());
            this.ruleCollection.Add(typeof(ISaleByDateValidationRule), new SaleByDateValidationRule());
            this.ruleCollection.Add(typeof(ISaleValidationRule), new SaleValidationRule());
            this.ruleCollection.Add(typeof(IArrivedGoodsValidationRule), new ArrivedGoodsValidationRule());
            this.ruleCollection.Add(typeof(IProductValidationRule), new ProductValidationRule());
            this.ruleCollection.Add(typeof(IProductByDateValidationRule), new ProductByDateValidationRule());
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
