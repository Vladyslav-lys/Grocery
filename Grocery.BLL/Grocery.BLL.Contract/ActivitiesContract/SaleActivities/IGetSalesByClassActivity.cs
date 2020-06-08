using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.Contract
{
    public interface IGetSalesByClassActivity
    {
        List<Sale> Run(Class class_, DateTime sinceDate, DateTime toDate);
    }
}
