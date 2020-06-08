using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DBContext db;

        public CategoryRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(Category category)
        {
            if (category != null)
            {
                db.InsertCategory(category);
            }
        }

        public void Delete(Category category)
        {
            Category curCategory = this.FindById(category.Id);

            if (curCategory != null)
            {
                db.DropCategory(category);
                db.Categories.Remove(curCategory);
            }
        }

        public Category FindById(int id)
        {
            foreach (Category curCategory in this.GetAll())
            {
                if (curCategory.Id == id)
                    return curCategory;
            }
            return null;
        }

        public List<Category> GetAll()
        {
            return db.Categories;
        }

        public void GetNewAll()
        {
            db.GetCategoriesFromDatabase();
        }

        public void Update(Category category)
        {
            if (category != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Categories[i].Id == category.Id)
                    {
                        db.Categories[i].Name = category.Name;
                    }
                }
                db.UpdateCategory(category);
            }
        }
    }
}
