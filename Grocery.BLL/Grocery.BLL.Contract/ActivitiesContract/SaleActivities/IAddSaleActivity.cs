using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Contract
{
    public interface IAddSaleActivity
    {
        void Run(Product product, int count, DateTime dateTime, float price, Seller seller);
    }
}
