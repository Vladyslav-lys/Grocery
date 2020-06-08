using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;

namespace Grocery.BLL.Rules
{
    public class EnterValidationRule : ValidationBase, IEnterValidationRule
    {
        public EnterValidationRule() : base()
        {

        }

        public ValidResult ValidateLogin(string login)
        {
            if (string.IsNullOrEmpty(login) || !login.IsStringWithNumbers())
            {
                validResult = new ValidResult(false, "Login must have: letters or digits");
            }
            return validResult;
        }

        public ValidResult ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || !password.IsStringWithNumbers())
            {
                validResult = new ValidResult(false, "Password must have: letters or digits");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}
