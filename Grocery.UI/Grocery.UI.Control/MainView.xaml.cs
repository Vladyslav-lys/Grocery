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
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IViewMain
    {
        public MainView(IViewModelMain viewModelMain)
        {
            viewModelMain.ViewMain = this;
            InitializeComponent();
            this.DataContext = viewModelMain;
            viewModelMain.SetSeller();
            viewModelMain.ShowProducts();
            viewModelMain.ShowArrivedGoods();
            viewModelMain.ShowSales();
            viewModelMain.SetClasses();

            SettingFindGridEnabled = false;
        }

        public DatePicker SinceDate
        {
            get { return this.Dispatcher.Invoke(() => this.sinceDatePick); }
            set { this.Dispatcher.Invoke(() => this.sinceDatePick = value); }
        }

        public DatePicker ToDate
        {
            get { return this.Dispatcher.Invoke(() => this.toDatePick); }
            set { this.Dispatcher.Invoke(() => this.toDatePick = value); }
        }

        public string ErrorSinceDate
        {
            get { return this.Dispatcher.Invoke(() => this.lblErrorSinceDate.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblErrorSinceDate.Content = value); }
        }

        public string ErrorToDate
        {
            get { return this.Dispatcher.Invoke(() => this.lblErrorToDate.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblErrorToDate.Content = value); }
        }

        public Visibility FindVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.findByDefs.Visibility); }
            set { this.Dispatcher.Invoke(() => this.findByDefs.Visibility = value); }
        }

        public Visibility ListProductVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.listProducts.Visibility); }
            set { this.Dispatcher.Invoke(() => this.listProducts.Visibility = value); }
        }

        public Visibility ListArrivedGoodsVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.listArrivedGoods.Visibility); }
            set { this.Dispatcher.Invoke(() => this.listArrivedGoods.Visibility = value); }
        }

        public Visibility ListSalesVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.listSales.Visibility); }
            set { this.Dispatcher.Invoke(() => this.listSales.Visibility = value); }
        }

        public bool SettingFindGridEnabled
        {
            get { return this.Dispatcher.Invoke(() => this.settingFindGrid.IsEnabled); }
            set { this.Dispatcher.Invoke(() => this.settingFindGrid.IsEnabled = value); }
        }

        public Button GetBackBtn
        {
            get { return this.Dispatcher.Invoke(() => this.GetAllBackBtn); }
            set { this.Dispatcher.Invoke(() => this.GetAllBackBtn = value); }
        }

        public ComboBox TableList
        {
            get { return this.Dispatcher.Invoke(() => this.tableList); }
            set { this.Dispatcher.Invoke(() => this.tableList = value); }
        }

        public ComboBox FindList
        {
            get { return this.Dispatcher.Invoke(() => this.listFindBy); }
            set { this.Dispatcher.Invoke(() => this.listFindBy = value); }
        }

        public ComboBox ClassList
        {
            get { return this.Dispatcher.Invoke(() => this.listClass); }
            set { this.Dispatcher.Invoke(() => this.listClass = value); }
        }

        public ListView ListProducts
        {
            get { return this.Dispatcher.Invoke(() => this.listProducts); }
            set { this.Dispatcher.Invoke(() => this.listProducts = value); }
        }

        public ListView ListArrivedGoods
        {
            get { return this.Dispatcher.Invoke(() => this.listArrivedGoods); }
            set { this.Dispatcher.Invoke(() => this.listProducts = value); }
        }

        public ListView ListSales
        {
            get { return this.Dispatcher.Invoke(() => this.listSales); }
            set { this.Dispatcher.Invoke(() => this.listSales = value); }
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

//public string ErrorSinceDateReport
//{
//    get { return this.Dispatcher.Invoke(() => this.lblLastNameError.Content.ToString()); }
//    set { this.Dispatcher.Invoke(() => this.lblLastNameError.Content = value); }
//}

//public string ErrorToDateReport
//{
//    get { return this.Dispatcher.Invoke(() => this.lblLastNameError.Content.ToString()); }
//    set { this.Dispatcher.Invoke(() => this.lblLastNameError.Content = value); }
//}

//public Visibility FindPanelVisibility
//{
//    get { return this.Dispatcher.Invoke(() => this.FindPanel.Visibility); }
//    set { this.Dispatcher.Invoke(() => this.FindPanel.Visibility = value); }
//}

//public Visibility ReportPanelVisibility
//{
//    get { return this.Dispatcher.Invoke(() => this.ReportPanel.Visibility); }
//    set { this.Dispatcher.Invoke(() => this.ReportPanel.Visibility = value); }
//}