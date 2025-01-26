using LitePDV.Model;
using LitePDV.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Checks
{
    internal class ClientCheck
    {
        //var clientService = new ClientService();

        //// teste insert 
        //var newClient = new Client
        //(
        //    name: "Mary Doe",
        //    email: "jane@email.com",
        //    phone: "3333-6060",
        //    smartphone: "9999-9999",
        //    cpf: "33333300090",
        //    rg: "909990008"
        //);

        //    try
        //    {
        //        clientService.Insert(newClient);
        //        Console.WriteLine("Cliente inserido com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao inserir o cliente: {ex.Message}");
        //    }

        // test get by id
        //try
        //{
        //    var client = clientService.GetById(1);
        //    Console.WriteLine($"ID: {client.id}, Nome: {client.name}, Email: {client.email}, Telefone: {client.phone}, Celular: {client.smartphone}, CPF: {client.cpf}, RG: {client.rg}");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar o cliente por id: {ex.Message}");
        //}

        // teste update
        //var clientUpdated = new Client
        //(
        //    id: 1,
        //    name: "Johnny",
        //    email: "johnny@email.com",
        //    phone: "3333-6060",
        //    smartphone: "9999-9999",
        //    cpf: "33333300090",
        //    rg: "909990008"
        //);

        //    try
        //    {
        //        clientService.Update(clientUpdated);
        //        Console.WriteLine("Cliente atualizado com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao atualizar o cliente: {ex.Message}");
        //    }

        // teste get all
        //try
        //{
        //    var clients = clientService.GetAll();

        //    Console.WriteLine("Clientes disponíveis:");
        //    foreach (var client in clients)
        //    {
        //        Console.WriteLine($"ID: {client.id}, Nome: {client.name}, Email: {client.email}, Telefone: {client.phone}, Celular: {client.smartphone}, CPF: {client.cpf}, RG: {client.rg}");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar os clientes: {ex.Message}");
        //}


        // delete
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
