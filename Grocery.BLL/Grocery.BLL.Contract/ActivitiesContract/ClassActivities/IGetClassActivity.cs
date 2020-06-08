using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Contract
{
    public interface IGetClassActivity
    {
        List<Class> Run();
    }
}
