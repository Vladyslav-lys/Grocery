using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class ValidationBase
    {
        public ValidResult validResult;

        public ValidationBase()
        {
            validResult = new ValidResult();
        }
    }
}
