using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DBContext db;

        public UserRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(User user)
        {
            if (user != null)
            {
                db.InsertUser(user);
            }
        }

        public void Delete(User user)
        {
            User curUser = this.FindById(user.Id);

            if (curUser != null)
            {
                db.DropUser(user);
                db.Users.Remove(curUser);
            }
        }

        public User FindById(int id)
        {
            foreach (User curUser in this.GetAll())
            {
                if (curUser.Id == id)
                    return curUser;
            }
            return null;
        }

        public List<User> GetAll()
        {
            return db.Users;
        }

        public void GetNewAll()
        {
            db.GetUsersFromDatabase();
        }

        public void Update(User user)
        {
            if (user != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Users[i].Id == user.Id)
                    {
                        db.Users[i].Login = user.Login;
                        db.Users[i].Password = user.Password;
                    }
                }
                db.UpdateUser(user);
            }
        }
    }
}
