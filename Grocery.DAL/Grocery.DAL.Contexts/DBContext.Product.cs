using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using System.Data.SqlClient;

namespace Grocery.DAL.Contexts
{
    public partial class DBContext
    {
        private List<Product> products;

        public List<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public void GetProductsFromDatabase()
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Products", con);
                SqlDataReader dr = sqlCom.ExecuteReader();
                this.products = new List<Product>();

                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string unit = dr[1].ToString();
                    int categoryId = int.Parse(dr[2].ToString());
                    int classId = int.Parse(dr[3].ToString());
                    int tareChangeId = int.Parse(dr[4].ToString());
                    int count = int.Parse(dr[5].ToString());
                    DateTime expirationDate = DateTime.Parse(dr[6].ToString());
                    int arrivedGoodsId = int.Parse(dr[7].ToString());
                    float purchasePrice = float.Parse(dr[8].ToString());
                    float salesPrice = float.Parse(dr[9].ToString());
                    bool returned = bool.Parse(dr[10].ToString());
                    DateTime? returnedDate = string.IsNullOrEmpty(dr[11].ToString()) ? (DateTime?)null : DateTime.Parse(dr[11].ToString());
                    bool writenOff = bool.Parse(dr[12].ToString());

                    this.Products.Add(new Product
                    {
                        Id = id,
                        Unit = unit,
                        Category = new Category { Id=categoryId, Name="" },
                        Class = new Class { Id=classId, Name=""},
                        TareChange = new TareChange { Id=tareChangeId, Name=""},
                        Count = count,
                        ExpirationDate = expirationDate,
                        ArrivedGoods = new ArrivedGoods { Id=arrivedGoodsId, AllPurchasePrice=0.0f, AllSalesPrice=0.0f, Count=0, DateTime=new DateTime(), Department=null, Provider=null, Seller=null},
                        PurchasePrice = purchasePrice,
                        SalesPrice = salesPrice,
                        Returned = returned,
                        ReturnedDate = returnedDate,
                        WritenOff = writenOff
                    });
                }

                foreach (Product product in products)
                {
                    product.Category = FindCategoryById(product.Category.Id);
                    product.Class = FindClassById(product.Class.Id);
                    product.TareChange = FindTareChangeById(product.TareChange.Id);
                    product.ArrivedGoods = FindArrivedGoodsById(product.ArrivedGoods.Id);
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

        public void InsertProduct(Product product)
        {
            try
            {
                this.OpenConnection();
                string comand = "Insert Into Products(unit, IDCATEGORIES, IDCLASSES, ID_TARE_CHANGES, COUNT, EXPIRATION_DATE, ID_ARRIVED_GOODS, PURCHASE_PRICE, SALES_PRICE, RETURNED, RETURNED_DATE, WRITEN_OFF) " +
                    "Values(@unit, @idcategories, @idclasses, @id_tare_changes, @count, @expiration_date, @id_arrived_goods, @purchase_price, @sales_price, @returned, @returned_date, @writen_off)";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@unit", product.Unit);
                sqlCom.Parameters.AddWithValue("@idcategories", product.Category.Id);
                sqlCom.Parameters.AddWithValue("@idclasses", product.Class.Id);
                sqlCom.Parameters.AddWithValue("@id_tare_changes", product.TareChange.Id);
                sqlCom.Parameters.AddWithValue("@count", product.Count);
                sqlCom.Parameters.AddWithValue("@expiration_date", product.ExpirationDate);
                sqlCom.Parameters.AddWithValue("@id_arrived_goods", product.ArrivedGoods.Id);
                sqlCom.Parameters.AddWithValue("@purchase_price", product.PurchasePrice);
                sqlCom.Parameters.AddWithValue("@sales_price", product.SalesPrice);
                sqlCom.Parameters.AddWithValue("@returned", product.Returned);
                sqlCom.Parameters.AddWithValue("@returned_date", product.ReturnedDate.ToString());
                sqlCom.Parameters.AddWithValue("@writen_off", product.WritenOff);
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

        public void DropProduct(Product product)
        {
            try
            {
                this.OpenConnection();
                string comand = "delete from Products where id = '" + product.Id.ToString() + "'";
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

        public void UpdateProduct(Product product)
        {
            try
            {
                this.OpenConnection();
                string comand = "Update Products Set unit=@unit, idcategories=@idcategories, idclasses=@idclasses, id_tare_changes=@id_tare_changes, " +
                    "count=@count, expiration_date=@expiration_date, id_arrived_goods=@id_arrived_goods, purchase_price=@purchase_price, " +
                    "sales_price=@sales_price, returned=@returned, returned_date=@returned_date, writen_off=@writen_off Where Id=@Id";
                SqlCommand sqlCom = new SqlCommand(comand, con);
                sqlCom.Parameters.AddWithValue("@Id", product.Id);
                sqlCom.Parameters.AddWithValue("@unit", product.Unit);
                sqlCom.Parameters.AddWithValue("@idcategories", product.Category.Id);
                sqlCom.Parameters.AddWithValue("@idclasses", product.Class.Id);
                sqlCom.Parameters.AddWithValue("@id_tare_changes", product.TareChange.Id);
                sqlCom.Parameters.AddWithValue("@count", product.Count);
                sqlCom.Parameters.AddWithValue("@expiration_date", product.ExpirationDate);
                sqlCom.Parameters.AddWithValue("@id_arrived_goods", product.ArrivedGoods.Id);
                sqlCom.Parameters.AddWithValue("@purchase_price", product.PurchasePrice);
                sqlCom.Parameters.AddWithValue("@sales_price", product.SalesPrice);
                sqlCom.Parameters.AddWithValue("@returned", product.Returned);
                sqlCom.Parameters.AddWithValue("@returned_date", product.ReturnedDate.ToString());
                sqlCom.Parameters.AddWithValue("@writen_off", product.WritenOff);
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

        public Product FindProductById(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Products Where Id=@Id", con);
                sqlCom.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = sqlCom.ExecuteReader();

                while (dr.Read())
                {
                    string unit = dr[1].ToString();
                    int categoryId = int.Parse(dr[2].ToString());
                    int classId = int.Parse(dr[3].ToString());
                    int tareChangeId = int.Parse(dr[4].ToString());
                    int count = int.Parse(dr[5].ToString());
                    DateTime expirationDate = DateTime.Parse(dr[6].ToString());
                    int arrivedGoodsId = int.Parse(dr[7].ToString());
                    float purchasePrice = float.Parse(dr[8].ToString());
                    float salesPrice = float.Parse(dr[9].ToString());
                    bool returned = bool.Parse(dr[10].ToString());
                    DateTime? returnedDate = string.IsNullOrEmpty(dr[11].ToString()) ? (DateTime?)null : DateTime.Parse(dr[11].ToString());
                    bool writenOff = bool.Parse(dr[12].ToString());

                    return new Product
                    {
                        Id = id,
                        Unit = unit,
                        Category = FindCategoryById(categoryId),
                        Class = FindClassById(classId),
                        TareChange = FindTareChangeById(tareChangeId),
                        Count = count,
                        ExpirationDate = expirationDate,
                        ArrivedGoods = FindArrivedGoodsById(arrivedGoodsId),
                        PurchasePrice = purchasePrice,
                        SalesPrice = salesPrice,
                        Returned = returned,
                        ReturnedDate = returnedDate,
                        WritenOff = writenOff
                    };
                }
                throw new Exception("Required product is absent!");
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
