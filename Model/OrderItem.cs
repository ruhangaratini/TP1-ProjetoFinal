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
        public int idProduct { get; set; }
        public int idOrder { get; set; }

        public OrderItem(int id, int quantity, double unitPrice, double subtotal, int idProduct, int idOrder)
        {
            this.idOrder = id;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
            this.subtotal = subtotal;
            this.idProduct = idProduct;
            this.idOrder = idOrder;
        }
    }
}
