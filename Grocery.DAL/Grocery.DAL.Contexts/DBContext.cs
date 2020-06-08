using System;
using System.Collections.Generic;
using Grocery.BLL.Entities;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
//this.connectionString = "Data Source=WIN-4ITBPNHRO6N\\SQLEXPRESS;Initial Catalog=Grocery;Integrated Security=True;MultipleActiveResultSets=true;";
namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private SqlConnection con;
        private string connectionString;

        public DBContext()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;
        }

        public void OpenConnection()
        {
            try
            {
                if (con == null)
                {
                    this.con = new SqlConnection(this.connectionString);
                    this.con.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There is wrong connection!", ex);
            }
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Close();
                con = null;
            }
        }
    }
}
