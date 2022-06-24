using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Geoprofs.Database
{
    public class Insert
    {
        public static async Task InsertUser(int rankid, string personeelsnaam, string password)
        {
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs"
            );
            await connection.OpenAsync();
            using var query = new MySqlCommand($"INSERT INTO personeel (RankId, PersoneelsNaam, Password) VALUES ({rankid}, '{personeelsnaam}', '{password}');");
            query.Connection = connection;
            query.ExecuteNonQuery();
        }

        public static async Task InsertVerlof(int personeelid, string vanaf, string tot, string beschrijving)
        {
            using var connection = new MySqlConnection(
                "server=localhost;user=geoprofs;password=guiSs*X*Gk!pPyrK;database=geoprofs"
            );
            await connection.OpenAsync();
            using var query = new MySqlCommand($"INSERT INTO verlof (PersoneelID, Van, Tot, VerlofOmschrijving, status, VerlofTypeID) VALUES ('{personeelid}', '{vanaf}', '{tot}', '{beschrijving}', 1, 1 );");
            query.Connection = connection;
            query.ExecuteNonQuery();
        }
    }
}
