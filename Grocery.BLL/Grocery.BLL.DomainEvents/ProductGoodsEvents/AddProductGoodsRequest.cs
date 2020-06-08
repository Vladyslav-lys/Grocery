using System;
using System.Collections.Generic;
using System.Text;
using Grocery.BLL.Entities;

namespace Grocery.BLL.DomainEvents
{
    public class AddProductGoodsRequest
    {
        public string Unit { get; set; }
        public TareChange TareChange { get; set; }
        public string Count { get; set; }
        public Provider Provider { get; set; }
        public string DateTime { get; set; }
        public Category Category { get; set; }
        public Class Class { get; set; }
        public string ExpirationDate { get; set; }
        public string AllPurchasePrice { get; set; }
        public string AllSalesPrice { get; set; }
        public Department Department { get; set; }
        public Seller Seller { get; set; }
        public bool Returned { get; set; }
        public string ReturnedDate { get; set; }
        public bool WritenOff { get; set; }

        public AddProductGoodsRequest(string unit, TareChange tareChange, string count, Provider provider, string dateTime,
            Category category, Class class_, string expirationDate, string allPurchasePrice, string allSalesPrice, 
            Department department, Seller seller, bool returned, string returnedDate, bool writenOff)
        {
            this.Unit = unit;
            this.TareChange = tareChange;
            this.Count = count;
            this.Provider = provider;
            this.DateTime = dateTime;
            this.Category = category;
            this.Class = class_;
            this.ExpirationDate = expirationDate;
            this.AllPurchasePrice = allPurchasePrice;
            this.AllSalesPrice = allSalesPrice;
            this.Department = department;
            this.Seller = seller;
            this.Returned = returned;
            this.ReturnedDate = returnedDate;
            this.WritenOff = writenOff;
        }
    }
}
