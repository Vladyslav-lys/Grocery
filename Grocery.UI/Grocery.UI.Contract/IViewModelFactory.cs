using Grocery.BLL.Entities;
using Grocery.Service.Client.Contract;

namespace Grocery.UI.Contract
{
    public interface IViewModelFactory
    {
        IViewModelLogin CreateViewModelLogin();
        IViewModelMain CreateViewModelMain(User user, IFrontServiceClient frontServiceClient);
        IViewModelProduct CreateViewModelProduct(int id, ArrivedGoods arrivedGoods, Product product, Seller seller, User user, IFrontServiceClient frontServiceClient);
        IViewModelSale CreateViewModelSale(User user, Seller seller, IFrontServiceClient frontServiceClient);
        IViewModelReport CreateViewModelReport(User user, IFrontServiceClient frontServiceClient);
    }
}
