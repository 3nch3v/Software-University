using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = @"Server=DESKTOP-PFRD5K8\SQLEXPRESS;DataBase=MinionsDB;Integrated Security=true;";
            SqlConnection dbConnection = new SqlConnection(stringConnection);
            dbConnection.Open();

            List<string> minionsNames = new List<string>();

            using (dbConnection)
            {
                string qry = "SELECT Name FROM Minions";

                SqlCommand cmd = new SqlCommand(qry, dbConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        minionsNames.Add(reader[0] as string);
                    }
                }
            }

            PrintNames(minionsNames);
        }

        private static void PrintNames(List<string> minionsNames)
        {
            for (int i = 0; i < Math.Ceiling(minionsNames.Count / 2.0); i++)
            {
                Console.WriteLine(minionsNames[i]);

                for (int j = minionsNames.Count - 1 - i; j >= minionsNames.Count - 1 - i; j--)
                {
                    if ((minionsNames.Count / 2) % 2 != 0)
                    {
                        if (i != j)
                        {
                            Console.WriteLine(minionsNames[j]);
                        }
                    }

                    else
                    {
                        Console.WriteLine(minionsNames[j]);
                    }
                }
            }
        }
    }
}
