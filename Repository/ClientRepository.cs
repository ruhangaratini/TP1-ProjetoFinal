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
    internal class ClientRepository : IRepository<Client>
    {
        private readonly string _connectionString;

        public ClientRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Client> GetAll()
        {
            try
            {
                var clients = new List<Client>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT * FROM CLIENT";

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var response = command.ExecuteReader())
                        {
                            while (response.Read())
                            {
                                var client = new Client
                                (
                                    id: Convert.ToInt32(response["id"]),
                                    name: response["name"].ToString(),
                                    email: response["email"].ToString(),
                                    phone: response["phone"].ToString(),
                                    smartphone: response["smartphone"].ToString(),
                                    cpf: response["cpf"].ToString(),
                                    rg: response["rg"].ToString()
                                );

                                clients.Add(client);
                            }
                        }

                        connection.Close();
                    }
                }

                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os clientes: {ex}");
            }
        }

        public Client GetById(int id)
        {
            try
            {
                Client client = null;

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT * FROM CLIENT WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                client = new Client
                                (
                                    id: Convert.ToInt32(reader["id"]),
                                    name: reader["name"].ToString(),
                                    email: reader["email"].ToString(),
                                    phone: reader["phone"].ToString(),
                                    smartphone: reader["smartphone"].ToString(),
                                    cpf: reader["phone"].ToString(),
                                    rg: reader["phone"].ToString()
                                );
                            }
                        }

                        connection.Close();
                    }
                }

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar o cliente por id: {ex.Message}", ex);
            }
        }

        public void Insert(Client client)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "INSERT INTO CLIENT (name, email, phone, smartphone, cpf, rg) VALUES(@name, @email, @phone, @smartphone, @cpf, @rg)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", client.name);
                        command.Parameters.AddWithValue("@email", client.email);
                        command.Parameters.AddWithValue("@phone", client.phone);
                        command.Parameters.AddWithValue("@smartphone", client.smartphone);
                        command.Parameters.AddWithValue("@cpf", client.cpf);
                        command.Parameters.AddWithValue("@rg", client.rg);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir o cliente: {ex}");
            }
        }

        public void Update(Client client) // verificar para casos de atualizações parciais
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "UPDATE CLIENT SET name = @name, email = @email, phone = @phone, smartphone = @smartphone, cpf = @cpf, rg = @rg WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", client.name);
                        command.Parameters.AddWithValue("@email", client.email);
                        command.Parameters.AddWithValue("@phone", client.phone);
                        command.Parameters.AddWithValue("@smartphone", client.smartphone);
                        command.Parameters.AddWithValue("@cpf", client.cpf);
                        command.Parameters.AddWithValue("@rg", client.rg);
                        command.Parameters.AddWithValue("@id", client.id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o cliente: {ex}");
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "DELETE FROM CLIENT WHERE id = @id";

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
                throw new Exception($"Erro ao deletar o cliente por id: {ex.Message}", ex);
            }
        }
    }
}
