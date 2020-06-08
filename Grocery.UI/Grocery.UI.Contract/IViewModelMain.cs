using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.UI.Contract
{
    public interface IViewModelMain
    {
        void ShowArrivedGoods();
        void ShowProducts();
        void ShowSales();
        void SetSeller();
        void ChangeTable(int selectedIndex);
        void OpenFind();
        void FindElements();
        void GetAllBack();
        void EditProductGoods();
        void AddProductGoods();
        void CreateReport();
        void AddSale();
        void SetClasses();
        IViewMain ViewMain { get; set; }
    }
}
