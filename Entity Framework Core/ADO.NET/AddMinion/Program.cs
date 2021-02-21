using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string townName = minionInfo[2];

            string[] villainInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            string villainName = villainInfo[0];


            string stringConnection = @"Server=DESKTOP-PFRD5K8\SQLEXPRESS;DataBase=MinionsDB;Integrated Security=true;";
            SqlConnection dbConnection= new SqlConnection(stringConnection);

            dbConnection.Open();

            using (dbConnection)
            {
                var townId = GetTownId(dbConnection, townName);

                if (townId == null)
                {
                    AddTown(dbConnection, townName);
                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                var villainIdResult = GetVillainId(dbConnection, villainName);

                if (villainIdResult == null)
                {
                    AddVillain(dbConnection, villainName);
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }


                var minionId = GetMinionId(dbConnection, minionName);

                if (minionId == null)
                {
                    int minionTownId = (int)GetTownId(dbConnection, townName);
                    AddMinion(dbConnection, minionName, minionAge, minionTownId);
                }

                AddMinionToVillain(dbConnection, villainName, minionName);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void AddMinionToVillain(SqlConnection dbConnection, string villainName, string minionName)
        {
            string addMinionToVillain = "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@villainId, @minionId)";

            int villainId = (int) GetVillainId(dbConnection, villainName);
            int minionId = (int) GetMinionId(dbConnection, minionName);

            using SqlCommand cmd = new SqlCommand(addMinionToVillain, dbConnection);
            cmd.Parameters.AddWithValue("@villainId", villainId);
            cmd.Parameters.AddWithValue("@minionId", minionId);
            cmd.ExecuteNonQuery();
        }

        private static void AddMinion(SqlConnection dbConnection, string minionName, int minionAge, int townId)
        {
            string addMinionQry = "INSERT INTO Minions(Name, Age, TownId) VALUES(@nam, @age, @townId)";
            using SqlCommand addMinion = new SqlCommand(addMinionQry, dbConnection);
            addMinion.Parameters.AddWithValue("@nam", minionName);
            addMinion.Parameters.AddWithValue("@age", minionAge);
            addMinion.Parameters.AddWithValue("@townId", townId);

            addMinion.ExecuteNonQuery();
        }

        private static int? GetMinionId(SqlConnection dbConnection, string minionName)
        {
            string minionIdQry = "SELECT Id FROM Minions WHERE Name = @Name";
            using SqlCommand minion = new SqlCommand(minionIdQry, dbConnection);
            minion.Parameters.AddWithValue("@Name", minionName);

            int? minionResult = (int?) minion.ExecuteScalar();
            return minionResult;
        }

        private static void AddVillain(SqlConnection dbConnection, string villainName)
        {
            string addVillainQry = "INSERT INTO Villains(Name, EvilnessFactorId)  VALUES(@villainName, 4)";
            using SqlCommand addVillain = new SqlCommand(addVillainQry, dbConnection);
            addVillain.Parameters.AddWithValue("@villainName", villainName);
            addVillain.ExecuteNonQuery();
        }

        private static int? GetVillainId(SqlConnection dbConnection, string villainName)
        {
            string villaindIdQry = "SELECT Id FROM Villains WHERE Name = @Name";

            using SqlCommand villainId = new SqlCommand(villaindIdQry, dbConnection);
            villainId.Parameters.AddWithValue("@Name", villainName);

            int? returnedId = (int?) villainId.ExecuteScalar();
            return returnedId;
        }

        private static void AddTown(SqlConnection dbConnection, string townName)
        {
            string insertTownQuery = "INSERT INTO Towns(Name) VALUES(@townName)";
            using SqlCommand insertTown = new SqlCommand(insertTownQuery, dbConnection);
            insertTown.Parameters.AddWithValue("@townName", townName);
            insertTown.ExecuteNonQuery();
        }

        private static int? GetTownId(SqlConnection dbConnection, string townName)
        {
            string checkForTown = $"SELECT Id FROM Towns WHERE Name = @townName";
            using SqlCommand cmd = new SqlCommand(checkForTown, dbConnection);
            cmd.Parameters.AddWithValue("@townName", townName);
            int? townId = (int?)cmd.ExecuteScalar();
            return townId;
        }
    }
}
