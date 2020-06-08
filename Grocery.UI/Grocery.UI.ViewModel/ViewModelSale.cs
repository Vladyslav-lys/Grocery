using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.UI.Contract;
using Grocery.BLL.Entities;
using Grocery.UI.Utility;
using Grocery.BLL.Contract;
using Grocery.BLL.Rules;
using Grocery.Service.Client.Contract;
using System.Windows.Input;
using Grocery.Service.Domain;

namespace Grocery.UI.ViewModel
{
    public class ViewModelSale : ViewModelBase, IViewModelSale
    {
        private IViewSale viewSale;

        private RelayCommand getBackCommand;
        private RelayCommand executeCommand;

        private ISaleValidationRule saleValidationRule;
        private IProductValidationRule productValidationRule;
        private IMainWindowController mainWindowController;
        private IFrontServiceClient frontServiceClient;
        private User user;
        private Seller seller;
        private List<Product> products = new List<Product>();

        public ViewModelSale() { }

        public ViewModelSale(ISaleValidationRule saleValidationRule, IProductValidationRule productValidationRule, IMainWindowController mainWindowController, IFrontServiceClient frontServiceClient, Seller seller, User user)
        {
            this.validatablePropertyCollection.Add("Product");
            this.validatablePropertyCollection.Add("Count");
            this.validatablePropertyCollection.Add("Datetime");

            this.saleValidationRule = saleValidationRule;
            this.productValidationRule = productValidationRule;
            this.mainWindowController = mainWindowController;
            this.frontServiceClient = frontServiceClient;
            this.seller = seller;
            this.user = user;
        }

        private bool CanExecute => this.IsValid;

        public IViewSale ViewSale
        {
            get { return this.viewSale; }
            set { this.viewSale = value; }
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "Product":
                    error = this.saleValidationRule.ValidateProduct((Product)this.viewSale.ProductList.SelectedItem).GetError();
                    this.viewSale.ErrorProduct = error;
                    break;
                case "Count":
                    error = this.saleValidationRule.ValidateCount(this.viewSale.CountTxt).GetError();
                    this.viewSale.ErrorCount = error;
                    break;
                case "Datetime":
                    error = this.saleValidationRule.ValidateDatetime(this.viewSale.DatetimePick.Text).GetError();
                    this.viewSale.ErrorDatetime = error;
                    break;
                default:
                    this.viewSale.ClearError(this.viewSale.ErrorProduct);
                    this.viewSale.ClearError(this.viewSale.ErrorCount);
                    this.viewSale.ClearError(this.viewSale.ErrorDatetime);
                    break;
            }
            this.productValidationRule.RefreshValidResult();
            this.saleValidationRule.RefreshValidResult();

            return error;
        }

        #region Commands
        public ICommand GetBackCommand
        {
            get
            {
                if (this.getBackCommand == null)
                {
                    this.getBackCommand = new RelayCommand(() => this.GetBack(), param => true);
                }
                return this.getBackCommand;
            }
        }

        public ICommand ExecuteCommand
        {
            get
            {
                if (this.executeCommand == null)
                {
                    this.executeCommand = new RelayCommand(() => this.Execute(), param => this.CanExecute);
                }
                return this.executeCommand;
            }
        }

        public string SetPrice
        {
            set
            {
                Product product = (Product)this.viewSale.ProductList.SelectedItem;

                if (this.viewSale.CountTxt != "" && int.Parse(this.viewSale.CountTxt) > 0)
                {
                    this.viewSale.PriceTxt = (int.Parse(this.viewSale.CountTxt) * product.SalesPrice).ToString();
                    return;
                }
                this.viewSale.PriceTxt = "";
            }
        }
        #endregion


        #region Action

        public void SetProducts()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.products = await this.frontServiceClient.ShowProductAsync(seller.Department);
                });
                task.Wait();

                if (this.products.Count > 0)
                {
                    this.viewSale.ProductList.ItemsSource = this.products;
                    this.viewSale.ProductList.DisplayMemberPath = "Unit";
                    this.viewSale.ProductList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.viewSale.ShowError(ex.InnerException.Message);
            }
        }

        public void SetSeller()
        {
            this.viewSale.SellerTxt = this.seller.Surname;
        }

        public void Execute()
        {
            try
            {
                OperationStatusInfo operationStatusInfo = null;

                Product product = (Product)this.viewSale.ProductList.SelectedItem;
                int count = int.Parse(this.viewSale.CountTxt);
                DateTime dateTime = this.viewSale.DatetimePick.SelectedDate.Value;
                float price = float.Parse(this.viewSale.PriceTxt);
                Seller seller = this.seller;

                Task task = Task.Run(async () =>
                {
                    Sale sale = new Sale
                    {
                        Product = product,
                        Count = count,
                        Datetime = dateTime,
                        Price = price,
                        Seller = seller
                    };

                    operationStatusInfo = await this.frontServiceClient.AddSaleAsync(sale);
                });
                task.Wait();

                if (operationStatusInfo != null)
                {
                    this.viewSale.ShowMsh(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                this.viewSale.ShowError(ex.InnerException.Message);
            }
        }

        public void GetBack()
        {
            this.mainWindowController.LoadMain(user, frontServiceClient);
        }
        #endregion
    }
}
