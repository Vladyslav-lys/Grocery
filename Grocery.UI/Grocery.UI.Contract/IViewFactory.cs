using Grocery.BLL.Entities;
using Grocery.Service.Client.Contract;

namespace Grocery.UI.Contract
{
    public interface IViewFactory
    {
        IViewLogin CreateViewLogin();
        IViewMain CreateViewMain(User user, IFrontServiceClient frontServiceClient);
        IViewProduct CreateViewProduct(int id, ArrivedGoods arrivedGoods, Product product, Seller seller, User user, IFrontServiceClient frontServiceClient);
        IViewSale CreateViewSale(User user, Seller seller, IFrontServiceClient frontServiceClient);
        IViewReport CreateViewReport(User user, IFrontServiceClient frontServiceClient);
    }
}
