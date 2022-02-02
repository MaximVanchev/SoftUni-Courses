using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AddMinion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> inputLineOne = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();
            string minionName = inputLineOne[1];
            int minionAge = int.Parse(inputLineOne[2]);
            string minionTownName = inputLineOne[3];

            List<string> inputLineTwo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string villainName = inputLineTwo[1];

            SqlConnection con = new SqlConnection(@"Server=.;Database=MinionsDB;User=sa;Password = Maxmen111; ");
            await con.OpenAsync();

            StringBuilder sb = new StringBuilder();

            using (con)
            {
                SqlCommand GetTownId = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", con);
                SqlCommand GetVillainId = new SqlCommand(@"SELECT Id FROM Villains WHERE Name = @villainName" , con);
                SqlCommand GetMinionId = new SqlCommand(@"SELECT Id FROM Minions WHERE Name = @minionName" , con);

                GetTownId.Parameters.AddWithValue("@townName", minionTownName);
                GetVillainId.Parameters.AddWithValue("@villainName", villainName);
                GetMinionId.Parameters.AddWithValue("@minionName", minionName);
                object isThereTown = await GetTownId.ExecuteNonQueryAsync();
                object isThereVillain = await GetVillainId.ExecuteScalarAsync();
                object isThereMinion = await GetMinionId.ExecuteScalarAsync();

                if (isThereTown == null || (int)isThereTown == -1)
                {
                    SqlCommand InsertIntoTowns = new SqlCommand(@"INSERT INTO Towns(Name) VALUES(@townName)" , con);
                    InsertIntoTowns.Parameters.AddWithValue("@townName", minionTownName);
                    sb.AppendLine($"Town {minionTownName} was added to the database.");
                    isThereTown = await GetTownId.ExecuteScalarAsync();
                }

                if (isThereVillain == null || (int)isThereVillain == -1)
                {
                    SqlCommand InsertIntoVillains = new SqlCommand(@"INSERT INTO Villains VALUES(@villainName , 4)" , con);
                    InsertIntoVillains.Parameters.AddWithValue("@villainName", villainName);
                    sb.AppendLine($"Villain {villainName} was added to the database.");
                    isThereVillain = await GetVillainId.ExecuteScalarAsync();
                }

                SqlCommand InsertIntoMinions = new SqlCommand(@"INSERT INTO Minions VALUES(@minionName , @minionAge , @minionTownId)" , con);
                int isThereTownInt = (int)isThereTown;
                int isThereVillainInt = (int)isThereVillain;

                InsertIntoMinions.Parameters.AddWithValue("@minionName", minionName);
                InsertIntoMinions.Parameters.AddWithValue("@minionAge", minionAge);
                InsertIntoMinions.Parameters.AddWithValue("@minionTownId", isThereTownInt);
                isThereMinion = await GetMinionId.ExecuteScalarAsync();
                int isThereMinionInt = (int)isThereMinion;

                SqlCommand InsertIntoMinionsVillains = new SqlCommand(@"INSERT INTO MinionsVillains VALUES(@minionId, @villainId)" , con);

                InsertIntoMinionsVillains.Parameters.AddWithValue("@minionId", isThereMinionInt);
                InsertIntoMinionsVillains.Parameters.AddWithValue("@villainId", isThereVillainInt);
                sb.Append($"Successfully added {minionName} to be minion of {villainName}.");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
