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
using System.Windows;

namespace Grocery.UI.ViewModel
{
    public class ViewModelReport : ViewModelBase, IViewModelReport
    {
        private IViewReport viewReport;
        
        private RelayCommand createReportCommand;
        private RelayCommand getBackCommand;

        private IReportValidationRule reportValidationRule;
        private IMainWindowController mainWindowController;
        private IFrontServiceClient frontServiceClient;
        private User user;
        private List<Class> classes = new List<Class>();
        private List<Category> categories = new List<Category>();
        private List<ReportSimple> reportSimples = new List<ReportSimple>();
        private List<ReportDetailed> reportDetaileds = new List<ReportDetailed>();

        public ViewModelReport() { }

        public ViewModelReport(IReportValidationRule reportValidationRule, IMainWindowController mainWindowController, IFrontServiceClient frontServiceClient, User user)
        {
            this.validatablePropertyCollection.Add("SinceDate");
            this.validatablePropertyCollection.Add("ToDate");

            this.reportValidationRule = reportValidationRule;
            this.mainWindowController = mainWindowController;
            this.frontServiceClient = frontServiceClient;
            this.user = user;
        }

        private bool CanExecute => this.IsValid;

        public IViewReport ViewReport
        {
            get { return this.viewReport; }
            set { this.viewReport = value; }
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "SinceDate":
                    if (this.viewReport.SinceDate.IsEnabled)
                    {
                        error = this.reportValidationRule.ValidateSinceDate(this.viewReport.SinceDate.Text).GetError();
                        this.viewReport.ErrorSinceDate = error;
                    }
                    break;
                case "ToDate":
                    if (this.viewReport.ToDate.IsEnabled)
                    {
                        error = this.reportValidationRule.ValidateToDate(this.viewReport.ToDate.Text).GetError();
                        this.viewReport.ErrorToDate = error;
                    }
                    break;
                default:
                    this.viewReport.ClearError(this.viewReport.ErrorSinceDate);
                    this.viewReport.ClearError(this.viewReport.ErrorToDate);
                    break;
            }
            this.reportValidationRule.RefreshValidResult();

            return error;
        }

        #region Command
        public ICommand CreateReportCommand
        {
            get
            {
                if (this.createReportCommand == null)
                {
                    this.createReportCommand = new RelayCommand(() => this.CreateReport(), param => this.CanExecute);
                }
                return this.createReportCommand;
            }
        }

        public ICommand GetBackCommand
        {
            get
            {
                if (this.getBackCommand == null)
                {
                    this.getBackCommand = new RelayCommand(() => this.GetAllBack(), param => true);
                }
                return this.getBackCommand;
            }
        }

        public int EnableToChoose
        {
            set
            {
                this.SetReport(value);
            }
        }
        #endregion


        #region Active
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
                    this.viewReport.CategoryList.ItemsSource = this.categories;
                    this.viewReport.CategoryList.DisplayMemberPath = "Name";
                    this.viewReport.CategoryList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.viewReport.ShowError(ex.InnerException.Message);
            }
        }

        public void CreateReport()
        {
            switch(this.viewReport.ReportList.SelectedIndex)
            {
                case 0:
                    CreateSimpleReport();
                    break;
                case 1:
                    CreateDetailedReport();
                    break;
                default:
                    break;
            }
        }

        public void GetAllBack()
        {
            this.mainWindowController.LoadMain(user, frontServiceClient);
        }

        private void CreateSimpleReport()
        {
            DateTime sinceDate = this.viewReport.SinceDate.SelectedDate.Value;
            DateTime toDate = this.viewReport.ToDate.SelectedDate.Value;

            try
            {
                Task task = Task.Run(async () =>
                {
                    this.reportSimples = await this.frontServiceClient.ShowReportSimpleAsync(sinceDate, toDate);
                });
                task.Wait();

                if (this.reportSimples.Count > 0)
                {
                    this.viewReport.ListReportSimple.ItemsSource = reportSimples;
                }
            }
            catch (Exception ex)
            {
                this.viewReport.ShowError(ex.InnerException.Message);
            }

            this.viewReport.ListReportSimpleVisibility = Visibility.Visible;
            this.viewReport.ListReportDetailedVisibility = Visibility.Hidden;
        }

        private void CreateDetailedReport()
        {
            try
            {
                Category category = (Category)this.viewReport.CategoryList.SelectedItem;
                DateTime sinceDate = this.viewReport.SinceDate.SelectedDate.Value;
                DateTime toDate = this.viewReport.ToDate.SelectedDate.Value;

                Task task = Task.Run(async () =>
                {
                    this.reportDetaileds = await this.frontServiceClient.ShowReportDetailedAsync(category, sinceDate, toDate);
                });
                task.Wait();

                if (this.reportDetaileds.Count > 0)
                {
                    this.viewReport.ListReportDetailed.ItemsSource = reportDetaileds;
                }
            }
            catch (Exception ex)
            {
                this.viewReport.ShowError(ex.InnerException.Message);
            }

            this.viewReport.ListReportSimpleVisibility = Visibility.Hidden;
            this.viewReport.ListReportDetailedVisibility = Visibility.Visible;
        }

        private void SetReport(int index)
        {
            switch(index)
            {
                case 0:
                    this.viewReport.CategoryList.IsEnabled = false;
                    this.viewReport.SettingReportEnabled = true;
                    break;
                case 1:
                    this.viewReport.CategoryList.IsEnabled = true;
                    this.viewReport.SettingReportEnabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
