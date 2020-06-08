using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.UI.Contract
{
    public interface IViewModelReport
    {
        void CreateReport();
        void SetCategories();
        IViewReport ViewReport { get; set; }
    }
}
