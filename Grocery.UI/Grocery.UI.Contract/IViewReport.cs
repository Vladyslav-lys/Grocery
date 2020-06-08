using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Grocery.UI.Contract
{
    public interface IViewReport : IView
    {
        DatePicker SinceDate { get; set; }
        DatePicker ToDate { get; set; }
        string ErrorSinceDate { get; set; }
        string ErrorToDate { get; set; }
        ComboBox ReportList { get; set; }
        ComboBox CategoryList { get; set; }
        Visibility ListReportSimpleVisibility { get; set; }
        Visibility ListReportDetailedVisibility { get; set; }
        ListView ListReportSimple { get; set; }
        ListView ListReportDetailed { get; set; }
        bool SettingReportEnabled { get; set; }
        void ShowMsh(string msg);
    }
}
