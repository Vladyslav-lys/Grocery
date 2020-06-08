using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<Department> departments;

        public List<Department> Departments
        {
            get { return this.departments; }
            set { this.departments = value; }
        }

        public void GetDepartmentsFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Departments", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.departments = new List<Department>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    int number = int.Parse(dr[1].ToString());
                    string address = dr[2].ToString();

                    this.Departments.Add(new Department { Id = id, Number = number, Address = address });
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

        public void InsertDepartment(Department department)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Departments(number, address) Values(@number, @address)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@number", department.Number);
                sqlCom.Parameters.AddWithValue("@address", department.Address);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the department!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropDepartment(Department department)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Departments where id = '" + department.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the department!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Departments Set number=@number, address=@address Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", department.Id);
                sqlCom.Parameters.AddWithValue("@number", department.Number);
                sqlCom.Parameters.AddWithValue("@address", department.Address);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update department data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public Department FindDepartmentById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Departments Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while(dr.Read())
                {
                    int number = int.Parse(dr[1].ToString());
                    string address = dr[2].ToString();

                    return new Department { Id = id, Number = number, Address = address };
                }
                throw new Exception("Required department is absent!");
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
