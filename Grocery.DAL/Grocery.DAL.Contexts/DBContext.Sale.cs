using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<Sale> sales;

        public List<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        public void GetSalesFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Sales", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.sales = new List<Sale>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    int productId = int.Parse(dr[1].ToString());
                    int count = int.Parse(dr[2].ToString());
                    float price = float.Parse(dr[3].ToString());
                    DateTime dateTime = DateTime.Parse(dr[4].ToString());
                    int sellerId = int.Parse(dr[5].ToString());

                    this.Sales.Add(new Sale
                    {
                        Id = id,
                        Product = new Product { Id=productId, Category=null, Class=null, ArrivedGoods=null, Count=0, ExpirationDate=new DateTime(), PurchasePrice=0.0f, Returned=false, ReturnedDate=new DateTime(), SalesPrice=0.0f, TareChange=null, Unit="", WritenOff=false },
                        Count = count,
                        Price = price,
                        Datetime = dateTime,
                        Seller = new Seller { Id=sellerId, Address="", BirthDate=new DateTime(), Department=null, Fired=false, FiredDate=null, FirstName="", PassportNumber=0, PassportSeries="", PhoneNumber=0, SecondName="", Surname="", TIN=0, User=null }
                    });
                }

                foreach(Sale sale in sales)
                {
                    sale.Product = FindProductById(sale.Product.Id);
                    sale.Seller = FindSellerById(sale.Seller.Id);
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

        public void InsertSale(Sale sale)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Sales(idproducts, count, price, datetime, idsellers) Values(@idproducts, @count, @price, @datetime, @idsellers)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@idproducts", sale.Product.Id);
                sqlCom.Parameters.AddWithValue("@count", sale.Count);
                sqlCom.Parameters.AddWithValue("@price", sale.Price);
                sqlCom.Parameters.AddWithValue("@datetime", sale.Datetime);
                sqlCom.Parameters.AddWithValue("@idsellers", sale.Seller.Id);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add the sale!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void DropSale(Sale sale)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Sales where id = '" + sale.Id.ToString() + "'";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete the sale!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void UpdateSale(Sale sale)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Sales Set idproducts=@idproducts, count=@count, price=@price, datetime=@datetime, idsellers=@idsellers Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@idproducts", sale.Product.Id);
                sqlCom.Parameters.AddWithValue("@count", sale.Count);
                sqlCom.Parameters.AddWithValue("@price", sale.Price);
                sqlCom.Parameters.AddWithValue("@datetime", sale.Datetime);
                sqlCom.Parameters.AddWithValue("@idsellers", sale.Seller.Id);
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update sale data!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public Sale FindSaleById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Sales Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    int productId = int.Parse(dr[1].ToString());
                    int count = int.Parse(dr[2].ToString());
                    float price = float.Parse(dr[3].ToString());
                    DateTime dateTime = DateTime.Parse(dr[4].ToString());
                    int sellerId = int.Parse(dr[5].ToString());

                    return new Sale
                    {
                        Id = id,
                        Product = FindProductById(productId),
                        Count = count,
                        Price = price,
                        Datetime = dateTime,
                        Seller = FindSellerById(sellerId)
                    };
                }
                throw new Exception("Required sale is absent!");
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
