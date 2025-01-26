using LitePDV.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Checks
{
    internal class Product
    {
        //var productService = new ProductService();

        // teste insert 
        //var novoProduto = new Product
        //(
        //    name: "New insert test",
        //    description: "top product",
        //    price: 1000.00,
        //    stockQuantity: 100,
        //    status: true
        //);

        //try
        //{
        //    productRepository.Insert(novoProduto);
        //    Console.WriteLine("Produto atualizado com sucesso!");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao inserir o produto: {ex.Message}");
        //}

        // test get by id
        //try
        //{
        //    var p = productService.GetById(1);
        //    Console.WriteLine($"ID: {p.id}, Nome: {p.name}, Preço: {p.price:C}, Estoque: {p.stockQuantity}, Status: {(p.status ? "Ativo" : "Inativo")}");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar o produto por id: {ex.Message}");
        //}

        // teste update
        //var produtoAtualizado = new Product
        //(
        //    id: 1,
        //    name: "Test validate",
        //    description: "Descrição Atualizada",
        //    price: 1000,
        //    stockQuantity: 20,
        //    status: true
        //);

        //try
        //{
        //    productService.Update(produtoAtualizado);
        //    Console.WriteLine("Produto atualizado com sucesso!");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao atualizar o produto: {ex.Message}");
        //}

        //try
        //{
        //    var produtos = productService.GetAll();

        //    Console.WriteLine("Produtos disponíveis:");
        //    foreach (var produto in produtos)
        //    {
        //        Console.WriteLine($"ID: {produto.id}, Nome: {produto.name}, Preço: {produto.price:C}, Estoque: {produto.stockQuantity}, Status: {(produto.status ? "Ativo" : "Inativo")}");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao buscar os produtos: {ex.Message}");
        //}

        // delete
        //try
        //{
        //    bool product = productService.DeleteById(3);

        //    if(product)
        //    {
        //        Console.WriteLine("Produto deletado com sucesso");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Não existe produto com o ID informado. Verifique e tente novamente.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erro ao deletar o produto: {ex.Message}");
        //}
    }
}
