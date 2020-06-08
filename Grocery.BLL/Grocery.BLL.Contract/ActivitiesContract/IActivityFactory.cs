using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public interface IActivityFactory
    {
        T Create<T>();
    }
}
