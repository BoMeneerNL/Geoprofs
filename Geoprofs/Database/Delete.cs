using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Geoprofs.Database
{
    public class Delete
    {
        public static async Task DeleteQuery(int personeelid)
        {
            Program.personeel = new();
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs"
            );
            await connection.OpenAsync();

            using var query = new MySqlCommand("DELETE FROM personeel WHERE personeelid='" + personeelid + "'", connection);
            using var reader = await query.ExecuteReaderAsync();
        }
    }
}
