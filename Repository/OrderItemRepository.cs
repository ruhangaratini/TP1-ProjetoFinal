using LitePDV.Checks;
using LitePDV.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Repository
{
    class OrderItemRepository
    {
        private readonly string _connectionString;

        public OrderItemRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<OrderItem> GetAll()
        {
            try
            {
                var orderItems = new List<OrderItem>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT * FROM ORDERS_ITEMS";

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var response = command.ExecuteReader())
                        {
                            while (response.Read())
                            {
                                var orderItem = new OrderItem
                                (
                                    id: Convert.ToInt32(response["id"]),
                                    quantity: Convert.ToInt32(response["quantity"]),
                                    unitPrice: Convert.ToDouble(response["unitPrice"]),
                                    subtotal: Convert.ToDouble(response["subtotal"]),
                                    idProduct: Convert.ToInt32(response["idProduct"]),
                                    idOrder: Convert.ToInt32(response["idOrder"])
                                );

                                orderItems.Add(orderItem);
                            }
                        }

                        connection.Close();
                    }
                }

                return orderItems;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os itens dos pedidos: {ex}");
            }
        }

        public OrderItem GetById(int id)
        {
            try
            {
                OrderItem orderItem = null;

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT * FROM ORDERS_ITEMS WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                orderItem = new OrderItem
                                (
                                    id: Convert.ToInt32(reader["id"]),
                                    quantity: Convert.ToInt32(reader["quantity"]),
                                    unitPrice: Convert.ToDouble(reader["unitPrice"]),
                                    subtotal: Convert.ToDouble(reader["subtotal"]),
                                    idProduct: Convert.ToInt32(reader["idProduct"]),
                                    idOrder: Convert.ToInt32(reader["idOrder"])
                                );
                            }
                        }

                        connection.Close();
                    }
                }

                return orderItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar os itens do pedido por id: {ex.Message}", ex);
            }
        }

        public void Insert(OrderItem orderItem)
        {
            double subtotal = orderItem.quantity * orderItem.unitPrice;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "INSERT INTO ORDERS_ITEMS (quantity, unitPrice, subtotal, idProduct, idOrder) VALUES(@quantity, @unitPrice, @subtotal, @idProduct, @idOrder)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@quantity", orderItem.quantity);
                        command.Parameters.AddWithValue("@unitPrice", orderItem.unitPrice);
                        command.Parameters.AddWithValue("@subtotal", subtotal);
                        command.Parameters.AddWithValue("@idProduct", orderItem.idProduct);
                        command.Parameters.AddWithValue("@idOrder", orderItem.idOrder);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir os itens do pedido: {ex}");
            }
        }

        public void Update(OrderItem orderItem) 
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "UPDATE ORDERS SET quantity = @quantity, unitPrice = @unitPrice WHERE idProduct = @idProduct && idOrder = @idOrder";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@quantity", orderItem.quantity);
                        command.Parameters.AddWithValue("@unitPrice", orderItem.unitPrice);
                        command.Parameters.AddWithValue("@idProduct", orderItem.idProduct);
                        command.Parameters.AddWithValue("@idOrder", orderItem.idOrder);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar os itens do pedido: {ex}");
            }
        }

        public bool DeleteById(int idProduct, int idOrder)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "DELETE FROM ORDERS WHERE idProduct = @idProduct && idOrder = @idOrder";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProduct", idProduct);
                        command.Parameters.AddWithValue("@idOrder", idOrder);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar o item do pedido: {ex.Message}", ex);
            }
        }

    }
}
