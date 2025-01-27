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

        public List<Product> GetAll()
        {
            try
            {
                var products = new List<Product>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT * FROM PRODUCT";

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var response = command.ExecuteReader())
                        {
                            while (response.Read())
                            {
                                var product = new Product
                                (
                                    id: Convert.ToInt32(response["id"]),
                                    name: response["name"].ToString(),
                                    description: response["description"].ToString(),
                                    price: Convert.ToDouble(response["price"]),
                                    stockQuantity: Convert.ToInt32(response["stockQuantity"]),
                                    category: response["category"].ToString()
                                );

                                products.Add(product);
                            }
                        }

                        connection.Close();
                    }
                }

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os produtos: {ex}");
            }
        }

        public Product GetById(int id)
        {
            try
            {
                Product product = null; 

                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "SELECT id, name, description, price, stockQuantity, category FROM PRODUCT WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product
                                (
                                    id: Convert.ToInt32(reader["id"]),
                                    name: reader["name"].ToString(),
                                    description: reader["description"].ToString(),
                                    price: Convert.ToDouble(reader["price"]),
                                    stockQuantity: Convert.ToInt32(reader["stockQuantity"]),
                                    category: reader["category"].ToString()
                                );
                            }
                        }

                        connection.Close();
                    }
                }

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar o produto por id: {ex.Message}", ex);
            }
        }

        public void Insert(Product produto)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "INSERT INTO PRODUCT (name, description, price, stockQuantity, category) VALUES(@name, @description, @price, @stockQuantity, @category)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", produto.name);
                        command.Parameters.AddWithValue("@description", produto.description);
                        command.Parameters.AddWithValue("@price", produto.price);
                        command.Parameters.AddWithValue("@stockQuantity", produto.stockQuantity);
                        command.Parameters.AddWithValue("@category", produto.category);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no insert product: {ex}");
            }
        }

        public void Update(Product produto)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "UPDATE PRODUCT SET name = @name, description = @description, price = @price, stockQuantity = @stockQuantity, category = @category WHERE id = @id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", produto.name);
                        command.Parameters.AddWithValue("@description", produto.description);
                        command.Parameters.AddWithValue("@price", produto.price);
                        command.Parameters.AddWithValue("@stockQuantity", produto.stockQuantity);
                        command.Parameters.AddWithValue("@status", produto.category);
                        command.Parameters.AddWithValue("@id", produto.id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no update product: {ex}");
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "DELETE FROM PRODUCT WHERE id = @id";

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
                throw new Exception($"Erro ao deletar o produto por id: {ex.Message}", ex);
            }
        }

    }
}