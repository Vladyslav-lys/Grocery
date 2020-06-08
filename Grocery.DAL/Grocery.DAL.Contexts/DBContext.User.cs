using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<User> users;

        public List<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public void GetUsersFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Users", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.users = new List<User>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string login = dr[1].ToString();
                    string password = dr[2].ToString();

                    this.Users.Add(new User { Id = id, Login = login, Password = password });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Current data are absent!", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void InsertUser(User user)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Users(login, password) Values(@login, @password)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@login", user.Login);
                sqlCom.Parameters.AddWithValue("@password", user.Password);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the user!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropUser(User user)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Users where id = '" + user.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the user!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Users Set login=@login, password=@password Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", user.Id);
                sqlCom.Parameters.AddWithValue("@login", user.Login);
                sqlCom.Parameters.AddWithValue("@password", user.Password);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update user data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public User FindUserById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Users Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();
                
                while(dr.Read())
                {
                    string login = dr[1].ToString();
                    string password = dr[2].ToString();

                    return new User { Id = id, Login = login, Password = password };
                }
                throw new Exception("Required user is absent!");
            }
            catch (SqlException ex)
            {
                throw new Exception("Current data are absent!", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}
