using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetUserResponse
    {
        public User User { get; set; }

        public GetUserResponse(User user)
        {
            this.User = user;
        }
    }
}
