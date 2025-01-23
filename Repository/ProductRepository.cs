using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitePDV.Model;

namespace LitePDV.Repository
{
    class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(Product produto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = "INSERT INTO PRODUCT (name, description, price, stockQuantity, status) VALUES(@name, @description, @price, @stockQuantity, @status)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", produto.name);
                    command.Parameters.AddWithValue("@description", produto.description);
                    command.Parameters.AddWithValue("@price", produto.price);
                    command.Parameters.AddWithValue("@stockQuantity", produto.stockQuantity);
                    command.Parameters.AddWithValue("@status", produto.status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}