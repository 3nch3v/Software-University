using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = @"Server=DESKTOP-PFRD5K8\SQLEXPRESS;DataBase=MinionsDB;Integrated Security=true;";
            SqlConnection dbConnection = new SqlConnection(stringConnection);
            dbConnection.Open();

            string country = Console.ReadLine();

            using (dbConnection)
            {
                var affectedRows = ChangeLettersToUpper(dbConnection, country);

                if (affectedRows > 0)
                {
                    Console.WriteLine($"{affectedRows} town names were affected.");
                    var towns = GetTownNames(dbConnection, country);
                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }

                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }

        private static List<string> GetTownNames(SqlConnection dbConnection, string country)
        {
            List<string> towns = new List<string>();

            string getTownNameQry = @"SELECT t.Name
                                            FROM Towns as t
                                            JOIN Countries AS c ON c.Id = t.CountryCode
                                            WHERE c.Name = @countryName";

            SqlCommand townsCmd = new SqlCommand(getTownNameQry, dbConnection);
            townsCmd.Parameters.AddWithValue("@countryName", country);
            SqlDataReader reader = townsCmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    towns.Add(reader[0] as string);
                }
            }

            return towns;
        }

        private static int ChangeLettersToUpper(SqlConnection dbConnection, string country)
        {
            string changeToUpperQry = @"UPDATE Towns
                                            SET Name = UPPER(Name)
                                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            SqlCommand cmd = new SqlCommand(changeToUpperQry, dbConnection);
            cmd.Parameters.AddWithValue("@countryName", country);
            int affectedRows = cmd.ExecuteNonQuery();
            return affectedRows;
        }
    }
}
