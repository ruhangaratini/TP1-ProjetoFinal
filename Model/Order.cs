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

        public Order() { }

        public Order(int id, DateTime date, double totalValue, string paymentMethod)
        {
            this.id = id;
            this.date = date;
            this.totalValue = totalValue;
            this.paymentMethod = paymentMethod;
        }

    }
}
