using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class TareChangeRepository : ITareChangeRepository
    {
        private DBContext db;

        public TareChangeRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(TareChange tareChange)
        {
            if (tareChange != null)
            {
                db.InsertTareChange(tareChange);
            }
        }

        public void Delete(TareChange tareChange)
        {
            TareChange curTareChange = this.FindById(tareChange.Id);

            if (curTareChange != null)
            {
                db.DropTareChange(tareChange);
                db.TareChanges.Remove(curTareChange);
            }
        }

        public TareChange FindById(int id)
        {
            foreach (TareChange curTareChange in this.GetAll())
            {
                if (curTareChange.Id == id)
                    return curTareChange;
            }
            return null;
        }

        public List<TareChange> GetAll()
        {
            return db.TareChanges;
        }

        public void GetNewAll()
        {
            db.GetTareChangesFromDatabase();
        }

        public void Update(TareChange tareChange)
        {
            if (tareChange != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Sellers[i].Id == tareChange.Id)
                    {
                        db.TareChanges[i].Name = tareChange.Name;
                    }
                }
                db.UpdateTareChange(tareChange);
            }
        }
    }
}
