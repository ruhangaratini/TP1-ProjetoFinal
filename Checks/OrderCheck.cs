using LitePDV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Checks
{
    class OrderCheck
    {
        //private readonly OrderRepository _repository;
        // test insert
        //try
        //{
        //    var order = orderService.GetById(2);
        //    Console.WriteLine($"ID: {order.id}, Data: {order.date}, totalValue: {order.totalValue}, Método de pagamento: {order.paymentMethod}, Cliente: {order.client.name}");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar o pedido por id: {ex.Message}");
        //}

        //orderService.Insert(newOrder);

        // test get by id
        //try
        //{
        //    var order = orderService.GetById(1);
        //    Console.WriteLine($"ID: {order.id}, Data: {order.date}, totalValue: {order.totalValue}, Método de pagamento: {order.paymentMethod}");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar o pedido por id: {ex.Message}");
        //}

        // teste update
        //var orderUpdated = new Order
        //(
        //    id: 1,
        //    totalValue: "10500",
        //    paymentMethod: "Money"
        //);

        //    try
        //    {
        //        orderService.Update(orderUpdated);
        //        Console.WriteLine("Pedido atualizado com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao atualizar o pedido: {ex.Message}");
        //    }

        // teste get all
        //try
        //{
        //    var orders = orderService.GetAll();

        //    Console.WriteLine("Pedidos disponíveis:");
        //    foreach (var order in orders)
        //    {
        //        Console.WriteLine($"ID: {order.id}, Data: {order.date}, Valor total: {order.totalValue}, Método de pagamento: {order.paymentMethod}");

        //        Console.WriteLine("Itens do pedido:");
        //        foreach (var item in order.items)
        //        {
        //            Console.WriteLine($"- Produto ID: {item.idProduct}, Quantidade: {item.quantity}, Preço unitário: {item.unitPrice}, Subtotal: {item.subtotal}");
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar os pedidos: {ex.Message}");
        //}


        // delete
        //try
        //{
        //    bool order = orderService.DeleteById(6);

        //    if (order)
        //    {
        //        Console.WriteLine("Pedido deletado com sucesso");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Não existe pedido com o ID informado. Verifique e tente novamente.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao deletar o ordere: {ex.Message}");
        //}
    }
}
