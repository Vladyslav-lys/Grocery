using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private DBContext db;

        public ClassRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(Class class_)
        {
            if (class_ != null)
            {
                db.InsertClass(class_);
            }
        }

        public void Delete(Class class_)
        {
            Class curClass = this.FindById(class_.Id);

            if (curClass != null)
            {
                db.DropClass(class_);
                db.Classes.Remove(curClass);
            }
        }

        public Class FindById(int id)
        {
            foreach (Class curClass in this.GetAll())
            {
                if (curClass.Id == id)
                    return curClass;
            }
            return null;
        }

        public List<Class> GetAll()
        {
            return db.Classes;
        }

        public void GetNewAll()
        {
            db.GetClassesFromDatabase();
        }

        public void Update(Class class_)
        {
            if (class_ != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Classes[i].Id == class_.Id)
                    {
                        db.Classes[i].Name = class_.Name;
                    }
                }
                db.UpdateClass(class_);
            }
        }
    }
}
