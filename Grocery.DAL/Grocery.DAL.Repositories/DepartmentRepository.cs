using System;
using System.Collections.Generic;
using System.Text;
using Grocery.DAL.Contract;
using Grocery.BLL.Entities;
using Grocery.DAL.Contexts;

namespace Grocery.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DBContext db;

        public DepartmentRepository(DBContext context)
        {
            this.db = context;
        }

        public void Create(Department department)
        {
            if (department != null)
            {
                db.InsertDepartment(department);
            }
        }

        public void Delete(Department department)
        {
            Department curDepartment = this.FindById(department.Id);

            if (curDepartment != null)
            {
                db.DropDepartment(department);
                db.Departments.Remove(curDepartment);
            }
        }

        public Department FindById(int id)
        {
            foreach (Department curDepartment in this.GetAll())
            {
                if (curDepartment.Id == id)
                    return curDepartment;
            }
            return null;
        }

        public List<Department> GetAll()
        {
            return db.Departments;
        }

        public void GetNewAll()
        {
            db.GetDepartmentsFromDatabase();
        }

        public void Update(Department department)
        {
            if (department != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Departments[i].Id == department.Id)
                    {
                        db.Departments[i].Number = department.Number;
                        db.Departments[i].Address = department.Address;
                    }
                }
                db.UpdateDepartment(department);
            }
        }
    }
}
