using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.BLL.Entities
{
    public class ReportDetailed
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Class Class { get; set; }
        public int ArrivedCount { get; set; }
        public int SaledCount { get; set; }
        public int ReturnedCount { get; set; }
        public float Sum { get; set; }
        public float Revenue { get; set; }
        public float PercentRevenue { get; set; }
    }
}
