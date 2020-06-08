using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Grocery.Service.Domain;
using Grocery.BLL.Entities;
using Grocery.Service.Client.Contract;

namespace Grocery.Service.Client
{
    public class FrontServiceClient : IFrontServiceClient
    {
        private SystemSettings systemSettings;
        private bool isConnected;

        private SystemCategoryController systemCategoryController;
        private SystemClassController systemClassController;
        private SystemConnectionController systemConnectionController;
        private SystemDepartmentController systemDepartmentController;
        private SystemEnterController systemEnterController;
        private SystemProductGoodsController systemProductGoodsController;
        private SystemReportController systemReportController;
        private SystemSaleController systemSaleController;
        private SystemTareChangeController systemTareChangeController;
        private SystemProviderController systemProviderController;
        private SystemSellerController systemSellerController;

        public FrontServiceClient()
        {
            this.SettingConfig();
            this.ControllerConfig();
        }

        private void SettingConfig()
        {
            string serviceurl = ConfigurationManager.AppSettings["ServiceUrl"];
            string hubname = ConfigurationManager.AppSettings["Hub"];
            this.isConnected = false;

            this.systemSettings = new SystemSettings(hubname, serviceurl, null);
        }

        private void ControllerConfig()
        {
            this.systemCategoryController = new SystemCategoryController(this.systemSettings, this);
            this.systemClassController = new SystemClassController(this.systemSettings, this);
            this.systemConnectionController = new SystemConnectionController(this.systemSettings);
            this.systemDepartmentController = new SystemDepartmentController(this.systemSettings, this);
            this.systemEnterController = new SystemEnterController(this.systemSettings, this);
            this.systemProductGoodsController = new SystemProductGoodsController(this.systemSettings, this);
            this.systemProviderController = new SystemProviderController(this.systemSettings, this);
            this.systemReportController = new SystemReportController(this.systemSettings, this);
            this.systemSaleController = new SystemSaleController(this.systemSettings, this);
            this.systemTareChangeController = new SystemTareChangeController(this.systemSettings, this);
            this.systemSellerController = new SystemSellerController(this.systemSettings, this);
        }
        
        public bool IsConnected
        {
            get { return this.isConnected; }
            set { this.isConnected = value; }
        }

        public async Task ConnectAsync()
        {
            await this.systemConnectionController.ConnectAsync();
        }

        public async Task DisconnectAsync()
        {
            await this.systemConnectionController.DisconnectAsync();
        }

        public async Task<User> EnterAsync(string login, string password)
        {
            return await this.systemEnterController.EnterAsync(login, password);
        }

        public async Task<OperationStatusInfo> AddProductGoodsAsync(Product product, ArrivedGoods arrivedGoods)
        {
            return await this.systemProductGoodsController.AddProductGoodsAsync(product, arrivedGoods);
        }

        public async Task<OperationStatusInfo> AddSaleAsync(Sale sale)
        {
            return await this.systemSaleController.AddSaleAsync(sale);
        }

        public async Task<OperationStatusInfo> EditProductGoodsAsync(Product product, ArrivedGoods arrivedGoods)
        {
            return await this.systemProductGoodsController.EditProductGoodsAsync(product, arrivedGoods);
        }

        public async Task<List<ArrivedGoods>> ShowArrivedGoodsAsync(Department department)
        {
            return await this.systemProductGoodsController.ShowArrivedGoodsAsync(department);
        }

        public async Task<List<Category>> ShowCategoryAsync()
        {
            return await this.systemCategoryController.ShowCategoryAsync();
        }

        public async Task<List<Class>> ShowClassAsync()
        {
            return await this.systemClassController.ShowClassAsync();
        }

        public async Task<List<Department>> ShowDepartmentAsync()
        {
            return await this.systemDepartmentController.ShowDepartmentsAsync();
        }

        public async Task<List<Product>> ShowProductAsync(Department department)
        {
            return await this.systemProductGoodsController.ShowProductAsync(department);
        }

        public async Task<List<Product>> ShowProductByDateAsync(DateTime date)
        {
            return await this.systemProductGoodsController.ShowProductByDateAsync(date);
        }

        public async Task<List<Provider>> ShowProviderAsync()
        {
            return await this.systemProviderController.ShowProvidersAsync();
        }

        public async Task<List<ReportDetailed>> ShowReportDetailedAsync(Category category, DateTime sinceDate, DateTime toDate)
        {
            return await this.systemReportController.ShowReportDetailedAsync(category, sinceDate, toDate);
        }

        public async Task<List<ReportSimple>> ShowReportSimpleAsync(DateTime sinceDate, DateTime toDate)
        {
            return await this.systemReportController.ShowReportSimpleAsync(sinceDate,toDate);
        }

        public async Task<List<Sale>> ShowSaleAsync(Department department)
        {
            return await this.systemSaleController.ShowSaleAsync(department);
        }

        public async Task<List<Sale>> ShowSaleByClassAsync(Class class_, DateTime sinceDate, DateTime toDate)
        {
            return await this.systemSaleController.ShowSaleByClassAsync(class_,sinceDate,toDate);
        }

        public async Task<List<TareChange>> ShowTareChangeAsync()
        {
            return await this.systemTareChangeController.ShowTareChangeAsync();
        }

        public async Task<Seller> FindSellerAsync(User user)
        {
            return await this.systemSellerController.FindSellerAsync(user);
        }
    }
}
