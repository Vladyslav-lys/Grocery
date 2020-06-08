using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Grocery.UI.Contract;
using Grocery.BLL.Entities;
using Grocery.UI.Utility;
using Grocery.BLL.Contract;
using Grocery.BLL.Rules;
using Grocery.Service.Client.Contract;
using System.Windows.Input;

namespace Grocery.UI.ViewModel
{
    public class ViewModelMain : ViewModelBase, IViewModelMain
    {
        private IViewMain viewMain;

        private RelayCommand editProductCommand;
        private RelayCommand addProductCommand;

        private RelayCommand createReportCommand;
        private RelayCommand openFindCommand;
        private RelayCommand findElementsCommand;
        private RelayCommand getAllBackCommand;
        private RelayCommand addSaleCommand;

        private IProductByDateValidationRule productByDateValidationRule;
        private ISaleByDateValidationRule saleByDateValidationRule;
        private IMainWindowController mainWindowController;
        private IFrontServiceClient frontServiceClient;
        private User user;
        private Seller seller = null;
        private List<Product> products = new List<Product>();
        private List<ArrivedGoods> arrivedGoods = new List<ArrivedGoods>();
        private List<Sale> sales = new List<Sale>();
        private List<Class> classes = new List<Class>();

        public ViewModelMain() { }

        public ViewModelMain(IProductByDateValidationRule productByDateValidationRule, ISaleByDateValidationRule saleByDateValidationRule, IMainWindowController mainWindowController, IFrontServiceClient frontServiceClient, User user)
        {
            this.validatablePropertyCollection.Add("SinceDate");
            this.validatablePropertyCollection.Add("ToDate");

            this.productByDateValidationRule = productByDateValidationRule;
            this.saleByDateValidationRule = saleByDateValidationRule;
            this.mainWindowController = mainWindowController;
            this.frontServiceClient = frontServiceClient;
            this.user = user;
        }

        private bool CanExecute => this.IsValid;
        private bool CanClick => this.EnableToClick;

        public IViewMain ViewMain
        {
            get { return this.viewMain; }
            set { this.viewMain = value; }
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "SinceDate":
                    if (this.viewMain.SinceDate.IsEnabled)
                    {
                        error = this.saleByDateValidationRule.ValidateSinceDate(this.viewMain.SinceDate.Text).GetError();
                        this.viewMain.ErrorSinceDate = error;
                    }
                    break;
                case "ToDate":
                    if (this.viewMain.ToDate.IsEnabled)
                    {
                        error = this.saleByDateValidationRule.ValidateToDate(this.viewMain.ToDate.Text).GetError();
                        this.viewMain.ErrorToDate = error;
                    }
                    break;
                default:
                    this.viewMain.ClearError(this.viewMain.ErrorSinceDate);
                    this.viewMain.ClearError(this.viewMain.ErrorToDate);
                    break;
            }
            this.saleByDateValidationRule.RefreshValidResult();

            return error;
        }

        #region Commands
        public ICommand OpenFindCommand
        {
            get
            {
                if (this.openFindCommand== null)
                {
                    this.openFindCommand = new RelayCommand(() => this.OpenFind(), param => true);
                }
                return this.openFindCommand;
            }
        }

        public ICommand FindElementsCommand
        {
            get
            {
                if (this.findElementsCommand == null)
                {
                    this.findElementsCommand = new RelayCommand(() => this.FindElements(), param => this.CanExecute);
                }
                return this.findElementsCommand;
            }
        }

        public ICommand GetAllBackCommand
        {
            get
            {
                if (this.getAllBackCommand == null)
                {
                    this.getAllBackCommand = new RelayCommand(() => this.GetAllBack(), param => true);
                }
                return this.getAllBackCommand;
            }
        }

        public ICommand AddSaleCommand
        {
            get
            {
                if (this.addSaleCommand == null)
                {
                    this.addSaleCommand = new RelayCommand(() => this.AddSale(), param => true);
                }
                return this.addSaleCommand;
            }
        }

        public ICommand AddProductGoodsCommand
        {
            get
            {
                if (this.addProductCommand == null)
                {
                    this.addProductCommand = new RelayCommand(() => this.AddProductGoods(), param => true);
                }
                return this.addProductCommand;
            }
        }

        public ICommand EditProductGoodsCommand
        {
            get
            {
                if (this.editProductCommand == null)
                {
                    this.editProductCommand = new RelayCommand(() => this.EditProductGoods(), param => this.CanClick);
                }
                return this.editProductCommand;
            }
        }

