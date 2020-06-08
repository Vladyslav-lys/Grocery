using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<Provider> providers;

        public List<Provider> Providers
        {
            get { return this.providers; }
            set { this.providers = value; }
        }

        public void GetProvidersFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Providers", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.providers = new List<Provider>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string name = dr[1].ToString();
                    string address = dr[2].ToString();
                    int phoneNumber = int.Parse(dr[3].ToString());

                    this.Providers.Add(new Provider { Id = id, Name = name, Address = address, PhoneNumber = phoneNumber });
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

        public void InsertProvider(Provider provider)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Providers(name, address, phone_number) Values(@name, @address, @phone_number)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@name", provider.Name);
                sqlCom.Parameters.AddWithValue("@address", provider.Address);
                sqlCom.Parameters.AddWithValue("@phone_number", provider.PhoneNumber);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the provier!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropProvider(Provider provider)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Providers where id = '" + provider.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the provier!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateProvider(Provider provider)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Providers Set name=@name, address=@address, phone_number=@phone_number Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", provider.Id);
                sqlCom.Parameters.AddWithValue("@name", provider.Name);
                sqlCom.Parameters.AddWithValue("@address", provider.Address);
                sqlCom.Parameters.AddWithValue("@phone_number", provider.PhoneNumber);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update provier data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public Provider FindProviderById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Providers Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr[1].ToString();
                    string address = dr[2].ToString();
                    int phoneNumber = int.Parse(dr[3].ToString());

                    return new Provider { Id = id, Name = name, Address = address, PhoneNumber = phoneNumber };
                }
                throw new Exception("Required provider is absent!");
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
