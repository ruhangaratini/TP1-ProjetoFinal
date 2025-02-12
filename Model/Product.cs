﻿using LitePDV.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Model
{
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stockQuantity { get; set; }
        public string category { get; set; }

        public Product() { }

        public Product(int id, string name, string description, double price, int stockQuantity, string category)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.stockQuantity = stockQuantity;
            this.category = category;
        }

        public Product(string name, string description, double price, int stockQuantity, string category)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.stockQuantity = stockQuantity;
            this.category = category;
        }
    }
}