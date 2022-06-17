using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Geoprofs.Database
{
    public class Update
    {
        public static async Task UpdateQuery(int personeelid)
        {
            Program.personeel = new();
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs"
            );
            await connection.OpenAsync();

            using var query = new MySqlCommand("");
            //using var reader = await query.ExecuteReaderAsync();
        }
    }
}
