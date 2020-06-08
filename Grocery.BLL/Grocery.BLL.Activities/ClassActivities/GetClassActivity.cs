using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetClassActivity : IGetClassActivity
    {
        private IClassRepository classRepository;

        public GetClassActivity(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public List<Class> Run()
        {
            List<Class> classes = new List<Class>();

            classRepository.GetNewAll();
            foreach (Class curClass in classRepository.GetAll())
            {
                Class class_ = new Class()
                {
                    Id = curClass.Id,
                    Name = curClass.Name
                };

                classes.Add(class_);
            }
            
            return classes;
        }
    }
}
