using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class GetSellerRequest
    {
        public User User { get; set; }

        public GetSellerRequest(User user)
        {
            this.User = user;
        }
    }
}
