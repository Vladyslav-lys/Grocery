using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Contract;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Activities
{
    public class GetDepartmentActivity : IGetDepartmentActivity
    {
        private IDepartmentRepository departmentRepository;

        public GetDepartmentActivity(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public List<Department> Run()
        {
            List<Department> departments = new List<Department>();

            departmentRepository.GetNewAll();
            foreach (Department curDepartment in departmentRepository.GetAll())
            {
                Department department = new Department()
                {
                    Id = curDepartment.Id,
                    Number = curDepartment.Number,
                    Address = curDepartment.Address
                };

                departments.Add(department);
            }
            
            return departments;
        }
    }
}
