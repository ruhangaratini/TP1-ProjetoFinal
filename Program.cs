using LitePDV.Model;
using LitePDV.Repository;
using LitePDV.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LitePDV
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            var orderService = new OrderService();

            var newOrder = new Order
            (
                paymentMethod: "Credit Card",
                idClient: 1
            );

            newOrder.items.Add(new OrderItem
            (
                id: 0,
                quantity: 2,
                unitPrice: 500,
                subtotal: 1000,
                idProduct: 1,
                idOrder: 0
            ));

            newOrder.items.Add(new OrderItem
            (
                id: 0,
                quantity: 2,
                unitPrice: 600,
                subtotal: 1200,
                idProduct: 2,
                idOrder: 0
            ));

            orderService.Insert(newOrder);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LitePDV());
        }

    }
}
