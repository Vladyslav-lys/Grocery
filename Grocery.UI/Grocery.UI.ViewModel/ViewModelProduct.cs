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
    public class ViewModelProduct : ViewModelBase, IViewModelProduct
    {
        private IViewProduct viewProduct;

        private RelayCommand getBackCommand;
        private RelayCommand executeCommand;

        private IArrivedGoodsValidationRule arrivedGoodsValidationRule;
        private IProductValidationRule productValidationRule;
        private IMainWindowController mainWindowController;
        private IFrontServiceClient frontServiceClient;
        private int id;
        private User user;
        private ArrivedGoods arrivedGoods;
        private Product product;
        private Seller seller;
        private List<TareChange> tareChanges = new List<TareChange>();
        private List<Category> categories = new List<Category>();
        private List<Class> classes = new List<Class>();
        private List<Provider> providers = new List<Provider>();

        public ViewModelProduct() { }

        public ViewModelProduct(IArrivedGoodsValidationRule arrivedGoodsValidationRule, IProductValidationRule productValidationRule, IMainWindowController mainWindowController, IFrontServiceClient frontServiceClient, ArrivedGoods arrivedGoods, Product product, Seller seller, User user, int id)
        {
            this.validatablePropertyCollection.Add("Unit");
            this.validatablePropertyCollection.Add("Count");
            this.validatablePropertyCollection.Add("Datetime");
            this.validatablePropertyCollection.Add("ExpirationDate");
            this.validatablePropertyCollection.Add("PurchasePrice");
            this.validatablePropertyCollection.Add("SalesPrice");
            this.validatablePropertyCollection.Add("ReturnedDate");

            this.arrivedGoodsValidationRule = arrivedGoodsValidationRule;
            this.productValidationRule = productValidationRule;
            this.mainWindowController = mainWindowController;
            this.frontServiceClient = frontServiceClient;
            this.seller = seller;
            this.product = product;
            this.arrivedGoods = arrivedGoods;
            this.user = user;
            this.id = id;
        }

        private bool CanExecute => this.IsValid;

        public IViewProduct ViewProduct
        {
            get { return this.viewProduct; }
            set { this.viewProduct = value; }
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "Unit":
                    error = this.productValidationRule.ValidateUnit(this.viewProduct.UnitTxt).GetError();
                    this.viewProduct.ErrorUnit = error;
                    break;
                case "Count":
                    error = this.productValidationRule.ValidateCount(this.viewProduct.CountTxt).GetError();
                    this.viewProduct.ErrorCount = error;
                    break;
                case "Datetime":
                    error = this.arrivedGoodsValidationRule.ValidateDateTime(this.viewProduct.DatetimePick.Text).GetError();
                    this.viewProduct.ErrorDatetime = error;
                    break;
                case "ExpirationDate":
                    error = this.productValidationRule.ValidateExpirationDate(this.viewProduct.ExpirationDatePick.Text).GetError();
                    this.viewProduct.ErrorExpirationDate = error;
                    break;
                case "PurchasePrice":
                    error = this.productValidationRule.ValidatePurchasePrice(this.viewProduct.AllPurchasePriceTxt).GetError();
                    this.viewProduct.ErrorAllPurchasePrice = error;
                    break;
                case "SalesPrice":
                    error = this.productValidationRule.ValidateSalesPrice(this.viewProduct.AllSalesPriceTxt).GetError();
                    this.viewProduct.ErrorAllSalesPrice = error;
                    break;
                case "ReturnedDate":
                    if(this.viewProduct.ReturnedChecked.Value)
                    {
                        error = this.productValidationRule.ValidateReturnedDate(this.viewProduct.ReturnedDatePick.Text, this.viewProduct.ReturnedChecked.Value).GetError();
                        this.viewProduct.ErrorReturnedDate = error;
                    }
                    break;
                default:
                    this.viewProduct.ClearError(this.viewProduct.ErrorUnit);
                    this.viewProduct.ClearError(this.viewProduct.ErrorCount);
                    this.viewProduct.ClearError(this.viewProduct.ErrorDatetime);
                    this.viewProduct.ClearError(this.viewProduct.ErrorExpirationDate);
                    this.viewProduct.ClearError(this.viewProduct.ErrorReturnedDate);
                    this.viewProduct.ClearError(this.viewProduct.ErrorAllPurchasePrice);
                    this.viewProduct.ClearError(this.viewProduct.ErrorAllSalesPrice);
                    break;
            }
            this.productValidationRule.RefreshValidResult();
            this.arrivedGoodsValidationRule.RefreshValidResult();

            return error;
        }

        #region Command
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

        public bool ReturnedChecked
        {
            set
            {
                this.IsCheckedReturned(value);
            }
        }
        #endregion


        #region Action

        public void ShowProductGoods()
        {
            try
            {
                if (this.id > 0)
                {
                    if (this.product != null)
                    {
                        Provider provider = this.product.ArrivedGoods.Provider;
                        TareChange tareChange = this.product.TareChange;
                        Category category = this.product.Category;
                        Class class_ = this.product.Class;

                        this.viewProduct.UnitTxt = this.product.Unit;
                        this.viewProduct.TareChangeList.SelectedIndex = SetSelectedIndex(this.product.TareChange);
                        this.viewProduct.CountTxt = this.product.ArrivedGoods.Count.ToString();
                        this.viewProduct.ProviderList.SelectedIndex = SetSelectedIndex(this.product.ArrivedGoods.Provider);
                        this.viewProduct.DatetimePick.Text = this.product.ArrivedGoods.DateTime.ToString();
                        this.viewProduct.CategoryList.SelectedIndex = SetSelectedIndex(this.product.Category);
                        this.viewProduct.ClassList.SelectedIndex = SetSelectedIndex(this.product.Class);
                        this.viewProduct.ExpirationDatePick.Text = this.product.ExpirationDate.ToString();
                        this.viewProduct.AllPurchasePriceTxt = this.product.ArrivedGoods.AllPurchasePrice.ToString();
                        this.viewProduct.AllSalesPriceTxt = this.product.ArrivedGoods.AllSalesPrice.ToString();
                        this.viewProduct.DepartmentTxt = this.product.ArrivedGoods.Department.Number.ToString();
                        this.viewProduct.SellerTxt = this.product.ArrivedGoods.Seller.Surname;
                        this.viewProduct.ReturnedChecked = this.product.Returned;
                        this.viewProduct.ReturnedDatePick.Text = this.product.ReturnedDate.ToString();
                        this.viewProduct.WritenOffChecked = this.product.WritenOff;
                    }
                }
            }
            catch (Exception ex)
            {
                this.viewProduct.ShowError(ex.InnerException.Message);
            }
        }

        public void SetTareChanges()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.tareChanges = await this.frontServiceClient.ShowTareChangeAsync();
                });
                task.Wait();

                if (this.tareChanges.Count > 0)
                {
                    this.viewProduct.TareChangeList.ItemsSource = this.tareChanges;
                    this.viewProduct.TareChangeList.DisplayMemberPath = "Name";
                    this.viewProduct.TareChangeList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.viewProduct.ShowError(ex.InnerException.Message);
            }
        }

        public void SetCategories()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.categories = await this.frontServiceClient.ShowCategoryAsync();
                });
                task.Wait();

                if (this.categories.Count > 0)
                {
                    this.viewProduct.CategoryList.ItemsSource = this.categories;
                    this.viewProduct.CategoryList.DisplayMemberPath = "Name";
                    this.viewProduct.CategoryList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.viewProduct.ShowError(ex.InnerException.Message);
            }
        }

        public void SetClasses()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.classes = await this.frontServiceClient.ShowClassAsync();
                });
                task.Wait();

                if (this.classes.Count > 0)
                {
                    this.viewProduct.ClassList.ItemsSource = this.classes;
                    this.viewProduct.ClassList.DisplayMemberPath = "Name";
                    this.viewProduct.ClassList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.viewProduct.ShowError(ex.InnerException.Message);
            }
        }

        public void SetProviders()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.providers = await this.frontServiceClient.ShowProviderAsync();
                });
                task.Wait();

                if (this.providers.Count > 0)
                {
                    this.viewProduct.ProviderList.ItemsSource = this.providers;
                    this.viewProduct.ProviderList.DisplayMemberPath = "Name";
                    this.viewProduct.ProviderList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.viewProduct.ShowError(ex.InnerException.Message);
            }
        }

        public void SetDepartment()
        {
            this.viewProduct.DepartmentTxt = this.seller.Department.Number.ToString();
        }

        public void SetSeller()
        {
            this.viewProduct.SellerTxt = this.seller.Surname;
        }

        public void Execute()
        {
            if(this.id > 0)
            {
                EditProduct();
                return;
            }

            AddProduct();
        }

        public void GetBack()
        {
            this.mainWindowController.LoadMain(user, frontServiceClient);
        }

        public void IsCheckedReturned(bool isChecked)
        {
            switch(isChecked)
            {
                case true:
                    this.viewProduct.ReturnedDatePick.IsEnabled = true;
                    break;
                case false:
                    this.viewProduct.ErrorReturnedDate = "";
                    this.viewProduct.ReturnedDatePick.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void AddProduct()
        {
            try
            {
                OperationStatusInfo operationStatusInfo = null;
                
                string unit = this.viewProduct.UnitTxt;
                TareChange tareChange = (TareChange) this.viewProduct.TareChangeList.SelectedItem;
                int count = int.Parse(this.viewProduct.CountTxt);
                Provider provider = (Provider)this.viewProduct.ProviderList.SelectedItem;
                DateTime dateTime = this.viewProduct.DatetimePick.SelectedDate.Value;
                Category category = (Category)this.viewProduct.CategoryList.SelectedItem;
                Class class_ = (Class)this.viewProduct.ClassList.SelectedItem;
                DateTime expirationDate = this.viewProduct.ExpirationDatePick.SelectedDate.Value;
                float allPurchasePrice = float.Parse(this.viewProduct.AllPurchasePriceTxt);
                float allSalesPrice = float.Parse(this.viewProduct.AllSalesPriceTxt);
                Department department = this.seller.Department;
                Seller seller = this.seller;
                bool returned = this.viewProduct.ReturnedChecked.Value;
                DateTime? returnedDate = this.viewProduct.ReturnedDatePick.SelectedDate;
                bool writenOff = this.viewProduct.WritenOffChecked.Value;

                Task task = Task.Run(async () =>
                {
                    ArrivedGoods arrivedGoods = new ArrivedGoods
                    {
                        Provider = provider,
                        Count = count,
                        DateTime = dateTime,
                        AllPurchasePrice = allPurchasePrice,
                        AllSalesPrice = allSalesPrice,
                        Department = department,
                        Seller = seller
                    };

                    Product product = new Product
                    {
                        Unit = unit,
                        TareChange = tareChange,
                        Class = class_,
                        Category = category,
                        Count = count,
                        ExpirationDate = expirationDate,
                        ArrivedGoods = arrivedGoods,
                        PurchasePrice = 0.0f,
                        SalesPrice = 0.0f,
                        Returned = returned,
                        ReturnedDate = returnedDate,
                        WritenOff = writenOff
                    };

                    operationStatusInfo = await this.frontServiceClient.AddProductGoodsAsync(product, arrivedGoods);
                });
                task.Wait();

                if (operationStatusInfo != null)
                {
                    this.viewProduct.ShowMsh(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                this.viewProduct.ShowError(ex.InnerException.Message);
            }
        }

        private void EditProduct()
        {
            try
            {
                OperationStatusInfo operationStatusInfo = null;

                string unit = this.viewProduct.UnitTxt;
                TareChange tareChange = (TareChange)this.viewProduct.TareChangeList.SelectedItem;
                int count = int.Parse(this.viewProduct.CountTxt);
                Provider provider = (Provider)this.viewProduct.ProviderList.SelectedItem;
                DateTime dateTime = this.viewProduct.DatetimePick.SelectedDate.Value;
                Category category = (Category)this.viewProduct.CategoryList.SelectedItem;
                Class class_ = (Class)this.viewProduct.ClassList.SelectedItem;
                DateTime expirationDate = this.viewProduct.ExpirationDatePick.SelectedDate.Value;
                float allPurchasePrice = float.Parse(this.viewProduct.AllPurchasePriceTxt);
                float allSalesPrice = float.Parse(this.viewProduct.AllSalesPriceTxt);
                Department department = this.seller.Department;
                Seller seller = this.seller;
                bool returned = this.viewProduct.ReturnedChecked.Value;
                DateTime? returnedDate = this.viewProduct.ReturnedDatePick.SelectedDate;
                bool writenOff = this.viewProduct.WritenOffChecked.Value;

                Task task = Task.Run(async () =>
                {
                    ArrivedGoods arrivedGoods = new ArrivedGoods
                    {
                        Id = this.arrivedGoods.Id,
                        Provider = provider,
                        Count = count,
                        DateTime = dateTime,
                        AllPurchasePrice = allPurchasePrice,
                        AllSalesPrice = allSalesPrice,
                        Department = department,
                        Seller = seller
                    };

                    Product product = new Product
                    {
                        Id = this.product.Id,
                        Unit = unit,
                        TareChange = tareChange,
                        Class = class_,
                        Category = category,
                        Count = count,
                        ExpirationDate = expirationDate,
                        ArrivedGoods = arrivedGoods,
                        PurchasePrice = 0.0f,
                        SalesPrice = 0.0f,
                        Returned = returned,
                        ReturnedDate = returnedDate,
                        WritenOff = writenOff
                    };

                    operationStatusInfo = await this.frontServiceClient.EditProductGoodsAsync(product, arrivedGoods);
                });
                task.Wait();

                if (operationStatusInfo != null)
                {
                    this.viewProduct.ShowMsh(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                this.viewProduct.ShowError(ex.InnerException.Message);
            }
        }

        private int SetSelectedIndex(object obj)
        {
            int i = 0;

            if(obj is TareChange)
            {
                int j = 0;
                foreach (TareChange tareChange in this.viewProduct.TareChangeList.ItemsSource)
                {
                    if(tareChange.Id == this.product.TareChange.Id)
                    {
                        i = j;
                    }
                    j++;
                }
            }
            else if (obj is Provider)
            {
                int j = 0;
                foreach (Provider provider in this.viewProduct.ProviderList.ItemsSource)
                {
                    if (provider.Id == this.product.ArrivedGoods.Provider.Id)
                    {
                        i = j;
                    }
                    j++;
                }
            }
            else if (obj is Class)
            {
                int j = 0;
                foreach (Class class_ in this.viewProduct.ClassList.ItemsSource)
                {
                    if (class_.Id == this.product.Class.Id)
                    {
                        i = j;
                    }
                    j++;
                }
            }
            else if (obj is Category)
            {
                int j = 0;
                foreach (Category category in this.viewProduct.CategoryList.ItemsSource)
                {
                    if (category.Id == this.product.Category.Id)
                    {
                        i = j;
                    }
                    j++;
                }
            }

            return i;
        }
        #endregion
    }
}
