using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.UI.Contract
{
    public interface IViewLogin : IView
    {
        string Login { get; }
        string Password { get; }
        string ErrorLogin { get; set; }
        string ErrorPassword { get; set; }
    }
}
