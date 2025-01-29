using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitePDV.Model;
using LitePDV.Config;
using LitePDV.Checks;
using System.Reflection.Emit;

namespace LitePDV.Repository
{
    class ProductRepository
    {
        private static readonly SqlServerConfig _db = new SqlServerConfig();

        static void CreateTable()
        {
            _db.Execute(@"
                CREATE TABLE PRODUCT (
                    id INT PRIMARY KEY IDENTITY,
                    name VARCHAR(100) NOT NULL,
                    description VARCHAR(255) NOT NULL,
                    price NUMERIC(18, 2) NOT NULL,
                    stockQuantity INT,
                    category VARCHAR(100)
                );
            ");
        }


        public List<Product> GetAll()
        {
            var products = new List<Product>();
            Response<List<Dictionary<string, dynamic>>> response = _db.ExecuteQuery("SELECT * FROM PRODUCT");

            if (!response.success || response.data == null)
            {
                return null;
            }

            foreach (var row in response.data)
            {
                var product = new Product
                        (
                            id: Convert.ToInt32(row["id"]),
                            name: row["name"].ToString(),
                            description: row["description"].ToString(),
                            price: Convert.ToDouble(row["price"]),
                            stockQuantity: Convert.ToInt32(row["stockQuantity"]),
                            category: row["category"].ToString()
                        );

                products.Add(product);
            }

            return products;
        }

        public Product GetById(int id)
        {
            Product product = null;

            var parameter = new Dictionary<string, dynamic>
            {
                { "@id", id }
            };

            Response<List<Dictionary<string, dynamic>>> response = _db.ExecuteQuery("SELECT * FROM PRODUCT WHERE id = @id", parameter);

            if (!response.success || response.data == null || response.data.Count == 0)
            {
                return null;
            }

            var row = response.data.First();

            product = new Product
                        (
                            id: Convert.ToInt32(row["id"]),
                            name: row["name"].ToString(),
                            description: row["description"].ToString(),
                            price: Convert.ToDouble(row["price"]),
                            stockQuantity: Convert.ToInt32(row["stockQuantity"]),
                            category: row["category"].ToString()
                        );

            return product;
        }

        public Response<int> Insert(Product product)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "@name", product.name },
                { "@description", product.description },
                { "@price", product.price },
                { "@stockQuantity", product.stockQuantity },
                { "@category", product.category},
            };

            const string query = "INSERT INTO PRODUCT (name, description, price, stockQuantity, category) VALUES(@name, @description, @price, @stockQuantity, @category)";

            return _db.ExecuteQueryScalar(query, parameters);
        }

        public bool Update(Product product)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "@name", product.name },
                { "@description", product.description },
                { "@price", product.price },
                { "@stockQuantity", product.stockQuantity },
                { "@category", product.category},
                { "@id", product.id},
            };

            const string query = "UPDATE PRODUCT SET name = @name, description = @description, price = @price, stockQuantity = @stockQuantity, category = @category WHERE id = @id";

            Response<int> response = _db.Execute(query, parameters);

            return response.success && response.affectedRows > 0;
        }

        public bool DeleteById(int id)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "@id", id }
            };

            const string query = "DELETE FROM PRODUCT WHERE id = @id";

            Response<int> response = _db.Execute(query, parameters);

            return response.success && response.affectedRows > 0;
        }

    }
}