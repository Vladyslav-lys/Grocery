using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetProviderActivity : IGetProviderActivity
    {
        private IProviderRepository providerRepository;

        public GetProviderActivity(IProviderRepository providerRepository)
        {
            this.providerRepository = providerRepository;
        }

        public List<Provider> Run()
        {
            List<Provider> providers = new List<Provider>();

            providerRepository.GetNewAll();
            foreach (Provider curProvider in providerRepository.GetAll())
            {
                Provider provider = new Provider()
                {
                    Id = curProvider.Id,
                    Name = curProvider.Name,
                    Address = curProvider.Address,
                    PhoneNumber = curProvider.PhoneNumber
                };

                providers.Add(provider);
            }
            
            return providers;
        }
    }
}
