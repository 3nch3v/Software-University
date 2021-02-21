using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace MinionNames
{
    class Program
    {
        private const string stringConnection = @"Server=DESKTOP-PFRD5K8\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            var dbConnection = new SqlConnection(stringConnection);

            dbConnection.Open();

            using (dbConnection)
            {
                int villainIdInput = int.Parse(Console.ReadLine());

                string villainNameQuery = $"SELECT Name FROM Villains WHERE Id = {villainIdInput}";
                SqlCommand cmd = new SqlCommand(villainNameQuery, dbConnection);
                string villainName = (string) cmd.ExecuteScalar();

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainIdInput} exists in the database.");
                }

                else
                {
                    Console.WriteLine($"Villain: {villainName}");

                    StringBuilder minions = GetMinions(dbConnection, villainIdInput);

                    if (minions == null)
                    {
                        Console.WriteLine("(no minions)");
                    }

                    else
                    {
                        Console.WriteLine(minions);
                    }
                }
            }
        }

        private static StringBuilder GetMinions(SqlConnection dbConnection, int villainIdInput)
        {
            string villainMinionsQry = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                            m.Name, 
                                            m.Age
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id " +
                                       $"WHERE mv.VillainId = {villainIdInput} " +
                                       "ORDER BY m.Name";

            SqlCommand cmd = new SqlCommand(villainMinionsQry, dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            using (reader)
            {
                while (reader.Read())
                {
                    sb.AppendLine($"{reader[0]}. {reader[1]} {reader[2]}");
                }
            }

            return sb;
        }
    }
}
