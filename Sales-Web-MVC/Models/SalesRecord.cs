using Sales_Web_MVC.Models.Enums;
using System;

namespace Sales_Web_MVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public EnumSaleStatus Status { get; set; }
        public Seller Seller { get; set; }
    }
}
