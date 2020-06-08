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
    /// Логика взаимодействия для ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl, IViewReport
    {
        public ReportView(IViewModelReport viewModelReport)
        {
            viewModelReport.ViewReport = this;
            InitializeComponent();
            this.DataContext = viewModelReport;
            viewModelReport.SetCategories();
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

        public ComboBox ReportList
        {
            get { return this.Dispatcher.Invoke(() => this.typeList); }
            set { this.Dispatcher.Invoke(() => this.typeList = value); }
        }

        public ComboBox CategoryList
        {
            get { return this.Dispatcher.Invoke(() => this.listCategory); }
            set { this.Dispatcher.Invoke(() => this.listCategory = value); }
        }

        public ListView ListReportSimple
        {
            get { return this.Dispatcher.Invoke(() => this.listReportSimple); }
            set { this.Dispatcher.Invoke(() => this.listReportSimple = value); }
        }

        public ListView ListReportDetailed
        {
            get { return this.Dispatcher.Invoke(() => this.listReportDetailed); }
            set { this.Dispatcher.Invoke(() => this.listReportDetailed = value); }
        }

        public Visibility ListReportSimpleVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.listReportSimple.Visibility); }
            set { this.Dispatcher.Invoke(() => this.listReportSimple.Visibility = value); }
        }

        public Visibility ListReportDetailedVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.listReportDetailed.Visibility); }
            set { this.Dispatcher.Invoke(() => this.listReportDetailed.Visibility = value); }
        }

        public bool SettingReportEnabled
        {
            get { return this.Dispatcher.Invoke(() => this.settingReport.IsEnabled); }
            set { this.Dispatcher.Invoke(() => this.settingReport.IsEnabled = value); }
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
