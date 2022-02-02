using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _1.InitialSetup
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=.;Database=MinionsDB;User=sa;Password = Maxmen111; ");
            await con.OpenAsync();
            using (con)
            {
                SqlCommand command = new SqlCommand(@"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                    FROM Villains AS v
                                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                                    GROUP BY v.Id, v.Name
                                                    HAVING COUNT(mv.VillainId) > 3
                                                    ORDER BY COUNT(mv.VillainId)" , con);
                using (command)
                { 
                   SqlDataReader reader = await command.ExecuteReaderAsync();
                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            string name = (string)reader["Name"];
                            int minionsCount = (int)reader["MinionsCount"];
                            Console.WriteLine($"{name} - {minionsCount}");
                        }
                    }
                }
            }
        }
    }
}
