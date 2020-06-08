using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public interface IValidationActivity<T>
    {
        void Validate(T request);
    }
}
