using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.BLL.DomainEvents;

namespace Grocery.BLL.Activities
{
    public class EnterValidationActivity : IValidationActivity<GetUserRequest>
    {
        private IEnterValidationRule enterValidationRule;

        public EnterValidationActivity(IEnterValidationRule enterValidationRule)
        {
            this.enterValidationRule = enterValidationRule;
        }

        public void Validate(GetUserRequest requsetUserEvent)
        {
            ValidResult validResultLogin = enterValidationRule.ValidateLogin(requsetUserEvent.Login);
            ValidResult validResultPassword = enterValidationRule.ValidatePassword(requsetUserEvent.Password);

            if (validResultLogin.GetError().Length > 0)
            {
                throw new Exception(validResultLogin.GetError());
            }
            else if (validResultPassword.GetError().Length > 0)
            {
                throw new Exception(validResultPassword.GetError());
            }
        }
    }
}
