using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Threading.Tasks;

namespace _3.MinionNames
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int vilianId = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Server=.;Database=MinionsDB;User=sa;Password = Maxmen111; ");
            await con.OpenAsync();
            using (con)
            {
                SqlCommand GetVilliainMinionsNameAge = new SqlCommand(
                    @"SELECT M.[Name] , M.Age
                    FROM Villains AS V
                    JOIN MinionsVillains AS MV
                    ON V.Id = MV.VillainId
                    JOIN Minions AS M
                    ON MV.MinionId = M.Id
                    WHERE V.Id = @Id
                    ORDER BY M.Name", con);
                SqlCommand GetVillainName = new SqlCommand(
                    @"SELECT [Name]
                    FROM Villains
                    WHERE Id = @Id" , con);
                GetVilliainMinionsNameAge.Parameters.AddWithValue("@Id", vilianId);
                GetVillainName.Parameters.AddWithValue("@Id", vilianId);
                StringBuilder sb = new StringBuilder();
                using (GetVillainName)
                {
                    SqlDataReader reader = await GetVillainName.ExecuteReaderAsync();
                    using (reader)
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine($"No villain with ID {vilianId} exists in the database.");
                            return;
                        }
                        while (await reader.ReadAsync())
                        {
                            string name = (string)reader["Name"];
                            sb.AppendLine($"Villain: {name}");
                        }
                        
                    }
                }
                using (GetVilliainMinionsNameAge)
                {
                    SqlDataReader reader = await GetVilliainMinionsNameAge.ExecuteReaderAsync();
                    using (reader)
                    {
                        int i = 0;
                        if (!reader.HasRows)
                        {
                            sb.Append("(no minions)");
                            Console.WriteLine(sb.ToString());
                            return;
                        }
                        while (await reader.ReadAsync())
                        {
                            i++;
                            string name = (string)reader["Name"];
                            int age = (int)reader["Age"];
                            sb.AppendLine($"{i}. {name} {age}");
                            
                        }
                        Console.WriteLine(sb.ToString().Trim());
                    }
                }
            }
        }
    }
}
