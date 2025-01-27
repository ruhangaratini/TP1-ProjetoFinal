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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LitePDV());

            //var clientService = new ClientService();

            // teste delete
            //try
            //{
            //    bool client = clientService.DeleteById(3);

            //    if (client)
            //    {
            //        Console.WriteLine("Cliente deletado com sucesso");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Não existe cliente com o ID informado. Verifique e tente novamente.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Erro ao deletar o cliente: {ex.Message}");
            //}
        }

    }
}
