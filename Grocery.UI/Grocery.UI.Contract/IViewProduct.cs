using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Grocery.UI.Contract
{
    public interface IViewProduct : IView
    {
        string ErrorUnit { get; set; }
        string ErrorCount { get; set; }
        string ErrorDatetime { get; set; }
        string ErrorExpirationDate { get; set; }
        string ErrorAllPurchasePrice { get; set; }
        string ErrorAllSalesPrice { get; set; }
        string ErrorReturnedDate { get; set; }
        ComboBox TareChangeList { get; set; }
        ComboBox ProviderList { get; set; }
        ComboBox CategoryList { get; set; }
        ComboBox ClassList { get; set; }
        string UnitTxt { get; set; }
        string CountTxt { get; set; }
        string AllPurchasePriceTxt { get; set; }
        string AllSalesPriceTxt { get; set; }
        string DepartmentTxt { get; set; }
        string SellerTxt { get; set; }
        DatePicker DatetimePick { get; set; }
        DatePicker ExpirationDatePick { get; set; }
        DatePicker ReturnedDatePick { get; set; }
        bool? ReturnedChecked { get; set; }
        bool? WritenOffChecked { get; set; }
        void ShowMsh(string msg);
    }
}
