using Geoprofs.Classes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geoprofs
{
    public class Program
    {
        public static List<Dictionary<string, object>> personeel = new();
        public static List<Dictionary<string, object>> verlof = new();
        public static User currentuser = new();
        public static async Task Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            await Database.Select.PersoneelSelectQuery();
            await Database.Select.VerlofSelectQuery();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
