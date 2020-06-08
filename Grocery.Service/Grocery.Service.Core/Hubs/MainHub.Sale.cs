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
        public async Task<OperationStatusInfo> ShowSales(Department department)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetSaleRequest getSaleRequest = new GetSaleRequest(department);

                try
                {
                    GetSaleResponse getSaleResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetSaleRequest, GetSaleResponse>>()
                        .Execute(getSaleRequest);
                    operationStatusInfo.AttachedObject = getSaleResponse.Sales;
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

        public async Task<OperationStatusInfo> ShowSalesByClass(Class class_, DateTime sinceDate, DateTime toDate)
        {
            return await Task.Run(() =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                GetSaleByClassRequest getSaleByClassRequest = new GetSaleByClassRequest(class_, sinceDate.ToString(), toDate.ToString());

                try
                {
                    GetSaleByClassResponse getSaleByClassResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<GetSaleByClassRequest, GetSaleByClassResponse>>()
                        .Execute(getSaleByClassRequest);
                    operationStatusInfo.AttachedObject = getSaleByClassResponse.Sales;
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

        public async Task<OperationStatusInfo> AddSales(object addedSale)
        {
            return await Task.Run(() =>
            {
                Dictionary<Type, object> collection = new Dictionary<Type, object>();
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);

                string attachedSaleObjectText = addedSale.ToString();
                Sale newSale = JsonConvert.DeserializeObject<Sale>(attachedSaleObjectText);
                AddSaleRequest addSaleRequest = new AddSaleRequest(newSale.Product, newSale.Count.ToString(), 
                    newSale.Datetime.ToString(), newSale.Price.ToString(), newSale.Seller);

                try
                {
                    AddSaleResponse addSaleResponse = hubEnvironment.UseCaseFactory
                        .Create<IUseCase<AddSaleRequest, AddSaleResponse>>()
                        .Execute(addSaleRequest);
                    collection.Add(typeof(List<Sale>), addSaleResponse.Sales);
                    collection.Add(typeof(List<Product>), addSaleResponse.Products);
                    operationStatusInfo.AttachedObject = collection;
                    operationStatusInfo.AttachedInfo = "Sale is added!";
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
