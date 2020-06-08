using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.UI.Contract
{
    public interface IViewModelLogin
    {
        void Enter();
        void Exit();
        IViewLogin ViewLogin { get; set; }
    }
}
