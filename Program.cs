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
            //teste insert
            var productService = new ProductService();
            var clientService = new ClientService();
            var orderService = new OrderService();
            var initDatabaseService = new InitDatabaseService();

            //initDatabaseService.InitializeDatabase();
            try
            {
                bool product = productService.DeleteById(2);

                if (product)
                {
                    Console.WriteLine("Produto deletado com sucesso");
                }
                else
                {
                    Console.WriteLine("Não existe produto com o ID informado. Verifique e tente novamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o produto: {ex.Message}");
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LitePDV());
        }

    }
}
