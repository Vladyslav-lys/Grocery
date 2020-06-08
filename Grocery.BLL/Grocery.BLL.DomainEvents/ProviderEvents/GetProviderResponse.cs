using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetProviderResponse
    {
        public List<Provider> Providers { get; set; }

        public GetProviderResponse(List<Provider> providers)
        {
            this.Providers = providers;
        }
    }
}
