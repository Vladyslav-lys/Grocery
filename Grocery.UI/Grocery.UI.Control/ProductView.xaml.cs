using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grocery.UI.Contract;

namespace Grocery.UI.Control
{
    /// <summary>
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl, IViewProduct
    {
        public ProductView(IViewModelProduct viewModelProduct)
        {
            viewModelProduct.ViewProduct = this;
            InitializeComponent();
            this.DataContext = viewModelProduct;
            viewModelProduct.SetTareChanges();
            viewModelProduct.SetCategories();
            viewModelProduct.SetClasses();
            viewModelProduct.SetProviders();
            viewModelProduct.SetDepartment();
            viewModelProduct.SetSeller();
            viewModelProduct.ShowProductGoods();
        }

        public string ErrorUnit
        {
            get { return this.Dispatcher.Invoke(() => this.errorUnit.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorUnit.Content = value); }
        }

        public string ErrorCount
        {
            get { return this.Dispatcher.Invoke(() => this.errorCount.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorCount.Content = value); }
        }

        public string ErrorDatetime
        {
            get { return this.Dispatcher.Invoke(() => this.errorDatetime.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorDatetime.Content = value); }
        }

        public string ErrorExpirationDate
        {
            get { return this.Dispatcher.Invoke(() => this.errorExpirationDate.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorExpirationDate.Content = value); }
        }

        public string ErrorAllPurchasePrice
        {
            get { return this.Dispatcher.Invoke(() => this.errorAllPurchasePrice.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorAllPurchasePrice.Content = value); }
        }

        public string ErrorAllSalesPrice
        {
            get { return this.Dispatcher.Invoke(() => this.errorAllSalesPrice.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorAllSalesPrice.Content = value); }
        }

        public string ErrorReturnedDate
        {
            get { return this.Dispatcher.Invoke(() => this.errorReturnedDate.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorReturnedDate.Content = value); }
        }

        public ComboBox TareChangeList
        {
            get { return this.Dispatcher.Invoke(() => this.listTareChange); }
            set { this.Dispatcher.Invoke(() => this.listTareChange = value); }
        }

        public ComboBox ProviderList
        {
            get { return this.Dispatcher.Invoke(() => this.listProvider); }
            set { this.Dispatcher.Invoke(() => this.listProvider = value); }
        }

        public ComboBox CategoryList
        {
            get { return this.Dispatcher.Invoke(() => this.listCategory); }
            set { this.Dispatcher.Invoke(() => this.listCategory = value); }
        }

        public ComboBox ClassList
        {
            get { return this.Dispatcher.Invoke(() => this.listClass); }
            set { this.Dispatcher.Invoke(() => this.listClass = value); }
        }

        public string UnitTxt
        {
            get { return this.Dispatcher.Invoke(() => this.unitTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.unitTxt.Text = value); }
        }

        public string CountTxt
        {
            get { return this.Dispatcher.Invoke(() => this.countTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.countTxt.Text = value); }
        }

        public string AllPurchasePriceTxt
        {
            get { return this.Dispatcher.Invoke(() => this.allPurchasePriceTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.allPurchasePriceTxt.Text = value); }
        }

        public string AllSalesPriceTxt
        {
            get { return this.Dispatcher.Invoke(() => this.allSalesPriceTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.allSalesPriceTxt.Text = value); }
        }

        public string DepartmentTxt
        {
            get { return this.Dispatcher.Invoke(() => this.departmentTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.departmentTxt.Text = value); }
        }

        public string SellerTxt
        {
            get { return this.Dispatcher.Invoke(() => this.sellerTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.sellerTxt.Text = value); }
        }

        public DatePicker DatetimePick
        {
            get { return this.Dispatcher.Invoke(() => this.datetimePick); }
            set { this.Dispatcher.Invoke(() => this.datetimePick = value); }
        }

        public DatePicker ExpirationDatePick
        {
            get { return this.Dispatcher.Invoke(() => this.expirationDatePick); }
            set { this.Dispatcher.Invoke(() => this.expirationDatePick = value); }
        }

        public DatePicker ReturnedDatePick
        {
            get { return this.Dispatcher.Invoke(() => this.returnedDatePick); }
            set { this.Dispatcher.Invoke(() => this.returnedDatePick = value); }
        }

        public bool? ReturnedChecked
        {
            get { return this.Dispatcher.Invoke(() => this.checkReturned.IsChecked); }
            set { this.Dispatcher.Invoke(() => this.checkReturned.IsChecked = value); }
        }

        public bool? WritenOffChecked
        {
            get { return this.Dispatcher.Invoke(() => this.checkWritenOff.IsChecked); }
            set { this.Dispatcher.Invoke(() => this.checkWritenOff.IsChecked = value); }
        }

        public void ShowError(string error)
        {
            this.Dispatcher.Invoke(() => MessageBox.Show(error, "Error!", MessageBoxButton.OK, MessageBoxImage.Error));
        }

        public void ShowMsh(string msg)
        {
            this.Dispatcher.Invoke(() => MessageBox.Show(msg, "Info!", MessageBoxButton.OK, MessageBoxImage.Information));
        }

        public void ClearError(string error)
        {
            this.Dispatcher.Invoke(() => error = "");
        }
    }
}
