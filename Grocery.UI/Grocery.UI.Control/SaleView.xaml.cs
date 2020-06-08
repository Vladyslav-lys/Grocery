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
    /// Логика взаимодействия для SaleView.xaml
    /// </summary>
    public partial class SaleView : UserControl, IViewSale
    {
        public SaleView(IViewModelSale viewModelSale)
        {
            viewModelSale.ViewSale = this;
            InitializeComponent();
            this.DataContext = viewModelSale;
            viewModelSale.SetProducts();
            viewModelSale.SetSeller();

            this.DatetimePick.DisplayDate = DateTime.Now;
        }

        public string ErrorProduct
        {
            get { return this.Dispatcher.Invoke(() => this.errorProduct.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.errorProduct.Content = value); }
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

        public ComboBox ProductList
        {
            get { return this.Dispatcher.Invoke(() => this.listProduct); }
            set { this.Dispatcher.Invoke(() => this.listProduct = value); }
        }

        public string CountTxt
        {
            get { return this.Dispatcher.Invoke(() => this.countTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.countTxt.Text = value); }
        }

        public string PriceTxt
        {
            get { return this.Dispatcher.Invoke(() => this.priceTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.priceTxt.Text = value); }
        }

        public DatePicker DatetimePick
        {
            get { return this.Dispatcher.Invoke(() => this.datetimePick); }
            set { this.Dispatcher.Invoke(() => this.datetimePick = value); }
        }

        public string SellerTxt
        {
            get { return this.Dispatcher.Invoke(() => this.sellerTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.sellerTxt.Text = value); }
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
