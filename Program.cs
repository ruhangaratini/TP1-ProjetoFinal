using LitePDV.Model;
using LitePDV.Repository;
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
        [STAThread]
        static void Main()
        {
            //var productRepository = new ProductRepository();

            //var novoProduto = new Product
            //(
            //    name: "teste",
            //    description: "teste",
            //    price: 100.00,
            //    stockQuantity: 10,
            //    status: true
            //);

            //productRepository.Insert(novoProduto);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LitePDV());
        }
    }
}
