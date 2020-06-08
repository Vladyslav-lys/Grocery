using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private DBContext db;

        public SellerRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(Seller seller)
        {
            if (seller != null)
            {
                db.InsertSeller(seller);
            }
        }

        public void Delete(Seller seller)
        {
            Seller curSeller = this.FindById(seller.Id);

            if (curSeller != null)
            {
                db.DropSeller(seller);
                db.Sellers.Remove(curSeller);
            }
        }

        public Seller FindById(int id)
        {
            foreach (Seller curSeller in this.GetAll())
            {
                if (curSeller.Id == id)
                    return curSeller;
            }
            return null;
        }

        public List<Seller> GetAll()
        {
            return db.Sellers;
        }

        public void GetNewAll()
        {
            db.GetSellersFromDatabase();
        }

        public void Update(Seller seller)
        {
            if (seller != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Sellers[i].Id == seller.Id)
                    {
                        db.Sellers[i].Surname = seller.Surname;
                        db.Sellers[i].FirstName = seller.FirstName;
                        db.Sellers[i].SecondName = seller.SecondName;
                        db.Sellers[i].PassportSeries = seller.PassportSeries;
                        db.Sellers[i].PassportNumber = seller.PassportNumber;
                        db.Sellers[i].TIN = seller.TIN;
                        db.Sellers[i].BirthDate = seller.BirthDate;
                        db.Sellers[i].PhoneNumber = seller.PhoneNumber;
                        db.Sellers[i].Address = seller.Address;
                        db.Sellers[i].Department = seller.Department;
                        db.Sellers[i].User = seller.User;
                        db.Sellers[i].Fired = seller.Fired;
                        db.Sellers[i].FiredDate = seller.FiredDate;
                    }
                }
                db.UpdateSeller(seller);
            }
        }
    }
}
