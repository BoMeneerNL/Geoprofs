using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Geoprofs.Database
{
    public class Select
    {
        public static async Task SelectQuery()
        {
            Program.personeel = new();
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs"
            );
            await connection.OpenAsync();

            using var query = new MySqlCommand("SELECT * FROM personeel", connection);
            using var reader = await query.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
<<<<<<< Updated upstream:Geoprofs/Database/create.cs
                Dictionary<string, object> Personeel = new()
                {
                    { "personeelid", reader.GetInt64(0) },
                    { "rankid", reader.GetInt64(1) },
                    { "personeelsnaam", reader.GetString(2) },
                    { "password", reader.GetString(3) }
                };
=======
                Dictionary<string, object> Personeel = new();

                Personeel.Add("personeelid", reader.GetInt64(0));
                Personeel.Add("rankid", reader.GetInt64(1));
                Personeel.Add("personeelsnaam", reader.GetString(2));
                Personeel.Add("password", reader.GetString(3));

>>>>>>> Stashed changes:Geoprofs/Database/select.cs
                Program.personeel.Add(Personeel);
            }
        }
    }
}
