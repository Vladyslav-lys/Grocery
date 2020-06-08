using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Grocery.UI.Contract
{
    public interface IViewMain : IView
    {
        DatePicker SinceDate { get; set; }
        DatePicker ToDate { get; set; }
        string ErrorToDate { get; set; }
        string ErrorSinceDate { get; set; }
        Visibility FindVisibility { get; set; }
        Visibility ListProductVisibility { get; set; }
        Visibility ListArrivedGoodsVisibility { get; set; }
        Visibility ListSalesVisibility { get; set; }
        bool SettingFindGridEnabled { get; set; }
        Button GetBackBtn { get; set; }
        //Button EditBtn { get; set; }
        ComboBox TableList { get; set; }
        ComboBox FindList { get; set; }
        ComboBox ClassList { get; set; }
        ListView ListArrivedGoods { get; set; }
        ListView ListProducts { get; set; }
        ListView ListSales { get; set; }
        void ShowMsh(string msg);
    }
}
