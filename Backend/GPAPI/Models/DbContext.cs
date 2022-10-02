using GPAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Verlof> Verlof { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Authtoken> Authtokens { get; set; }
    }
}
