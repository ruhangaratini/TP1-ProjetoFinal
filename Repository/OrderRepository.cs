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
    class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Order> GetAll()
        {
            try
            {
                var orders = new List<Order>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = @"SELECT
                                o.id,
                                o.date,
                                o.totalValue,
                                o.paymentMethod,
                                o.idClient,
                                i.quantity,
                                i.unitPrice,
                                i.subtotal,
                    FROM ORDERS o JOIN ORDER_ITEMS i ON id = idOrder";

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var response = command.ExecuteReader())
                        {
                            while (response.Read())
                            {
                                var order = new Order
                                (
                                    id: Convert.ToInt32(response["id"]),
                                    date: Convert.ToDateTime(response["date"]),
                                    totalValue: Convert.ToDouble(response["totalValue"]),
                                    paymentMethod: response["paymentMethod"].ToString(),
                                    idClient: Convert.ToInt32(response["idClient"])
                                );

                                orders.Add(order);
                            }
                        }

                        connection.Close();
                    }
                }

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os pedidos: {ex}");
            }
        }



        public Order GetById(int id)
        {
            try
            {
                Order order = null;

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT * FROM ORDERS WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new Order
                                (
                                    id: Convert.ToInt32(reader["id"]),
                                    date: Convert.ToDateTime(reader["date"]),
                                    totalValue: Convert.ToDouble(reader["totalValue"]),
                                    paymentMethod: reader["paymentMethod"].ToString(),
                                    idClient: Convert.ToInt32(reader["idClient"])
                                );
                            }
                        }

                        connection.Close();
                    }
                }

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar o pedido por id: {ex.Message}", ex);
            }
        }

        public void Insert(Order order)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    const string query = "INSERT INTO ORDERS (date, totalValue, paymentMethod, idClient) OUTPUT INSERTED.id VALUES(@date, @totalValue, @paymentMethod, @idClient)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.AddWithValue("@totalValue", order.totalValue);
                        command.Parameters.AddWithValue("@paymentMethod", order.paymentMethod);
                        command.Parameters.AddWithValue("@idClient", order.idClient);

                        order.id = (int)command.ExecuteScalar();

                    }

                    foreach (var item in order.items)
                    {
                        const string queryItem = "INSERT INTO ORDER_ITEMS (quantity, unitPrice, subtotal, idProduct, idOrder) " +
                                                 "VALUES(@quantity, @unitPrice, @subtotal, @idProduct, @idOrder)";

                        using (var command = new SqlCommand(queryItem, connection))
                        {
                            command.Parameters.AddWithValue("@quantity", item.quantity);
                            command.Parameters.AddWithValue("@unitPrice", item.unitPrice);
                            command.Parameters.AddWithValue("@subtotal", item.subtotal);
                            command.Parameters.AddWithValue("@idProduct", item.idProduct);
                            command.Parameters.AddWithValue("@idOrder", order.id);

                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir o pedido: {ex}");
            }
        }

        public void Update(Order order) // verificar para casos de atualizações parciais e campos
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "UPDATE ORDERS SET totalValue = @totalValue, paymentMethod = @paymentMethod WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@totalValue", order.totalValue);
                        command.Parameters.AddWithValue("@paymentMethod", order.paymentMethod);
                        command.Parameters.AddWithValue("@id", order.id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o pedido: {ex}");
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "DELETE FROM ORDERS WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar o pedido por id: {ex.Message}", ex);
            }
        }

    }
}
