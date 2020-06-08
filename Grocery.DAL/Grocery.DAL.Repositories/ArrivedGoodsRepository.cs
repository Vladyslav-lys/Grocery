using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class ArrivedGoodsRepository : IArrivedGoodsRepository
    {
        private DBContext db;

        public ArrivedGoodsRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(ArrivedGoods arrivedGoods)
        {
            if (arrivedGoods != null)
            {
                db.InsertArrivedGoods(arrivedGoods);
            }
        }

        public void Delete(ArrivedGoods arrivedGoods)
        {
            ArrivedGoods curArrivedGoods = this.FindById(arrivedGoods.Id);

            if (curArrivedGoods != null)
            {
                db.DropArrivedGoods(arrivedGoods);
                db.ArrivedGoods.Remove(curArrivedGoods);
            }
        }

        public ArrivedGoods FindById(int id)
        {
            foreach (ArrivedGoods curArrivedGoods in this.GetAll())
            {
                if (curArrivedGoods.Id == id)
                    return curArrivedGoods;
            }
            return null;
        }

        public List<ArrivedGoods> GetAll()
        {
            return db.ArrivedGoods;
        }

        public void GetNewAll()
        {
            db.GetArrivedGoodsFromDatabase();
        }

        public void Update(ArrivedGoods arrivedGoods)
        {
            if (arrivedGoods != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.ArrivedGoods[i].Id == arrivedGoods.Id)
                    {
                        db.ArrivedGoods[i].Provider = arrivedGoods.Provider;
                        db.ArrivedGoods[i].Count = arrivedGoods.Count;
                        db.ArrivedGoods[i].DateTime = arrivedGoods.DateTime;
                        db.ArrivedGoods[i].AllPurchasePrice = arrivedGoods.AllPurchasePrice;
                        db.ArrivedGoods[i].AllSalesPrice = arrivedGoods.AllSalesPrice;
                        db.ArrivedGoods[i].Department = arrivedGoods.Department;
                        db.ArrivedGoods[i].Seller = arrivedGoods.Seller;
                    }
                }
                db.UpdateArrivedGoods(arrivedGoods);
            }
        }
    }
}
