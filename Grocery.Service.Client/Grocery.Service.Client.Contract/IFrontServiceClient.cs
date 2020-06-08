using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.BLL.Entities;
using Grocery.Service.Domain;

namespace Grocery.Service.Client.Contract
{
    public interface IFrontServiceClient
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        bool IsConnected { get; set; }

        Task<List<ArrivedGoods>> ShowArrivedGoodsAsync(Department department);

        Task<List<Category>> ShowCategoryAsync();

        Task<List<Class>> ShowClassAsync();

        Task<List<Department>> ShowDepartmentAsync();

        Task<List<Product>> ShowProductAsync(Department department);
        Task<List<Product>> ShowProductByDateAsync(DateTime date);
        Task<OperationStatusInfo> EditProductGoodsAsync(Product product, ArrivedGoods arrivedGoods);
        Task<OperationStatusInfo> AddProductGoodsAsync(Product product, ArrivedGoods arrivedGoods);

        Task<List<Provider>> ShowProviderAsync();

        Task<List<ReportDetailed>> ShowReportDetailedAsync(Category category, DateTime sinceDate, DateTime toDate);
        Task<List<ReportSimple>> ShowReportSimpleAsync(DateTime sinceDate, DateTime toDate);

        Task<List<Sale>> ShowSaleAsync(Department department);
        Task<List<Sale>> ShowSaleByClassAsync(Class class_, DateTime sinceDate, DateTime toDate);
        Task<OperationStatusInfo> AddSaleAsync(Sale sale);

        Task<List<TareChange>> ShowTareChangeAsync();

        Task<User> EnterAsync(string login, string password);

        Task<Seller> FindSellerAsync(User user);
    }
}
