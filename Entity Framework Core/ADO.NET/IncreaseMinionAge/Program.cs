using System;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace IncreaseMinionAge
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
                int[] ids = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                UpdateDataById(dbConnection, ids);

                StringBuilder minions = GetMinionsData(dbConnection);
                Console.WriteLine(minions);
            }
        }

        private static StringBuilder GetMinionsData(SqlConnection dbConnection)
        {
            StringBuilder sb = new StringBuilder();

            string minionInfoQry = "SELECT Name, Age FROM Minions";

            SqlCommand cmd = new SqlCommand(minionInfoQry, dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
                }
            }

            return sb;
        }

        private static void UpdateDataById(SqlConnection dbConnection, int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                string updateQuery = @" UPDATE Minions
                                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                        WHERE Id = @Id";

                using SqlCommand cmd = new SqlCommand(updateQuery, dbConnection);

                cmd.Parameters.AddWithValue("@Id", ids[i]);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
