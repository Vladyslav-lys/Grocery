using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.BLL.Entities;
using Grocery.Service.Client.Contract;
using Grocery.Service.Domain;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace Grocery.Service.Client
{
    class SystemProductGoodsController
    {
        private SystemSettings systemSettings;
        private IFrontServiceClient frontServiceClient;
        
        public SystemProductGoodsController(SystemSettings systemSettings, IFrontServiceClient frontServiceClient)
        {
            this.systemSettings = systemSettings;
            this.frontServiceClient = frontServiceClient;
        }

        public async Task<List<Product>> ShowProductAsync(Department department)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowProducts", department);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(attachedObjectText);

                    return products;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                frontServiceClient.IsConnected = false;
                throw new Exception("Showing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Showing is not executed. Reason: " + ex.Message, ex);
            }
        }

        public async Task<List<Product>> ShowProductByDateAsync(DateTime date)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowProductsByDate", date);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(attachedObjectText);

                    return products;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                frontServiceClient.IsConnected = false;
                throw new Exception("Showing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Showing is not executed. Reason: " + ex.Message, ex);
            }
        }

        public async Task<List<ArrivedGoods>> ShowArrivedGoodsAsync(Department department)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("ShowArrivedGoods", department);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText = operationStatusInfo.AttachedObject.ToString();
                    List<ArrivedGoods> arrivedGoods = JsonConvert.DeserializeObject<List<ArrivedGoods>>(attachedObjectText);

                    return arrivedGoods;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                frontServiceClient.IsConnected = false;
                throw new Exception("Showing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Showing is not executed. Reason: " + ex.Message, ex);
            }
        }

        public async Task<OperationStatusInfo> AddProductGoodsAsync(Product product, ArrivedGoods arrivedGoods)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("AddProductGoods", product, arrivedGoods);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return operationStatusInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Adding is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Adding is not executed. Reason:" + ex.Message, ex);
            }
        }

        public async Task<OperationStatusInfo> EditProductGoodsAsync(Product product, ArrivedGoods arrivedGoods)
        {
            try
            {
                OperationStatusInfo operationStatusInfo = await this.systemSettings.Connection.InvokeAsync<OperationStatusInfo>("EditProductGoods", product, arrivedGoods);

                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return operationStatusInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Editing is not executed. Reason: Connection to server is absent now. Please, reconnect later", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Editing is not executed. Reason:" + ex.Message, ex);
            }
        }
    }
}
