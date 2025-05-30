﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales_Web_MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller sr) => Sellers.Add(sr);
        public void RemoveSeller(Seller sr) => Sellers.Remove(sr);
        public double TotalSales(DateTime initial, DateTime final)
            => Sellers.Sum(seller => seller.TotalSales(initial, final));
    }
}
