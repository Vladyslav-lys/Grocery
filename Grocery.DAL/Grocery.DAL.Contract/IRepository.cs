using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.DAL.Contract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void GetNewAll();
        T FindById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
