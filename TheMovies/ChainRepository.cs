using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Net.WebRequestMethods;

namespace TheMovies
{
    public class ChainRepository
    {
        private readonly string _connectionString =
            "Server=localhost\\SQLEXPRESS;Database=TheMovies;Trusted_Connection=True;TrustServerCertificate=True;";

        public int AddChain(string chainName)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            INSERT INTO Chain (ChainName)
            VALUES (@name);
            SELECT CAST(SCOPE_IDENTITY() AS int);";

            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@name", chainName);

            int newId = (int)command.ExecuteScalar();

            return newId;
        }
    }
}
    