        public ICommand CreateReportCommand
        {
            get
            {
                if (this.createReportCommand == null)
                {
                    this.createReportCommand = new RelayCommand(() => this.CreateReport(), param => true);
                }
                return this.createReportCommand;
            }
        }

        public int ChangeTableIndex
        {
            set
            {
                this.ChangeTable(value);
            }
        }

        public int EnableByIndex
        {
            set
            {
                this.EnableElement(value);
            }
        }

        public bool EnableToClick
        {
            get
            {
                if(this.viewMain.ListProducts.SelectedIndex.Equals(-1) || this.viewMain.ListProducts.SelectedItems.Count > 1)
                {
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Actions
        public void SetSeller()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.seller = await this.frontServiceClient.FindSellerAsync(this.user);
                });
                task.Wait();
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
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

                if(this.classes.Count > 0)
                {
                    this.viewMain.ClassList.ItemsSource = this.classes;
                    this.viewMain.ClassList.DisplayMemberPath = "Name";
                    this.viewMain.ClassList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        public void ShowProducts()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.products = await this.frontServiceClient.ShowProductAsync(this.seller.Department);
                });
                task.Wait();

                if (this.products.Count > 0)
                {
                    this.viewMain.ListProducts.ItemsSource = products;
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        public void ShowArrivedGoods()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.arrivedGoods = await this.frontServiceClient.ShowArrivedGoodsAsync(this.seller.Department);
                });
                task.Wait();

                if (this.arrivedGoods.Count > 0)
                {
                    this.viewMain.ListArrivedGoods.ItemsSource = arrivedGoods;
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        public void ShowSales()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.sales = await this.frontServiceClient.ShowSaleAsync(this.seller.Department);
                });
                task.Wait();

                if (this.sales.Count > 0)
                {
                    this.viewMain.ListSales.ItemsSource = sales;
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }


        public void OpenFind()
        {
            if(this.viewMain.FindVisibility == Visibility.Hidden)
            {
                this.viewMain.FindVisibility = Visibility.Visible;
                return;
            }
            this.viewMain.FindVisibility = Visibility.Hidden;
        }

        public void FindElements()
        {
            switch (this.viewMain.FindList.SelectedIndex)
            {
                case 0:
                    FindProductByDate();
                    break;
                case 1:
                    FindSaleByClass();
                    break;
                default:
                    break;
            }

            this.viewMain.GetBackBtn.IsEnabled = true;
        }

        public void GetAllBack()
        {
            this.ShowSales();
            this.ShowProducts();

            this.viewMain.GetBackBtn.IsEnabled = false;
        }
        
        public void EditProductGoods()
        {
            try
            {
                Product product = (Product)this.viewMain.ListProducts.SelectedItem;
                this.mainWindowController.LoadProduct(product.Id, user, product.ArrivedGoods, product, seller, frontServiceClient);
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.Message);
            }
        }

        public void AddProductGoods()
        {
            this.mainWindowController.LoadProduct(0, user, null, null, seller, frontServiceClient);
        }

        public void CreateReport()
        {
            this.mainWindowController.LoadReport(user, frontServiceClient);
        }

        public void AddSale()
        {
            this.mainWindowController.LoadSale(user, seller, frontServiceClient);
        }

        private void FindProductByDate()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.products = await this.frontServiceClient.ShowProductByDateAsync(DateTime.Now);
                });
                task.Wait();

                if (task.IsCompleted)
                {
                    this.viewMain.ListProducts.ItemsSource = this.products;

                    this.viewMain.TableList.SelectedIndex = 0;
                    ChangeTable(0);
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        private void FindSaleByClass()
        {
            try
            {
                DateTime sinceDate = this.viewMain.SinceDate.SelectedDate.Value;
                DateTime toDate = this.viewMain.ToDate.SelectedDate.Value;
                Class class_ = (Class)this.viewMain.ClassList.SelectedItem;

                Task task = Task.Run(async () =>
                {
                    this.sales = await this.frontServiceClient.ShowSaleByClassAsync(class_, sinceDate, toDate);
                });
                task.Wait();

                if (task.IsCompleted)
                {
                    this.viewMain.ListSales.ItemsSource = this.sales;

                    this.viewMain.TableList.SelectedIndex = 1;
                    ChangeTable(1);
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        public void ChangeTable(int selectedIndex)
        {
            switch(selectedIndex)
            {
                case 0:
                    this.viewMain.ListProductVisibility = Visibility.Visible;
                    this.viewMain.ListArrivedGoodsVisibility = Visibility.Hidden;
                    this.viewMain.ListSalesVisibility = Visibility.Hidden;
                    break;
                case 1:
                    this.viewMain.ListProductVisibility = Visibility.Hidden;
                    this.viewMain.ListArrivedGoodsVisibility = Visibility.Hidden;
                    this.viewMain.ListSalesVisibility = Visibility.Visible;
                    break;
                case 2:
                    this.viewMain.ListProductVisibility = Visibility.Hidden;
                    this.viewMain.ListArrivedGoodsVisibility = Visibility.Visible;
                    this.viewMain.ListSalesVisibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        public void EnableElement(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    this.viewMain.ErrorSinceDate = "";
                    this.viewMain.ErrorToDate = "";
                    this.viewMain.SettingFindGridEnabled = false;
                    break;
                case 1:
                    this.viewMain.SettingFindGridEnabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

//public ICommand ShowProductsCommand
//{
//    get
//    {
//        if (this.showProductsCommand == null)
//        {
//            this.showProductsCommand = new RelayCommand(() => this.ShowProducts(), param => true);
//        }
//        return this.showProductsCommand;
//    }
//}

//public ICommand ShowArrivedGoodsCommand
//{
//    get
//    {
//        if (this.showArrivedGoodsCommand == null)
//        {
//            this.showArrivedGoodsCommand = new RelayCommand(() => this.ShowArrivedGoods(), param => true);
//        }
//        return this.showArrivedGoodsCommand;
//    }
//}

//public ICommand ShowSalesCommand
//{
//    get
//    {
//        if (this.showSalesCommand == null)
//        {
//            this.showSalesCommand = new RelayCommand(() => this.ShowSales(), param => true);
//        }
//        return this.showSalesCommand;
//    }
//}

//protected override string GetValidationError(string property)
//{
//    string error = null;

//    switch (property)
//    {
//        case "SinceDateReport":
//            error = this.reportValidationRule.ValidateSinceDate(this.viewMain.).GetError();
//            this.viewMain.ErrorSinceDateReport = error;
//            break;
//        case "ToDateReport":
//            error = this.reportValidationRule.ValidateToDate(this.viewMain.).GetError();
//            this.viewMain.ErrorToDateReport = error;
//            break;
//        case "SinceDateSale":
//            error = this.saleByDateValidationRule.ValidateSinceDate(this.viewMain.).GetError();
//            this.viewMain.ErrorSinceDateSale = error;
//            break;
//        case "ToDateSale":
//            error = this.saleByDateValidationRule.ValidateToDate(this.viewMain.).GetError();
//            this.viewMain.ErrorToDateSale = error;
//            break;
//        case "DateProduct":
//            error = this.productByDateValidationRule.ValidateDate(this.viewMain.).GetError();
//            this.viewMain.ErrorDateProduct = error;
//            break;
//        default:
//            this.viewMain.ClearError(this.viewMain.ErrorSinceDateReport);
//            this.viewMain.ClearError(this.viewMain.ErrorToDateReport);
//            this.viewMain.ClearError(this.viewMain.ErrorSinceDateSale);
//            this.viewMain.ClearError(this.viewMain.ErrorToDateSale);
//            this.viewMain.ClearError(this.viewMain.ErrorDateProduct);
//            break;
//    }
//    this.reportValidationRule.RefreshValidResult();
//    this.saleByDateValidationRule.RefreshValidResult();
//    this.productByDateValidationRule.RefreshValidResult();

//    return error;
//}

//this.validatablePropertyCollection.Add("SinceDateReport");
//        this.validatablePropertyCollection.Add("ToDateReport");
//        this.validatablePropertyCollection.Add("SinceDateSale");
//        this.validatablePropertyCollection.Add("ToDateSale");
//        this.validatablePropertyCollection.Add("SinceDateReport");
//        this.validatablePropertyCollection.Add("ToDateReport");
//        this.validatablePropertyCollection.Add("DateProduct");

//this.reportValidationRule = reportValidationRule;
//        this.saleByDateValidationRule = saleByDateValidationRule;
//        this.productByDateValidationRule = productByDateValidationRule;