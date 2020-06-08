using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contexts;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.DAL.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        readonly Dictionary<Type, object> collection = new Dictionary<Type, object>();

        public RepositoryFactory(DBContext context)
        {
            // Extension point of the factory
            this.collection.Add(typeof(IArrivedGoodsRepository), new ArrivedGoodsRepository(context));
            this.collection.Add(typeof(ICategoryRepository), new CategoryRepository(context));
            this.collection.Add(typeof(IClassRepository), new ClassRepository(context));
            this.collection.Add(typeof(IDepartmentRepository), new DepartmentRepository(context));
            this.collection.Add(typeof(IProductRepository), new ProductRepository(context));
            this.collection.Add(typeof(IProviderRepository), new ProviderRepository(context));
            this.collection.Add(typeof(ISaleRepository), new SaleRepository(context));
            this.collection.Add(typeof(ISellerRepository), new SellerRepository(context));
            this.collection.Add(typeof(ITareChangeRepository), new TareChangeRepository(context));
            this.collection.Add(typeof(IUserRepository), new UserRepository(context));
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.collection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the collection");
            }

            return (T)this.collection[type];
        }
    }
}
