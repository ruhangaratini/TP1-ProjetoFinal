using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Service
{
    class InitDatabaseService
    {
        private readonly string _connectionString;

        public InitDatabaseService()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void InitializeDatabase()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    ExecuteQuery(connection, @"
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

                    ExecuteQuery(connection, @"
                        CREATE TABLE PRODUCT (
                            id INT PRIMARY KEY IDENTITY,
                            name VARCHAR(100) NOT NULL,
                            description VARCHAR(255) NOT NULL,
                            price NUMERIC(18, 2) NOT NULL,
                            stockQuantity INT,
                            category VARCHAR(100)
                        );
                    ");

                    ExecuteQuery(connection, @"
                        CREATE TABLE ORDERS (
                            id INT PRIMARY KEY IDENTITY,
                            date DATETIME NOT NULL,
                            totalValue NUMERIC(18, 2) NOT NULL,
                            paymentMethod VARCHAR(20) NOT NULL,
                            idClient INT,
                            FOREIGN KEY (idClient) REFERENCES CLIENT(id)
                        );
                    ");

                    ExecuteQuery(connection, @"
                        CREATE TABLE ORDER_ITEMS (
                            quantity INT NOT NULL,
                            unitPrice NUMERIC(18, 2) NOT NULL,
                            subtotal NUMERIC(18, 2) NOT NULL,
                            idProduct INT NOT NULL,
                            idOrder INT NOT NULL,
                            PRIMARY KEY (idProduct, idOrder),
                            FOREIGN KEY (idProduct) REFERENCES PRODUCT(id),
                            FOREIGN KEY (idOrder) REFERENCES ORDERS(id)
                        );
                    ");

                    Console.WriteLine("Tabelas criadas com sucesso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Falha ao iniciar o banco: {ex.Message}");
                }
            }
        }

        private void ExecuteQuery(SqlConnection connection, string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
