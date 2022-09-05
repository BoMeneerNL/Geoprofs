using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Medewerker> Medewerkers { get; set; }
    }
}
