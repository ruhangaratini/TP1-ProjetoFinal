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
            var clientUpdated = new Client
            (
                id: 2,
                name: "Johnny Doe",
                email: "johnny@email.com",
                phone: "3333-6060",
                smartphone: "9999-9999",
                cpf: "33333300090",
                rg: "909990008"
            );

            try
            {
                clientService.Update(clientUpdated);
                Console.WriteLine("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o cliente: {ex.Message}");
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LitePDV());
        }

    }
}
