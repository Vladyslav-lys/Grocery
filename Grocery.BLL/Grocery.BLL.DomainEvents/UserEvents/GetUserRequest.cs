using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.DomainEvents
{
    public class GetUserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public GetUserRequest(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
