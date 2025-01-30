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
                var orderDict = new Dictionary<int, Order>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = @"
                                        SELECT
                                            o.id,
                                            o.date,
                                            o.totalValue,
                                            o.paymentMethod,
                                            o.idClient,
                                            i.quantity,
                                            i.unitPrice,
                                            i.subtotal,
                                            i.idProduct,
                                            c.name AS clientName,
                                            p.name AS productName
                                        FROM ORDERS o
                                        INNER JOIN ORDER_ITEMS i ON o.id = i.idOrder
                                        INNER JOIN PRODUCT p ON p.id = i.idProduct
                                        JOIN CLIENT c ON o.idClient = c.id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var response = command.ExecuteReader())
                        {
                            while (response.Read())
                            {
                                var orderId = Convert.ToInt32(response["id"]);

                                if (!orderDict.ContainsKey(orderId))
                                {
                                    Client client = new Client();
                                    client.name = response["clientName"].ToString();

                                    var order = new Order
                                    (
                                        id: orderId,
                                        date: Convert.ToDateTime(response["date"]),
                                        totalValue: Convert.ToDouble(response["totalValue"]),
                                        paymentMethod: response["paymentMethod"].ToString(),
                                        items: new List<OrderItem>(),
                                        client: client
                                    );

                                    orderDict.Add(orderId, order);
                                    orders.Add(order);
                                }

                                Product product = new Product();
                                product.id = Convert.ToInt32(response["idProduct"]);
                                product.name = response["productName"].ToString();

                                var orderItem = new OrderItem
                                (
                                    quantity: Convert.ToInt32(response["quantity"]),
                                    unitPrice: Convert.ToDouble(response["unitPrice"]),
                                    subtotal: Convert.ToDouble(response["subtotal"]),
                                    product: product,
                                    idOrder: orderId
                                );

                                orderDict[orderId].items.Add(orderItem);
                            }
                        }

                        connection.Close();
                    }
                }

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os pedidos: {ex.Message}", ex);
            }
        }

        public Order GetById(int id)
        {
            try
            {
                Order order = null;
                var orderDict = new Dictionary<int, Order>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = @"
                SELECT
                    *,
                    c.name AS clientName,
                    p.name AS productName
                FROM ORDERS o
                LEFT JOIN ORDER_ITEMS i ON o.id = i.idOrder
                LEFT JOIN PRODUCT p ON p.id = i.idProduct
                INNER JOIN CLIENT c ON c.id = o.idClient
                WHERE o.id = @id";

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
                                    items: new List<OrderItem>(),
                                    client: new Client(
                                        id: Convert.ToInt32(reader["idClient"]),
                                        name: reader["clientName"].ToString(),
                                        email: reader["email"].ToString(),
                                        phone: reader["phone"].ToString(),
                                        smartphone: reader["smartphone"].ToString(),
                                        cpf: reader["cpf"].ToString(),
                                        rg: reader["rg"].ToString()
                                    )
                                );

                                do
                                {
                                    Product aux = new Product();
                                    aux.id = Convert.ToInt32(reader["idProduct"]);
                                    aux.name = reader["productName"].ToString();

                                    var orderItem = new OrderItem
                                    (
                                        quantity: Convert.ToInt32(reader["quantity"]),
                                        unitPrice: Convert.ToDouble(reader["unitPrice"]),
                                        subtotal: Convert.ToDouble(reader["subtotal"]),
                                        product: aux,
                                        idOrder: Convert.ToInt32(reader["id"])
                                    );

                                    order.items.Add(orderItem);
                                } while (reader.Read());
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
                        command.Parameters.AddWithValue("@idClient", order.client.id);

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
                            command.Parameters.AddWithValue("@idProduct", item.product.id);
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

        public void Update(Order order)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE ORDERS SET totalValue = @totalValue, paymentMethod = @paymentMethod, idClient = @idClient WHERE id = @id";
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@totalValue", order.totalValue);
                        command.Parameters.AddWithValue("@paymentMethod", order.paymentMethod);
                        command.Parameters.AddWithValue("@idClient", order.client.id);
                        command.Parameters.AddWithValue("@id", order.id);

                        command.ExecuteNonQuery();
                    }

                    query = "DELETE FROM ORDER_ITEMS WHERE idOrder = @id";

                    using (var command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@id", order.id);

                        command.ExecuteNonQuery();
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
                            command.Parameters.AddWithValue("@idProduct", item.product.id);
                            command.Parameters.AddWithValue("@idOrder", order.id);

                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
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
                    connection.Open();

                    const string queryOrderItem = "DELETE FROM ORDER_ITEMS WHERE idOrder = @id";

                    using (var command = new SqlCommand(queryOrderItem, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }

                    const string query = "DELETE FROM ORDERS WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
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
