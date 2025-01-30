using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Model
{
    class Order
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public double totalValue { get; set; }
        public string paymentMethod { get; set; }
        public Client client { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();

        public Order()
        {
            items = new List<OrderItem>();
        }

        public Order(int id, DateTime date, double totalValue, string paymentMethod, List<OrderItem> items, Client client)
        {
            this.id = id;
            this.date = date;
            this.totalValue = totalValue;
            this.paymentMethod = paymentMethod;
            this.items = items;
            this.client = client;
        }

        public Order(int id, double totalValue, string paymentMethod)
        {
            this.id = id;
            this.totalValue = totalValue;
            this.paymentMethod = paymentMethod;
        }

    }
}
