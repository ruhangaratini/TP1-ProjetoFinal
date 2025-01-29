using LitePDV.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitePDV.Config
{
    class SqlServerConfig
    {

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Response<List<Dictionary<string, dynamic>>> ExecuteQuery(string query, Dictionary<string, dynamic> parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }

                        SqlDataReader reader = command.ExecuteReader();

                        var data = new List<Dictionary<string, object>>();

                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }
                            data.Add(row);
                        }

                        return new Response<List<Dictionary<string, dynamic>>>(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Response<List<Dictionary<string, object>>>.FromError(ex.Message);
            }
        }


        public Response<int> Execute(string query, Dictionary<String, dynamic> parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }

                        int affectedRows = command.ExecuteNonQuery();
                        connection.Close();

                        var res = new Response<int>(affectedRows);
                        res.affectedRows = affectedRows;
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Response<int>.FromError(ex.Message);
            }
        }


        public Response<int> ExecuteQueryScalar(string query, Dictionary<String, dynamic> parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }

                        var result = command.ExecuteScalar();
                        connection.Close();

                        if (result != null && int.TryParse(result.ToString(), out int value))
                        {
                            var res = new Response<int>();
                            res.insertedId = value;
                            return res;
                        }

                        return Response<int>.FromError("Não foi retornado nenhum valor.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Response<int>.FromError(ex.Message);
            }
        }

    }
}
