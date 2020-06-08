using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.UI.Contract
{
    public interface IView
    {
        void ShowError(string error);
        void ClearError(string error);
    }
}
