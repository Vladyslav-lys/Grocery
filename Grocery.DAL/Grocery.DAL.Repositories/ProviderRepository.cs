using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private DBContext db;

        public ProviderRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(Provider provider)
        {
            if (provider != null)
            {
                db.InsertProvider(provider);
            }
        }

        public void Delete(Provider provider)
        {
            Provider curProvider = this.FindById(provider.Id);

            if (curProvider != null)
            {
                db.DropProvider(provider);
                db.Providers.Remove(curProvider);
            }
        }

        public Provider FindById(int id)
        {
            foreach (Provider curProvider in this.GetAll())
            {
                if (curProvider.Id == id)
                    return curProvider;
            }
            return null;
        }

        public List<Provider> GetAll()
        {
            return db.Providers;
        }

        public void GetNewAll()
        {
            db.GetProvidersFromDatabase();
        }

        public void Update(Provider provider)
        {
            if (provider != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Providers[i].Id == provider.Id)
                    {
                        db.Providers[i].Name = provider.Name;
                        db.Providers[i].Address = provider.Address;
                        db.Providers[i].PhoneNumber = provider.PhoneNumber;
                    }
                }
                db.UpdateProvider(provider);
            }
        }
    }
}
