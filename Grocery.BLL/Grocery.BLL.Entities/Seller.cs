using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public long TIN { get; set; }
        public DateTime BirthDate { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public User User { get; set; }
        public bool Fired { get; set; }
        public DateTime? FiredDate { get; set; }
    }
}
