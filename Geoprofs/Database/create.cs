using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Geoprofs.Database
{
    public class create
    {
        public static async Task jeffAsync()
        {
            Program.personeel = new();
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs");
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM personeel", connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                Dictionary<string, object> Personeel = new();

                Personeel.Add("personeelid",reader.GetInt64(0));
                Personeel.Add("rankid", reader.GetInt64(1));
                Personeel.Add("personeelsnaam",reader.GetString(2));
                Personeel.Add("password", reader.GetString(3));
                Program.personeel.Add(Personeel);
                
            }
        }
    }
}
