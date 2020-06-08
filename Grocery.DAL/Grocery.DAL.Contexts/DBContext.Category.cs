using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<Category> categories;

        public List<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public void GetCategoriesFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Categories", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.categories = new List<Category>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string name = dr[1].ToString();

                    this.Categories.Add(new Category { Id = id, Name = name });
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

        public void InsertCategory(Category category)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Categories(category) Values(@category)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@category", category.Name);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the category!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropCategory(Category category)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Categories where id = '" + category.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the category!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Categories Set category=@category Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", category.Id);
                sqlCom.Parameters.AddWithValue("@category", category.Name);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update category data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public Category FindCategoryById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Categories Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr[1].ToString();

                    return new Category { Id = id, Name = name };
                }
                throw new Exception("Required category is absent!");
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

