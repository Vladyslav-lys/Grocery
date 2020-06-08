using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.DomainEvents;
using Grocery.BLL.Contract;
using Grocery.BLL.Entities;
using Grocery.Service.Domain;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Grocery.Service.Core
{
    public partial class MainHub
    {
        public async Task<OperationStatusInfo> ShowProducts(Department department)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetProductRequest getProductRequest = new GetProductRequest(department);

                try
                {
                    GetProductResponse getProductResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetProductRequest, GetProductResponse>>()
                        .Execute(getProductRequest);
                    operationStatusInfo.AttachedObject = getProductResponse.Products;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> ShowProductsByDate(string date)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetProductByDateRequest getProductByDateRequest = new GetProductByDateRequest(date);

                try
                {
                    GetProductByDateResponse getProductByDateResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetProductByDateRequest, GetProductByDateResponse>>()
                        .Execute(getProductByDateRequest);
                    operationStatusInfo.AttachedObject = getProductByDateResponse.Products;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> ShowArrivedGoods(Department department)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetArrivedGoodsRequest getArrivedGoodsRequest = new GetArrivedGoodsRequest(department);

                try
                {
                    GetArrivedGoodsResponse getArrivedGoodsResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetArrivedGoodsRequest, GetArrivedGoodsResponse>>()
                        .Execute(getArrivedGoodsRequest);
                    operationStatusInfo.AttachedObject = getArrivedGoodsResponse.ArrivedGoods;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> AddProductGoods(object addedProduct, object addedArrivedGoods)
        {
            return await Task.Run(() =>
            {
                Dictionary<Type, object> collection = new Dictionary<Type, object>();
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

                string attachedProductObjectText = addedProduct.ToString();
                string attachedArrivedGoodsObjectText = addedArrivedGoods.ToString();
                Product newProduct = JsonConvert.DeserializeObject<Product>(attachedProductObjectText);
                ArrivedGoods newArrivedGoods = JsonConvert.DeserializeObject<ArrivedGoods>(attachedArrivedGoodsObjectText);
                AddProductGoodsRequest addProductGoodsRequest = new AddProductGoodsRequest(newProduct.Unit, newProduct.TareChange, 
                    newArrivedGoods.Count.ToString(), newArrivedGoods.Provider, newArrivedGoods.DateTime.ToString(), newProduct.Category, 
                    newProduct.Class, newProduct.ExpirationDate.ToString(), newArrivedGoods.AllPurchasePrice.ToString(),
                    newArrivedGoods.AllSalesPrice.ToString(), newArrivedGoods.Department, newArrivedGoods.Seller, 
                    newProduct.Returned, newProduct.ReturnedDate.ToString(), newProduct.WritenOff);

                try
                {
                    AddProductGoodsResponse addProductGoodsResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<AddProductGoodsRequest, AddProductGoodsResponse>>()
                        .Execute(addProductGoodsRequest);
                    collection.Add(typeof(List<ArrivedGoods>), addProductGoodsResponse.ArrivedGoods);
                    collection.Add(typeof(List<Product>), addProductGoodsResponse.Products);
                    operationStatusInfo.AttachedObject = collection;
                    operationStatusInfo.AttachedInfo = "Product is added!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> EditProductGoods(object editedProduct, object editedArrivedGoods)
        {
            return await Task.Run(() =>
            {
                Dictionary<Type, object> collection = new Dictionary<Type, object>();
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

                string attachedProductObjectText = editedProduct.ToString();
                string attachedArrivedGoodsObjectText = editedArrivedGoods.ToString();
                Product newProduct = JsonConvert.DeserializeObject<Product>(attachedProductObjectText);
                ArrivedGoods newArrivedGoods = JsonConvert.DeserializeObject<ArrivedGoods>(attachedArrivedGoodsObjectText);
                EditProductGoodsRequest editProductGoodsRequest = new EditProductGoodsRequest(newProduct.Id, newProduct.Unit, newProduct.TareChange,
                    newArrivedGoods.Count.ToString(), newArrivedGoods.Provider, newArrivedGoods.DateTime.ToString(), newProduct.Category,
                    newProduct.Class, newProduct.ExpirationDate.ToString(), newArrivedGoods, newArrivedGoods.AllPurchasePrice.ToString(),
                    newArrivedGoods.AllSalesPrice.ToString(), newArrivedGoods.Department, newArrivedGoods.Seller,
                    newProduct.Returned, newProduct.ReturnedDate.ToString(), newProduct.WritenOff);

                try
                {
                    EditProductGoodsResponse editProductGoodsResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<EditProductGoodsRequest, EditProductGoodsResponse>>()
                        .Execute(editProductGoodsRequest);
                    collection.Add(typeof(List<ArrivedGoods>), editProductGoodsResponse.ArrivedGoods);
                    collection.Add(typeof(List<Product>), editProductGoodsResponse.Products);
                    operationStatusInfo.AttachedObject = collection;
                    operationStatusInfo.AttachedInfo = "Product is updated!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }

                return operationStatusInfo;
            });
        }
    }
}
