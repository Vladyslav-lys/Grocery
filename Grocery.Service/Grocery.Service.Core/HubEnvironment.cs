using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using Grocery.DAL.Contract;
using Grocery.DAL.Contexts;
using Grocery.DAL.Repositories;
using Grocery.BLL.Activities;
using Grocery.BLL.Contract;
using Grocery.BLL.UseCases;

namespace Grocery.Service.Core
{
    public class HubEnvironment
    {
        private IHubContext<MainHub> hubContext;
        private IUseCaseFactory useCaseFactory;

        public HubEnvironment(IHubContext<MainHub> hubContext, IValidationRuleFactory validationRuleFactory)
        {
            IRepositoryFactory repositoryFactory = new RepositoryFactory(new DBContext());
            IActivityFactory activityFactory = new ActivityFactory(repositoryFactory, validationRuleFactory);

            this.useCaseFactory = new UseCaseFactory(activityFactory);
            this.hubContext = hubContext;
        }

        public IUseCaseFactory UseCaseFactory
        {
            get { return this.useCaseFactory; }
            set { this.useCaseFactory = value; }
        }
    }
}
