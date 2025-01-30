using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Model
{
    class OrderItem
    {
        public int quantity {  get; set; }
        public double unitPrice { get; set; }
        public double subtotal { get; set;}
        public Product product { get; set; }
        public int idOrder { get; set; }

        public OrderItem(int quantity, double unitPrice, double subtotal, Product product, int idOrder)
        {
            this.quantity = quantity;
            this.unitPrice = unitPrice;
            this.subtotal = subtotal;
            this.product = product;
            this.idOrder = idOrder;
        }
    }
}
