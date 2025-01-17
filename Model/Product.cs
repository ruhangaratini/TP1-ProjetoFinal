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
        public bool status { get; set; }

        public Product(int id, string name, string description, double price, int stockQuantity, bool status)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.stockQuantity = stockQuantity;
            this.status = status;
        }

        public Product(string name, string description, double price, int stockQuantity, bool status)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.stockQuantity = stockQuantity;
            this.status = status;
        }
    }
}
