using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.UI.Contract
{
    public interface IViewModelProduct
    {
        void ShowProductGoods();
        void SetTareChanges();
        void SetCategories();
        void SetClasses();
        void SetProviders();
        void SetSeller();
        void SetDepartment();
        void Execute();
        void GetBack();
        IViewProduct ViewProduct { get; set; }
    }
}
