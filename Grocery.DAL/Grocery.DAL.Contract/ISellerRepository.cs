using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;
using Grocery.DAL.Contract;

namespace Grocery.DAL.Contract
{
    public interface ISellerRepository : IRepository<Seller>
    {
    }
}
