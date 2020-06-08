using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Contract
{
    public interface IEnterValidationRule
    {
        ValidResult ValidateLogin(string login);
        ValidResult ValidatePassword(string password);

        void RefreshValidResult();
    }
}
