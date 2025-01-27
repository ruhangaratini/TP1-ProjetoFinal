//using LitePDV.Model;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Data.SqlOrder;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LitePDV.Repository
//{
//    class OrderRepository
//    {
//        private readonly string _connectionString;

//        public OrderRepository()
//        {
//            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
//        }

//        public List<Order> GetAll()
//        {
//            try
//            {
//                var orders = new List<Order>();

//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    const string query = "SELECT * FROM ORDERS";

//                    using (var command = new SqlCommand(query, connection))
//                    {
//                        connection.Open();

//                        using (var response = command.ExecuteReader())
//                        {
//                            while (response.Read())
//                            {
//                                var order = new Order
//                                (
//                                    id: Convert.ToInt32(response["id"]),
//                                    name: response["name"].ToString(),
//                                    email: response["email"].ToString(),
//                                    phone: response["phone"].ToString(),
//                                    smartphone: response["smartphone"].ToString(),
//                                    cpf: response["cpf"].ToString(),
//                                    rg: response["rg"].ToString()
//                                );

//                                orders.Add(order);
//                            }
//                        }

//                        connection.Close();
//                    }
//                }

//                return orders;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Erro ao buscar todos os orderes: {ex}");
//            }
//        }

//        public Order GetById(int id)
//        {
//            try
//            {
//                Order order = null;

//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    const string query = "SELECT * FROM CLIENT WHERE id = @id";

//                    using (var command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@id", id);

//                        connection.Open();

//                        using (var reader = command.ExecuteReader())
//                        {
//                            if (reader.Read())
//                            {
//                                order = new Order
//                                (
//                                    id: Convert.ToInt32(reader["id"]),
//                                    name: reader["name"].ToString(),
//                                    email: reader["email"].ToString(),
//                                    phone: reader["phone"].ToString(),
//                                    smartphone: reader["smartphone"].ToString(),
//                                    cpf: reader["phone"].ToString(),
//                                    rg: reader["phone"].ToString()
//                                );
//                            }
//                        }

//                        connection.Close();
//                    }
//                }

//                return order;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Erro ao buscar o ordere por id: {ex.Message}", ex);
//            }
//        }

//        public void Insert(Order order)
//        {
//            try
//            {
//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    const string query = "INSERT INTO CLIENT (name, email, phone, smartphone, cpf, rg) VALUES(@name, @email, @phone, @smartphone, @cpf, @rg)";

//                    using (var command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@name", order.name);
//                        command.Parameters.AddWithValue("@email", order.email);
//                        command.Parameters.AddWithValue("@phone", order.phone);
//                        command.Parameters.AddWithValue("@smartphone", order.smartphone);
//                        command.Parameters.AddWithValue("@cpf", order.cpf);
//                        command.Parameters.AddWithValue("@rg", order.rg);

//                        connection.Open();
//                        command.ExecuteNonQuery();
//                        connection.Close();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Erro ao inserir o ordere: {ex}");
//            }
//        }

//        public void Update(Order order) // verificar para casos de atualizações parciais
//        {
//            try
//            {
//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    const string query = "UPDATE CLIENT SET name = @name, email = @email, phone = @phone, smartphone = @smartphone, cpf = @cpf, rg = @rg WHERE id = @id";

//                    using (var command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@name", order.name);
//                        command.Parameters.AddWithValue("@email", order.email);
//                        command.Parameters.AddWithValue("@phone", order.phone);
//                        command.Parameters.AddWithValue("@smartphone", order.smartphone);
//                        command.Parameters.AddWithValue("@cpf", order.cpf);
//                        command.Parameters.AddWithValue("@rg", order.rg);
//                        command.Parameters.AddWithValue("@id", order.id);

//                        connection.Open();
//                        command.ExecuteNonQuery();
//                        connection.Close();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Erro ao atualizar o ordere: {ex}");
//            }
//        }

//        public bool DeleteById(int id)
//        {
//            try
//            {
//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    const string query = "DELETE FROM CLIENT WHERE id = @id";

//                    using (var command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@id", id);

//                        connection.Open();
//                        command.ExecuteNonQuery();
//                        connection.Close();
//                    }
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Erro ao deletar o ordere por id: {ex.Message}", ex);
//            }
//        }

//    }
//}
