using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DBContext db;

        public ProductRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(Product product)
        {
            if (product != null)
            {
                db.InsertProduct(product);
            }
        }

        public void Delete(Product product)
        {
            Product curProduct = this.FindById(product.Id);

            if (curProduct != null)
            {
                db.DropProduct(product);
                db.Products.Remove(curProduct);
            }
        }

        public Product FindById(int id)
        {
            foreach (Product curProduct in this.GetAll())
            {
                if (curProduct.Id == id)
                    return curProduct;
            }
            return null;
        }

        public List<Product> GetAll()
        {
            return db.Products;
        }

        public void GetNewAll()
        {
            db.GetProductsFromDatabase();
        }

        public void Update(Product product)
        {
            if (product != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Products[i].Id == product.Id)
                    {
                        db.Products[i].Unit = product.Unit;
                        db.Products[i].Category = product.Category;
                        db.Products[i].Class = product.Class;
                        db.Products[i].TareChange = product.TareChange;
                        db.Products[i].Count = product.Count;
                        db.Products[i].ExpirationDate = product.ExpirationDate;
                        db.Products[i].ArrivedGoods = product.ArrivedGoods;
                        db.Products[i].PurchasePrice = product.PurchasePrice;
                        db.Products[i].SalesPrice = product.SalesPrice;
                        db.Products[i].Returned = product.Returned;
                        db.Products[i].ReturnedDate = product.ReturnedDate;
                        db.Products[i].WritenOff = product.WritenOff;
                    }
                }
                db.UpdateProduct(product);
            }
        }
    }
}
