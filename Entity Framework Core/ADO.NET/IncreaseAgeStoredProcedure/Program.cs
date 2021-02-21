using System;
using Microsoft.Data.SqlClient;

namespace IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = @"Server=DESKTOP-PFRD5K8\SQLEXPRESS;DataBase=MinionsDB;Integrated Security=true;";
            SqlConnection dbConnection = new SqlConnection(stringConnection);
            dbConnection.Open();

            using (dbConnection)
            {
                int id = int.Parse(Console.ReadLine());

                string storedProcedureQry = "EXEC usp_GetOlder @id";
                SqlCommand cmd = new SqlCommand(storedProcedureQry, dbConnection);

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
                    }
                }
            }
        }
    }
}
