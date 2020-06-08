using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<Seller> sellers;

        public List<Seller> Sellers
        {
            get { return this.sellers; }
            set { this.sellers = value; }
        }

        public void GetSellersFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Sellers", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.sellers = new List<Seller>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string surname = dr[1].ToString();
                    string firstName = dr[2].ToString();
                    string secondName = dr[3].ToString();
                    string passportSeries = dr[4].ToString();
                    int passportNumber = int.Parse(dr[5].ToString());
                    long tin = long.Parse(dr[6].ToString());
                    DateTime birthDate = DateTime.Parse(dr[7].ToString());
                    long phoneNumber = long.Parse(dr[8].ToString());
                    string address = dr[9].ToString();
                    int departmentId = int.Parse(dr[10].ToString());
                    int userId = int.Parse(dr[11].ToString());
                    bool fired = bool.Parse(dr[12].ToString());
                    DateTime? firedDate = string.IsNullOrEmpty(dr[13].ToString()) ? (DateTime?)null : DateTime.Parse(dr[13].ToString());

                    this.Sellers.Add(new Seller
                    {
                        Id = id,
                        Surname = surname,
                        FirstName = firstName,
                        SecondName = secondName,
                        PassportSeries = passportSeries,
                        PassportNumber = passportNumber,
                        TIN = tin,
                        BirthDate = birthDate,
                        PhoneNumber = phoneNumber,
                        Address = address,
                        Department = new Department { Id=departmentId, Address="", Number=0 },
                        User = new User { Id=userId, Login="", Password="" },
                        Fired = fired,
                        FiredDate = firedDate
                    });
                }

                foreach(Seller seller in sellers)
                {
                    seller.Department = FindDepartmentById(seller.Department.Id);
                    seller.User = FindUserById(seller.User.Id);
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

        public void InsertSeller(Seller seller)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Sellers(surname, firstname, secondname, passport_series, passport_number, tin, birthdate, phone_number, address, iddepartments, idusers, fired, fired_date) " +
                    "Values(@surname, @firstname, @secondname, @passport_series, @passport_number, @tin, @birthdate, @phone_number, @address, @iddepartments, @idusers, @fired, @fired_date)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@surname", seller.Surname);
                sqlCom.Parameters.AddWithValue("@firstname", seller.FirstName);
                sqlCom.Parameters.AddWithValue("@secondname", seller.SecondName);
                sqlCom.Parameters.AddWithValue("@passport_series", seller.PassportSeries);
                sqlCom.Parameters.AddWithValue("@passport_number", seller.PassportNumber);
                sqlCom.Parameters.AddWithValue("@tin", seller.TIN);
                sqlCom.Parameters.AddWithValue("@birthdate", seller.BirthDate);
                sqlCom.Parameters.AddWithValue("@phone_number", seller.PhoneNumber);
                sqlCom.Parameters.AddWithValue("@address", seller.Address);
                sqlCom.Parameters.AddWithValue("@iddepartments", seller.Department.Id);
                sqlCom.Parameters.AddWithValue("@idusers", seller.User.Id);
                sqlCom.Parameters.AddWithValue("@fired", seller.Fired);
                sqlCom.Parameters.AddWithValue("@fired_date", seller.FiredDate);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the seller!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropSeller(Seller seller)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Sellers where id = '" + seller.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the seller!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateSeller(Seller seller)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Sellers Set surname=@surname, firstname=@firstname, secondname=@secondname, passport_series=@passport_series, passport_number=@passport_number, tin=@tin, " +
                    "birthdate=@birthdate, phone_number=@phone_number, address=@address, iddepartments=@iddepartments, idusers=@idusers, fired=@fired, fired_date=@fired_date Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", seller.Id);
                sqlCom.Parameters.AddWithValue("@surname", seller.Surname);
                sqlCom.Parameters.AddWithValue("@firstname", seller.FirstName);
                sqlCom.Parameters.AddWithValue("@secondname", seller.SecondName);
                sqlCom.Parameters.AddWithValue("@passport_series", seller.PassportSeries);
                sqlCom.Parameters.AddWithValue("@passport_number", seller.PassportNumber);
                sqlCom.Parameters.AddWithValue("@tin", seller.TIN);
                sqlCom.Parameters.AddWithValue("@birthdate", seller.BirthDate);
                sqlCom.Parameters.AddWithValue("@phone_number", seller.PhoneNumber);
                sqlCom.Parameters.AddWithValue("@address", seller.Address);
                sqlCom.Parameters.AddWithValue("@iddepartments", seller.Department.Id);
                sqlCom.Parameters.AddWithValue("@idusers", seller.User.Id);
                sqlCom.Parameters.AddWithValue("@fired", seller.Fired);
                sqlCom.Parameters.AddWithValue("@fired_date", seller.FiredDate);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update seller data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public Seller FindSellerById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Sellers Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    string surname = dr[1].ToString();
                    string firstName = dr[2].ToString();
                    string secondName = dr[3].ToString();
                    string passportSeries = dr[4].ToString();
                    int passportNumber = int.Parse(dr[5].ToString());
                    long tin = long.Parse(dr[6].ToString());
                    DateTime birthDate = DateTime.Parse(dr[7].ToString());
                    long phoneNumber = long.Parse(dr[8].ToString());
                    string address = dr[9].ToString();
                    int departmentId = int.Parse(dr[10].ToString());
                    int userId = int.Parse(dr[11].ToString());
                    bool fired = bool.Parse(dr[12].ToString());
                    DateTime? firedDate = string.IsNullOrEmpty(dr[13].ToString()) ? (DateTime?)null : DateTime.Parse(dr[13].ToString());

                    return new Seller
                    {
                        Id = id,
                        Surname = surname,
                        FirstName = firstName,
                        SecondName = secondName,
                        PassportSeries = passportSeries,
                        PassportNumber = passportNumber,
                        TIN = tin,
                        BirthDate = birthDate,
                        PhoneNumber = phoneNumber,
                        Address = address,
                        Department = FindDepartmentById(departmentId),
                        User = FindUserById(userId),
                        Fired = fired,
                        FiredDate = firedDate
                    };
                }
                throw new Exception("Required seller is absent!");
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
