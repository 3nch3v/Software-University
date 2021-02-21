using System;
using Microsoft.Data.SqlClient;

namespace VillainNames
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
                string villainNames = @"SELECT v.Name, 
                                               COUNT(mv.VillainId) AS MinionsCount  
                                           FROM Villains AS v
                                           JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                           GROUP BY v.Id, v.Name
                                               HAVING COUNT(mv.VillainId) > 3
                                           ORDER BY COUNT(mv.VillainId)";

                using SqlCommand cmd = new SqlCommand(villainNames, dbConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }
                }

            }
        }
    }
}
