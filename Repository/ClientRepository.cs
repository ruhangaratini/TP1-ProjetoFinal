using LitePDV.Checks;
using LitePDV.Config;
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
    internal class ClientRepository // : IRepository<Client>
    {
        private static readonly SqlServerConfig _db = new SqlServerConfig();

        static void CreateTable()
        {
            _db.Execute(@"
                CREATE TABLE CLIENT (
                    id INT PRIMARY KEY IDENTITY,
                    name VARCHAR(100) NOT NULL,
                    email VARCHAR(100),
                    phone VARCHAR(20),
                    smartphone VARCHAR(20),
                    cpf VARCHAR(11),
                    rg VARCHAR(20)
                );
            ");
        }

        public List<Client> GetAll()
        {
            var clients = new List<Client>();
            Response<List<Dictionary<string, dynamic>>> response = _db.ExecuteQuery("SELECT * FROM CLIENT");

            if (!response.success || response.data == null)
            {
                return null;
            }

            foreach (var row in response.data)
            {
                var client = new Client
                (
                    id: Convert.ToInt32(row["id"]),
                    name: row["name"]?.ToString(),
                    email: row["email"]?.ToString(),
                    phone: row["phone"]?.ToString(),
                    smartphone: row["smartphone"]?.ToString(),
                    cpf: row["cpf"]?.ToString(),
                    rg: row["rg"]?.ToString()
                );

                clients.Add(client);
            }

            return clients;
        }


        public Client GetById(int id)
        {
            Client client = null;

            var parameter = new Dictionary<string, dynamic>
            {
                { "@id", id }
            };

            Response<List<Dictionary<string, dynamic>>> response = _db.ExecuteQuery("SELECT * FROM CLIENT WHERE id = @id", parameter);

            if (!response.success || response.data == null || response.data.Count == 0)
            {
                return null;
            }

            var row = response.data.First();

            client = new Client
            (
                id: Convert.ToInt32(row["id"]),
                name: row["name"]?.ToString(),
                email: row["email"]?.ToString(),
                phone: row["phone"]?.ToString(),
                smartphone: row["smartphone"]?.ToString(),
                cpf: row["cpf"]?.ToString(),
                rg: row["rg"]?.ToString()
            );

            return client;
        }

        public Response<int> Insert(Client client)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "@name", client.name },
                { "@email", client.email },
                { "@phone", client.phone },
                { "@smartphone", client.smartphone },
                { "@cpf", client.cpf },
                { "@rg", client.rg }
            };

            string query = "INSERT INTO CLIENT (name, email, phone, smartphone, cpf, rg) OUTPUT INSERTED.id VALUES(@name, @email, @phone, @smartphone, @cpf, @rg)";

            return _db.ExecuteQueryScalar(query, parameters);
        }


        public bool Update(Client client)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "@name", client.name },
                { "@email", client.email },
                { "@phone", client.phone },
                { "@smartphone", client.smartphone },
                { "@cpf", client.cpf },
                { "@rg", client.rg },
                { "@id", client.id }
            };

            string query = "UPDATE CLIENT SET name = @name, email = @email, phone = @phone, smartphone = @smartphone, cpf = @cpf, rg = @rg WHERE id = @id";

            Response<int> response = _db.Execute(query, parameters);

            return response.success && response.affectedRows > 0;
        }


        public bool DeleteById(int id)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "@id", id }
            };

            Response<int> response = _db.Execute("DELETE FROM CLIENT WHERE id = @id", parameters);

            return response.success && response.affectedRows > 0;
        }

    }
}
