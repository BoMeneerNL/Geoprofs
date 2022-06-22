using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Geoprofs.Database
{
    public class Update
    {
        public static async Task UpdateUser(int personeelid, int rankid, string personeelsnaam, string password)
        {
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs"
            );
            await connection.OpenAsync();
            using var query = new MySqlCommand($"UPDATE personeel SET RankID={rankid}, PersoneelsNaam='{personeelsnaam}', Password='{password}' WHERE PersoneelID={personeelid}");
            query.Connection = connection;
            query.ExecuteNonQuery();
        }
    }
}
