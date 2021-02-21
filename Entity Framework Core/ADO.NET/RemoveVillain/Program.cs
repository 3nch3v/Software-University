using System;
using Microsoft.Data.SqlClient;

namespace RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = @"Server=DESKTOP-PFRD5K8\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";
            var dbConnection = new SqlConnection(stringConnection);
            dbConnection.Open();

            using (dbConnection)
            {
                int villainId = int.Parse(Console.ReadLine());

                string villainNameQry = "SELECT Name FROM Villains WHERE Id = @villainId";
                using SqlCommand cmd = new SqlCommand(villainNameQry, dbConnection);
                cmd.Parameters.AddWithValue("@villainId", villainId);

                string villianName = cmd.ExecuteScalar() as string;

                if (villianName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string deleteFromMinionsVillainsQry = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                using SqlCommand deleteFromMinionsVillains = new SqlCommand(deleteFromMinionsVillainsQry, dbConnection);
                deleteFromMinionsVillains.Parameters.AddWithValue("@villainId", villainId);

                int releasedMinions = (int) deleteFromMinionsVillains.ExecuteNonQuery();

                string deleteVillainQry = "DELETE FROM Villains WHERE Id = @villainId";
                using SqlCommand deleteVillain = new SqlCommand(deleteVillainQry, dbConnection);
                deleteVillain.Parameters.AddWithValue("@villainId", villainId);
                deleteVillain.ExecuteNonQuery();


                Console.WriteLine($"{villianName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
        }
    }
}
