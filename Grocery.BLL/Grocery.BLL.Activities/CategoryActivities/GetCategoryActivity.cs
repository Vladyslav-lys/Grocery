using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetCategoryActivity : IGetCategoryActivity
    {
        private ICategoryRepository categoryRepository;

        public GetCategoryActivity(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> Run()
        {
            List<Category> categories = new List<Category>();

            categoryRepository.GetNewAll();
            foreach (Category curCategory in categoryRepository.GetAll())
            {
                Category category = new Category()
                {
                    Id = curCategory.Id,
                    Name = curCategory.Name
                };

                categories.Add(category);
            }

            return categories;
        }
    }
}
