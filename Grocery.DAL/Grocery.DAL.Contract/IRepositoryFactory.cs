using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.DAL.Contract
{
    public interface IRepositoryFactory
    {
        T Create<T>();
    }
}
