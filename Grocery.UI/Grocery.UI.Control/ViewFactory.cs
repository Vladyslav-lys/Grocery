using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.UI.Contract;
using Grocery.BLL.Entities;
using Grocery.Service.Client.Contract;
using Grocery.UI.ViewModel;

namespace Grocery.UI.Control
{
    public class ViewFactory : IViewFactory
    {
        private IViewModelFactory viewModelFactory;

        public ViewFactory(IViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        public IViewLogin CreateViewLogin()
        {
            return new LoginView(this.viewModelFactory.CreateViewModelLogin());
        }

        public IViewMain CreateViewMain(User user, IFrontServiceClient frontServiceClient)
        {
            return new MainView(this.viewModelFactory.CreateViewModelMain(user, frontServiceClient));
        }

        public IViewProduct CreateViewProduct(int id, ArrivedGoods arrivedGoods, Product product, Seller seller, User user, IFrontServiceClient frontServiceClient)
        {
            return new ProductView(this.viewModelFactory.CreateViewModelProduct(id, arrivedGoods, product, seller, user, frontServiceClient));
        }

        public IViewSale CreateViewSale(User user, Seller seller, IFrontServiceClient frontServiceClient)
        {
            return new SaleView(this.viewModelFactory.CreateViewModelSale(user, seller, frontServiceClient));
        }

        public IViewReport CreateViewReport(User user, IFrontServiceClient frontServiceClient)
        {
            return new ReportView(this.viewModelFactory.CreateViewModelReport(user, frontServiceClient));
        }
    }
}
