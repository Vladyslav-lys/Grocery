using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetUserActivity : IGetUserActivity
    {
        private IUserRepository userRepository;

        public GetUserActivity(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Run(string login, string password)
        {
            User user = null;

            userRepository.GetNewAll();
            foreach (User curUser in userRepository.GetAll())
            {
                if (login.Equals(curUser.Login) && password.Equals(curUser.Password))
                    user = new User() { Id = curUser.Id, Login = curUser.Login, Password = curUser.Password };
            }

            if (user == null)
                throw new Exception("The user is not found! Please, check out login or password");

            return user;
        }
    }
}
