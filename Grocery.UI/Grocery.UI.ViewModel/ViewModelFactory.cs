using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.BLL.Entities;
using Grocery.UI.Contract;
using Grocery.Service.Client.Contract;
using Grocery.BLL.Contract;

namespace Grocery.UI.ViewModel
{
    public class ViewModelFactory : IViewModelFactory
    {
        IValidationRuleFactory validationRuleFactory;
        IMainWindowController mainWindowController;
        IFrontServiceClient frontServiceClient;

        public ViewModelFactory(IValidationRuleFactory validationRuleFactory, IMainWindowController mainWindowController, IFrontServiceClient frontServiceClient)
        {
            this.validationRuleFactory = validationRuleFactory;
            this.mainWindowController = mainWindowController;
            this.frontServiceClient = frontServiceClient;
        }

        public IViewModelLogin CreateViewModelLogin()
        {
            return new ViewModelLogin(validationRuleFactory.Create<IEnterValidationRule>(), mainWindowController, frontServiceClient);
        }

        public IViewModelMain CreateViewModelMain(User user, IFrontServiceClient frontServiceClient)
        {
            return new ViewModelMain(validationRuleFactory.Create<IProductByDateValidationRule>(), validationRuleFactory.Create<ISaleByDateValidationRule>(), mainWindowController, frontServiceClient, user);
        }

        public IViewModelProduct CreateViewModelProduct(int id, ArrivedGoods arrivedGoods, Product product, Seller seller, User user, IFrontServiceClient frontServiceClient)
        {
            return new ViewModelProduct(validationRuleFactory.Create<IArrivedGoodsValidationRule>(), validationRuleFactory.Create<IProductValidationRule>(), mainWindowController, frontServiceClient, arrivedGoods, product, seller, user, id);
        }

        public IViewModelSale CreateViewModelSale(User user, Seller seller, IFrontServiceClient frontServiceClient)
        {
            return new ViewModelSale(validationRuleFactory.Create<ISaleValidationRule>(), validationRuleFactory.Create<IProductValidationRule>(), mainWindowController, frontServiceClient, seller, user);
        }

        public IViewModelReport CreateViewModelReport(User user, IFrontServiceClient frontServiceClient)
        {
            return new ViewModelReport(validationRuleFactory.Create<IReportValidationRule>(), mainWindowController, frontServiceClient, user);
        }
    }
}
