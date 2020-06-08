using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<Class> classes;

        public List<Class> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        public void GetClassesFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Classes", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.classes = new List<Class>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string name = dr[1].ToString();

                    this.Classes.Add(new Class { Id = id, Name = name });
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

        public void InsertClass(Class class_)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Classes(class) Values(@class)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@class", class_.Name);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the class!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropClass(Class class_)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Classes where id = '" + class_.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the class!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateClass(Class class_)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Classes Set class=@class Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", class_.Id);
                sqlCom.Parameters.AddWithValue("@class", class_.Name);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update class data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public Class FindClassById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Classes Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr[1].ToString();

                    return new Class { Id = id, Name = name };
                }
                throw new Exception("Required class is absent!");
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
