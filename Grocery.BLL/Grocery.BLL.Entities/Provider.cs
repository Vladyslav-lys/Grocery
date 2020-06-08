using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
