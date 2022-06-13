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
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs");
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM personeel", connection);
            using var reader = await command.ExecuteReaderAsync();
            List<DataRow> datarows = new();
            
            while (await reader.ReadAsync())
            {
                DataRow dr = null;



                datarows.Add(dr);
                
            }
            DataTable dt = datarows.ToArray().CopyToDataTable();
        }
    }
}
