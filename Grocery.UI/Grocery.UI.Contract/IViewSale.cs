using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Grocery.UI.Contract
{
    public interface IViewSale : IView
    {
        string ErrorProduct { get; set; }
        string ErrorCount { get; set; }
        string ErrorDatetime { get; set; }
        ComboBox ProductList { get; set; }
        string CountTxt { get; set; }
        DatePicker DatetimePick { get; set; }
        string SellerTxt { get; set; }
        string PriceTxt { get; set; }
        void ShowMsh(string msg);
    }
}
