using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.BLL.Entities;
using Grocery.Service.Client.Contract;

namespace Grocery.UI.Contract
{
    public interface IMainWindowController
    {
        void LoadMain(User user, IFrontServiceClient frontServiceClient);
        void LoadLogin();
        void LoadProduct(int id, User user, ArrivedGoods arrivedGoods, Product product, Seller seller, IFrontServiceClient frontServiceClient);
        void LoadSale(User user, Seller seller, IFrontServiceClient frontServiceClient);
        void LoadReport(User user, IFrontServiceClient frontServiceClient);
        void SetView(IViewFactory viewFactory);
        void Exit();
    }
}
