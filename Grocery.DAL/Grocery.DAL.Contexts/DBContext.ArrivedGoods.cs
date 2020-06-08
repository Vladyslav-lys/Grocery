using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<ArrivedGoods> arrivedGoods;

        public List<ArrivedGoods> ArrivedGoods
        {
            get { return this.arrivedGoods; }
            set { this.arrivedGoods = value; }
        }

        public void GetArrivedGoodsFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM ArrivedGoods", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.arrivedGoods = new List<ArrivedGoods>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    int providerId = int.Parse(dr[1].ToString());
                    int count = int.Parse(dr[2].ToString());
                    DateTime datetime = DateTime.Parse(dr[3].ToString());
                    float purchasePrice = float.Parse(dr[4].ToString());
                    float salesPrice = float.Parse(dr[5].ToString());
                    int departmentId = int.Parse(dr[6].ToString());
                    int sellerId = int.Parse(dr[7].ToString());

                    this.ArrivedGoods.Add(new ArrivedGoods
                    {
                        Id = id,
                        Provider = new Provider { Id=providerId, Address="", Name="", PhoneNumber=0 },
                        Count = count,
                        DateTime = datetime,
                        AllPurchasePrice = purchasePrice,
                        AllSalesPrice = salesPrice,
                        Department = new Department { Id=departmentId, Address="", Number=0 },
                        Seller = new Seller { Id=sellerId, Address="", Department=null, PhoneNumber=0, BirthDate=new DateTime(), Fired=false, FiredDate=null, FirstName="", PassportNumber=0, PassportSeries="", SecondName="", Surname="", TIN=0, User=null}
                    });
                }

                foreach (ArrivedGoods arrivedGood in arrivedGoods)
                {
                    arrivedGood.Provider = FindProviderById(arrivedGood.Provider.Id);
                    arrivedGood.Department = FindDepartmentById(arrivedGood.Department.Id);
                    arrivedGood.Seller = FindSellerById(arrivedGood.Seller.Id);
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

        public void InsertArrivedGoods(ArrivedGoods arrivedGoods)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into ArrivedGoods(idproviders, count, datetime, purchase_price, sales_price, iddepartments, idsellers) Values(@idproviders, @count, @datetime, @purchase_price, @sales_price, @iddepartments, @idsellers)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@idproviders", arrivedGoods.Provider.Id);
                sqlCom.Parameters.AddWithValue("@count", arrivedGoods.Count);
                sqlCom.Parameters.AddWithValue("@datetime", arrivedGoods.DateTime);
                sqlCom.Parameters.AddWithValue("@purchase_price", arrivedGoods.AllPurchasePrice);
                sqlCom.Parameters.AddWithValue("@sales_price", arrivedGoods.AllSalesPrice);
                sqlCom.Parameters.AddWithValue("@iddepartments", arrivedGoods.Department.Id);
                sqlCom.Parameters.AddWithValue("@idsellers", arrivedGoods.Seller.Id);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the product!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropArrivedGoods(ArrivedGoods arrivedGoods)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from ArrivedGoods where id = '" + arrivedGoods.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the product!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateArrivedGoods(ArrivedGoods arrivedGoods)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update ArrivedGoods Set idproviders=@idproviders, count=@count, datetime=@datetime, purchase_price=@purchase_price, sales_price=@sales_price, iddepartments=@iddepartments, idsellers=@idsellers Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", arrivedGoods.Id);
                sqlCom.Parameters.AddWithValue("@idproviders", arrivedGoods.Provider.Id);
                sqlCom.Parameters.AddWithValue("@count", arrivedGoods.Count);
                sqlCom.Parameters.AddWithValue("@datetime", arrivedGoods.DateTime);
                sqlCom.Parameters.AddWithValue("@purchase_price", arrivedGoods.AllPurchasePrice);
                sqlCom.Parameters.AddWithValue("@sales_price", arrivedGoods.AllSalesPrice);
                sqlCom.Parameters.AddWithValue("@iddepartments", arrivedGoods.Department.Id);
                sqlCom.Parameters.AddWithValue("@idsellers", arrivedGoods.Seller.Id);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update product data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public ArrivedGoods FindArrivedGoodsById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM ArrivedGoods Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    int providerId = int.Parse(dr[1].ToString());
                    int count = int.Parse(dr[2].ToString());
                    DateTime datetime = DateTime.Parse(dr[3].ToString());
                    float purchasePrice = float.Parse(dr[4].ToString());
                    float salesPrice = float.Parse(dr[5].ToString());
                    int departmentId = int.Parse(dr[6].ToString());
                    int sellerId = int.Parse(dr[7].ToString());

                    return new ArrivedGoods
                    {
                        Id = id,
                        Provider = FindProviderById(providerId),
                        Count = count,
                        DateTime = datetime,
                        AllPurchasePrice = purchasePrice,
                        AllSalesPrice = salesPrice,
                        Department = FindDepartmentById(departmentId),
                        Seller = FindSellerById(sellerId)
                    };
                }
                throw new Exception("Required supply is absent!");
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
