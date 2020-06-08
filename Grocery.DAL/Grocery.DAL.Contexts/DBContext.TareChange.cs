using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<TareChange> tareChanges;

        public List<TareChange> TareChanges
        {
            get { return this.tareChanges; }
            set { this.tareChanges = value; }
        }

        public void GetTareChangesFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM TareChanges", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.tareChanges = new List<TareChange>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string name = dr[1].ToString();

                    this.TareChanges.Add(new TareChange { Id = id, Name = name });
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

        public void InsertTareChange(TareChange tareChange)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into TareChanges(tare_change) Values(@tare_change)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@tare_change", tareChange.Name);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the tare-change!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropTareChange(TareChange tareChange)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from TareChanges where id = '" + tareChange.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the tare-change!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateTareChange(TareChange tareChange)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update TareChanges Set tare_change=@tare_change Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", tareChange.Id);
                sqlCom.Parameters.AddWithValue("@tare_change", tareChange.Name);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update tare-change data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public TareChange FindTareChangeById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM TareChanges Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr[1].ToString();

                    return new TareChange { Id = id, Name = name };
                }
                throw new Exception("Required tare change is absent!");
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
