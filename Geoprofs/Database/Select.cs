using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Geoprofs.Database
{
    public class Select
    {
        public static async Task PersoneelSelectQuery()
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
                Dictionary<string, object> Personeel = new()
                {
                    { "personeelid", reader.GetInt64(0) },
                    { "rankid", reader.GetInt64(1) },
                    { "personeelsnaam", reader.GetString(2) },
                    { "password", reader.GetString(3) }
                };

                Program.personeel.Add(Personeel);
            }
        }

        public static async Task VerlofSelectQuery()
        {
            Program.verlof = new();
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs"
            );
            await connection.OpenAsync();

            using var query = new MySqlCommand("SELECT * FROM verlof", connection);
            using var reader = await query.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Dictionary<string, object> Verlof = new()
                {
                    { "verlofid", reader.GetInt64(0) },
                    { "tot", reader.GetDateOnly(1) },
                    { "personeelid", reader.GetInt64(2) },
                    { "verloftypeid", reader.GetInt64(3) },
                    { "verlofomschrijving", reader.GetString(4) },
                    { "van", reader.GetDateOnly(5) },
                    { "status", reader.GetInt64(6) },
                };

                Program.verlof.Add(Verlof);
            }
        }
    }
}
