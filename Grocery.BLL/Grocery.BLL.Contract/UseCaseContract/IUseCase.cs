using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public interface IUseCase<in TRequest, out TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
