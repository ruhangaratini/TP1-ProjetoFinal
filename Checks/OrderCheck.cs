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
        //var newOrder = new Order
        //(
        //    totalValue: 2000,
        //    paymentMethod: "Credit Card",
        //    idClient: 1
        //);

        //newOrder.items.Add(new OrderItem
        //(
        //    id: 0,
        //    quantity: 2,
        //    unitPrice: 500,
        //    subtotal: 1000,
        //    idProduct: 1,
        //    idOrder: 0    
        //));

        //newOrder.items.Add(new OrderItem
        //(
        //    id: 0,
        //    quantity: 1,
        //    unitPrice: 1000,
        //    subtotal: 1000,
        //    idProduct: 2,
        //    idOrder: 0
        //));

        //orderService.Insert(newOrder);

        //try
        //{
        //    orderService.Insert(newOrder);
        //    Console.WriteLine("Pedido inserido com sucesso!");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao inserir o pedido: {ex.Message}");
        //}

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
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar os pedidos: {ex.Message}");
        //}


        // delete
        //try
        //{
        //    bool order = orderService.DeleteById(3);

        //    if (order)
        //    {
        //        Console.WriteLine("Cliente deletado com sucesso");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Não existe ordere com o ID informado. Verifique e tente novamente.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao deletar o ordere: {ex.Message}");
        //}
    }
}
