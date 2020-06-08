using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private DBContext db;

        public SaleRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(Sale sale)
        {
            if (sale != null)
            {
                db.InsertSale(sale);
            }
        }

        public void Delete(Sale sale)
        {
            Sale curSale = this.FindById(sale.Id);

            if (curSale != null)
            {
                db.DropSale(sale);
                db.Sales.Remove(curSale);
            }
        }

        public Sale FindById(int id)
        {
            foreach (Sale curSale in this.GetAll())
            {
                if (curSale.Id == id)
                    return curSale;
            }
            return null;
        }

        public List<Sale> GetAll()
        {
            return db.Sales;
        }

        public void GetNewAll()
        {
            db.GetSalesFromDatabase();
        }

        public void Update(Sale sale)
        {
            if (sale != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Sales[i].Id == sale.Id)
                    {
                        db.Sales[i].Product = sale.Product;
                        db.Sales[i].Count = sale.Count;
                        db.Sales[i].Price = sale.Price;
                        db.Sales[i].Datetime = sale.Datetime;
                        db.Sales[i].Seller = sale.Seller;
                    }
                }
                db.UpdateSale(sale);
            }
        }
    }
}
